using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.Core.Queries.UserProfilesQueries;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.UserProfileHandlers.UserProfilesQueryHandlers
{
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, OperationResult<UserProfile>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public GetUserProfileByIdQueryHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<UserProfile>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<UserProfile>();
            operationResult.Payload = await _cmmsDbContext.UserProfileS.FirstOrDefaultAsync(f => f.UserProfileId == request.UserProfileId);
            
            if (operationResult.Payload is null)
            {
                operationResult.AddError(ErrorCode.NotFound, string.Format("No UserProfile found for ID {0}", request.UserProfileId));
            }
            return operationResult;
        }
    }
}
