using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using MediatR;

namespace Cmms.Core.Queries.QuestQueries
{
    public record GetQuestByIdQuery(Guid Id) : IRequest<OperationResult<Quest>>;

}
