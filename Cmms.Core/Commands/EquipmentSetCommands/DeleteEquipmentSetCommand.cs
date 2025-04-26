using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using MediatR;

namespace Cmms.Core.Commands.EquipmentSetCommands
{
    public class DeleteEquipmentSetCommand : IRequest<OperationResult<EquipmentSet>>
    {
        public Guid Id { get; set; }

        public Guid DeletingByUserID { get; set; }
    }
}
