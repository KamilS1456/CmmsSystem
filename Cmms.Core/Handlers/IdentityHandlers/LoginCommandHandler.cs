using AutoMapper;
using Cmms.Core.Commands.IdentityCommands;
using Cmms.Core.DtoModels;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.Core.Services;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Cmms.Core.Handlers.IdentityHandlers
{
   public  class LoginCommandHandler : IRequestHandler<LoginCommand, OperationResult<IdentityUserProfileDto>>
    {
        private readonly CmmsDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityService _identityService;
        private readonly IMapper _mapper;
        private OperationResult<IdentityUserProfileDto> _result = new();

        public LoginCommandHandler(CmmsDbContext ctx, UserManager<IdentityUser> userManager,
            IdentityService identityService, IMapper mapper)
        {
            _dbContext = ctx;
            _userManager = userManager;
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<OperationResult<IdentityUserProfileDto>> Handle(LoginCommand request,
            CancellationToken cancellationToken)
        {
            OperationResult<IdentityUserProfileDto> result = new();
            try
            {
                var identityUser = await ValidateAndGetIdentityAsync(request);
                if (_result.IsError) return _result;

                var userProfile = await _dbContext.UserProfileS
                    .FirstOrDefaultAsync(up => up.IdentityId == identityUser.Id, cancellationToken:
                        cancellationToken);


                _result.Payload = _mapper.Map<IdentityUserProfileDto>(userProfile);
                _result.Payload.UserName = identityUser.UserName;
                _result.Payload.Token = _identityService.GetJwtString(identityUser, userProfile);
                return _result;

            }
            catch (Exception e)
            {
                _result.AddUnknownError(e.Message);
            }

            return _result;
        }

        private async Task<IdentityUser> ValidateAndGetIdentityAsync(LoginCommand request)
        {
            var identityUser = await _userManager.FindByEmailAsync(request.UserName);

            if (identityUser is null)
                _result.AddError(ErrorCode.IdentityUserDoesNotExist,
                    "Unable to find a user with the specified username");

            var validPassword = await _userManager.CheckPasswordAsync(identityUser, request.Password);

            if (!validPassword)
                _result.AddError(ErrorCode.IncorrectPassword, "The provided password is incorrect");

            return identityUser;
        }        
    }
}
