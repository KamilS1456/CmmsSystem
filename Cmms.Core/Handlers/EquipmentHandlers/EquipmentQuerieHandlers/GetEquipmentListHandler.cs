//using Cmms.Core.EntitieDbCOntext;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities.Equipments;
using Cmms.Queries.EquipmentQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cmms.Core.Handlers.EquipmentHandlers.EquipmentQuerieHandlers
{
    public class GetEquipmentListHandler : IRequestHandler<GetEquipmentListQuery, OperationResult<IEnumerable<Equipment>>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public GetEquipmentListHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;

        }
        public async Task<OperationResult<IEnumerable<Equipment>>> Handle(GetEquipmentListQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<Equipment>>();

            result.Payload = await _cmmsDbContext.Equipments.ToListAsync(cancellationToken);

            return result;
        }
    }
}
