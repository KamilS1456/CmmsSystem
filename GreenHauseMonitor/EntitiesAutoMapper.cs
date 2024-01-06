using AutoMapper;
using Cmms.Entities;
using Cmms.Models;
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

        }

    }
}
