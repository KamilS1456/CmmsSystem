using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using MediatR;

namespace Cmms.Core.Queries.EquipmentSetQueries
{
    public record GetEquipmentSetByIdQuery(Guid Id) : IRequest<OperationResult<EquipmentSet>>;

}
