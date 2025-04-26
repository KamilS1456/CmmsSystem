//using Cmms.Core.EntitieDbCOntext;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities.Equipments;
using Cmms.Queries.EquipmentQueries;
using Cmms.Queries.EquipmentSetQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cmms.Core.Handlers.EquipmentSetHandlers.EquipmentSetQuerieHandlers
{
    public class GetEquipmentSetListHandler : IRequestHandler<GetEquipmentSetListQuery, OperationResult<IEnumerable<EquipmentSet>>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public GetEquipmentSetListHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;

        }
        public async Task<OperationResult<IEnumerable<EquipmentSet>>> Handle(GetEquipmentSetListQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<EquipmentSet>>();

            result.Payload = await _cmmsDbContext.EquipmentSets.ToListAsync(cancellationToken);

            return result;
        }
    }
}
