using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using MediatR;

namespace Cmms.Queries.EquipmentSetQueries
{
    public record GetEquipmentSetListQuery() : IRequest<OperationResult<IEnumerable<EquipmentSet>>>;

}

