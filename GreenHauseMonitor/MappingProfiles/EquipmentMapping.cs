using AutoMapper;
using Cmms.Requests.Equipment;
using Cmms.Core.Commands.EquipmentCommands;
using Cmms.Respones.EquipmentResponse;
using Cmms.Domain.Entities.Equipments;

namespace Cmms.MappingProfiles
{
    public class EquipmentMapping : Profile
    {
        public EquipmentMapping()
        {
            CreateMap<EquipmentCreate, CreateEquipmentCommand>();
            CreateMap<Equipment, EquipmentResponse>();
            CreateMap<EquipmentUpdate, UpdateEquipmentCommand>();
        }
    }
}
