using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Queries.QuestQueries
{
    public record GetQuestByIdQuery(Guid Id) : IRequest<OperationResult<Quest>> ;

}
