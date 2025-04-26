using AutoMapper;
using Cmms.Requests.EquipmentSet;
using Cmms.Core.Commands.EquipmentSetCommands;
using Cmms.Respones.EquipmentSetResponse;
using Cmms.Domain.Entities.Equipments;

namespace Cmms.MappingProfiles
{
    public class EquipmentSetMapping : Profile
    {
        public EquipmentSetMapping()
        {
            CreateMap<EquipmentSetCreate, CreateEquipmentSetCommand>();
            CreateMap<EquipmentSet, EquipmentSetResponse>();
            CreateMap<EquipmentSetUpdate, UpdateEquipmentSetCommand>();
        }
    }
}
