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
    public record GetAllUserProfilesQuery : IRequest<OperationResult<IEnumerable<UserProfile>>>;

}
