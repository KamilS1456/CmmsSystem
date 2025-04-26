using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using MediatR;

namespace Cmms.Queries.EquipmentQueries
{
    public record GetEquipmentListQuery() : IRequest<OperationResult<IEnumerable<Equipment>>>;

}

