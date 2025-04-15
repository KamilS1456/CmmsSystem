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
    internal class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, IEnumerable<UserProfile>>
    {
        private readonly CmmsDbContext _dbContext;
        public GetAllUserProfilesQueryHandler(CmmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.UserProfileS.ToListAsync(cancellationToken);
        }
    }

}
