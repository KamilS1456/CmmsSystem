using Cmms.Core.Queries.QuestQueries;
using MediatR;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Cmms.Domain.Entities.Equipments;
using Cmms.Core.Queries.EquipmentQueries;
using Cmms.Core.Queries.EquipmentSetQueries;

namespace Cmms.Core.Handlers.EquipmentSetHandlers.EquipmentSetQuerieHandlers
{
    public class GetEquipmentSetByIdHandler : IRequestHandler<GetEquipmentSetByIdQuery, OperationResult<EquipmentSet>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public GetEquipmentSetByIdHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;

        }
        public async Task<OperationResult<EquipmentSet>> Handle(GetEquipmentSetByIdQuery request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<EquipmentSet>();
            operationResult.Payload = await _cmmsDbContext.EquipmentSets.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (operationResult.Payload is null)
            {
                operationResult.AddError(ErrorCode.NotFound, string.Format("No EquipmentSet found for ID {0}", request.Id));
            }
            return operationResult;
        }
    }
}

