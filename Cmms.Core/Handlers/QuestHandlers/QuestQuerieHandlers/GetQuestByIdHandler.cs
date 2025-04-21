using Cmms.Core.Queries.QuestQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmms.Domain.Entities.Quest;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Core.Enums;
using Cmms.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cmms.Core.Handlers.QuestHandlers.QuestQuerieHandlers
{
    public class GetQuestTypeByIdHandler : IRequestHandler<GetQuestByIdQuery, OperationResult<Quest>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public GetQuestTypeByIdHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;

        }
        public async Task<OperationResult<Quest>> Handle(GetQuestByIdQuery request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<Quest>();
            operationResult.Payload = await _cmmsDbContext.Quests.FirstOrDefaultAsync(f => f.Id == request.Id);

            if (operationResult.Payload is null)
            {
                operationResult.AddError(ErrorCode.NotFound, string.Format("No Quest found for ID {0}", request.Id));
            }
            return operationResult;
        }
    }
}

