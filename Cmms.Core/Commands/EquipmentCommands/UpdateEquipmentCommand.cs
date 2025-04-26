using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using MediatR;
using static Cmms.Domain.Dictionary.EquipmentConditionEnum;

namespace Cmms.Core.Commands.EquipmentCommands
{
    public class UpdateEquipmentCommand : IRequest<OperationResult<Equipment>>
    {
        public Guid UpdateByUserID { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public EquipmentCondition Condition { get; set; }
        public DateTime LastServiceDateTime { get; set; }
    }
}
