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
using Microsoft.EntityFrameworkCore;
using Cmms.Core.Queries.QuestTypeQueries;

namespace Cmms.Core.Handlers.QuestTypeHandlers.QuestTypeQuerieHandlers
{
    public class GetQuestTypeByIdHandler : IRequestHandler<GetQuestTypeByIdQuery, OperationResult<QuestType>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public GetQuestTypeByIdHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;

        }
        public async Task<OperationResult<QuestType>> Handle(GetQuestTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<QuestType>();
            operationResult.Payload = await _cmmsDbContext.QuestTypes.FirstOrDefaultAsync(f => f.Id == request.Id);

            if (operationResult.Payload is null)
            {
                operationResult.AddError(ErrorCode.NotFound, string.Format("No QuestType found for ID {0}", request.Id));
            }
            return operationResult;
        }
    }
}

