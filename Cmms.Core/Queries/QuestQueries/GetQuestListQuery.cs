using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using MediatR;

namespace Cmms.Queries.QuestQueries
{
    public record GetQuestListQuery() : IRequest<OperationResult<IEnumerable<Quest>>>;

}

