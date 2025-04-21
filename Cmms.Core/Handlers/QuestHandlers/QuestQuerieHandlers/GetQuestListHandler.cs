//using Cmms.Core.EntitieDbCOntext;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;
using Cmms.Domain.Entities.Quest;
using Cmms.Queries.QuestQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.QuestHandlers.QuestQuerieHandlers
{
    public class GetQuestListHandler : IRequestHandler<GetQuestListQuery, OperationResult<IEnumerable<Quest>>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public GetQuestListHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;

        }
        public async Task<OperationResult<IEnumerable<Quest>>> Handle(GetQuestListQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<Quest>>();

            result.Payload = await _cmmsDbContext.Quests.ToListAsync(cancellationToken);

            return result;
        }
    }
}
