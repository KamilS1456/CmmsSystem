using AutoMapper;
using Cmms.Entities;
using Cmms.Entities.Settings;
using Cmms.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms
{
    public class EntitiesAutoMapper : Profile
    {
        public EntitiesAutoMapper()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>();
            CreateMap<Dish, CreateDishDto>();
            CreateMap<Dish, CreateDishDto>().ReverseMap();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(m => m.Address, c => c.MapFrom(dto => new Address()
                { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));

            CreateMap<SettingValueBool, SettingValueBoolDto>().ReverseMap();
            CreateMap<SettingValueIntDto, SettingValueInt>().ReverseMap();
            CreateMap<Setting, SettingDto>().ReverseMap();

            CreateMap<Quest, QuestDto>().ReverseMap();

            CreateMap<EquipmentSet, EquipmentSetDto>();//.ForMember(s => s.EquipmentSetToEquipments, c => c.MapFrom(m => m.EquipmentSetToEquipments));
            CreateMap<EquipmentSetToEquipment, EquipmentSetToEquipmentDto>();
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<Equipment, EquipmentDto>().ReverseMap();
            CreateMap<EquipmentToEquipment, EquipmentToEquipmentDto>();

            CreateMap<Occurrence, OccurrenceDto>();

        }

    }
}
