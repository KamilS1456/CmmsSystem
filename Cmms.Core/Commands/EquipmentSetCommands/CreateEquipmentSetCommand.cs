using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using Cmms.DtoModels;
using MediatR;

namespace Cmms.Core.Commands.EquipmentSetCommands
{
    public class CreateEquipmentSetCommand : IRequest<OperationResult<EquipmentSet>>
    {
        public Guid CreatedByUserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<EquipmentSetToEquipmentDto> EquipmentSetToEquipments { get; set; }
    }
}
