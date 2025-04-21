//using Cmms.Core.EntitieDbCOntext;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;
using Cmms.Domain.Entities.Quest;
using Cmms.Queries.QuestQueries;
using Cmms.Queries.QuestTypeQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.QuestTypeHandlers.QuestTypeQuerieHandlers
{
    public class GetQuestTypeListHandler : IRequestHandler<GetQuestTypeListQuery, OperationResult<IEnumerable<QuestType>>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public GetQuestTypeListHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;

        }
        public async Task<OperationResult<IEnumerable<QuestType>>> Handle(GetQuestTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<QuestType>>();

            result.Payload = await _cmmsDbContext.QuestTypes.ToListAsync(cancellationToken);

            return result;
        }
    }
}
