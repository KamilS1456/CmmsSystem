using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using MediatR;

namespace Cmms.Queries.QuestTypeQueries
{
    public record GetQuestTypeListQuery() : IRequest<OperationResult<IEnumerable<QuestType>>>;

}

