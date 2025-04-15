using Cmms.Domain.Entities;
using MediatR;

namespace Cmms.Queries.QuestQueries
{
    public record GetQuestListQuery() : IRequest<List<Quest>>;

}

