using Cmms.Core.Queries.QuestQueries;
using MediatR;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Cmms.Domain.Entities.Equipments;
using Cmms.Core.Queries.EquipmentQueries;

namespace Cmms.Core.Handlers.EquipmentHandlers.EquipmentQuerieHandlers
{
    public class GetEquipmentByIdHandler : IRequestHandler<GetEquipmentByIdQuery, OperationResult<Equipment>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public GetEquipmentByIdHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;

        }
        public async Task<OperationResult<Equipment>> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<Equipment>();
            operationResult.Payload = await _cmmsDbContext.Equipments.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (operationResult.Payload is null)
            {
                operationResult.AddError(ErrorCode.NotFound, string.Format("No Equipment found for ID {0}", request.Id));
            }
            return operationResult;
        }
    }
}

