using AutoMapper;
using Cmms.Core.Commands.IdentityCommands;
using Cmms.Core.DtoModels;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.Core.Services;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;
using Cmms.Domain.Exceptions;
using Cmms.DtoModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.IdentityHandlers
{
    public class RegisterIdentityHandler : IRequestHandler<RegisterIdentityCommand, OperationResult<IdentityUserProfileDto>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityService _identityService;
        private readonly IMapper _mapper;

        private OperationResult<IdentityUserProfileDto> _result = new();
        public RegisterIdentityHandler(CmmsDbContext cmmsDbContext, UserManager<IdentityUser> userManager, IdentityService identityService, IMapper mapper)
        {
            _cmmsDbContext = cmmsDbContext;
            _userManager = userManager;
            _identityService = identityService;
            _mapper = mapper;
        }
        public async Task<OperationResult<IdentityUserProfileDto>> Handle(RegisterIdentityCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IdentityUserProfileDto>();
            try
            {
                await ValidateIdentityDoesNotExist(request);
                if (_result.IsError) return _result;

                await using var transaction = await _cmmsDbContext.Database.BeginTransactionAsync(cancellationToken);

                var identity = await CreateIdentityUserAsync(request, transaction, cancellationToken);
                if (_result.IsError) return _result; 

                var profile = await CreateUserProfileAsync(request, transaction, identity, cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                _result.Payload = _mapper.Map<IdentityUserProfileDto>(profile);
                _result.Payload.UserName = identity.UserName; 
                _result.Payload.Token = _identityService.GetJwtString(identity, profile);
                return _result;
            } catch (UserProfileNotValidException ex){
                ex.ValidationErrors.ForEach(e => _result.AddError(ErrorCode.ValidationError, e));
            } catch (Exception e){
                _result.AddUnknownError(e.Message);
            }
            return result;
        }

        private async Task ValidateIdentityDoesNotExist(RegisterIdentityCommand request)
        {
            var existingIdentity = await _userManager.FindByEmailAsync(request.UserName);

            if (existingIdentity != null)
                _result.AddError(ErrorCode.IdentityUserAlreadyExists, "Provided email address already exists. Cannot register new user");

        }

        private async Task<IdentityUser> CreateIdentityUserAsync(RegisterIdentityCommand request,
            IDbContextTransaction transaction, CancellationToken cancellationToken)
        {
            var identity = new IdentityUser { Email = request.UserName, UserName = request.UserName };
            var createdIdentity = await _userManager.CreateAsync(identity, request.Password);
            if (!createdIdentity.Succeeded)
            {
                await transaction.RollbackAsync(cancellationToken);

                foreach (var identityError in createdIdentity.Errors)
                {
                    _result.AddError(ErrorCode.IdentityCreationFailed, identityError.Description);
                }
            }
            return identity;
        }

        private async Task<UserProfile> CreateUserProfileAsync(RegisterIdentityCommand request,
            IDbContextTransaction transaction, IdentityUser identity,
            CancellationToken cancellationToken)
        {
            try
            {
                var profileInfo = UserProfileBasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.UserName,
                    request.Phone, request.DateOfBirth, request.CurrentCity);

                var profile = UserProfile.CreateUserProfile(identity.Id, profileInfo);
                _cmmsDbContext.UserProfileS.Add(profile);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);
                return profile;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }       
    }

}
