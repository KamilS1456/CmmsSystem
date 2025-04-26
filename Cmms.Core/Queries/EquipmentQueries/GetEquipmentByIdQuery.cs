using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using MediatR;

namespace Cmms.Core.Queries.EquipmentQueries
{
    public record GetEquipmentByIdQuery(Guid Id) : IRequest<OperationResult<Equipment>>;

}
