using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using Cmms.DtoModels;
using MediatR;

namespace Cmms.Core.Commands.EquipmentSetCommands
{
    public class UpdateEquipmentSetCommand : IRequest<OperationResult<EquipmentSet>>
    {
        public Guid UpdateByUserID { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<EquipmentSetToEquipmentDto> EquipmentSetToEquipments { get; set; }
    }
}
