using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Queries.QuestTypeQueries
{
    public record GetQuestTypeByIdQuery(Guid Id) : IRequest<OperationResult<QuestType>> ;

}
