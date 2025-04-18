using Cmms.Core.Models;
using Cmms.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Queries.UserProfilesQueries
{
    public class GetUserProfileByIdQuery : IRequest<OperationResult<UserProfile>>
    { 
        public Guid UserProfileId { get; set; }
    }

}
