using AutoMapper;
using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Cmms.Excepction;
using Cmms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.Services
{
    public class DishService : IDishService
    {
        private readonly CmmsDbContext _dbContext;
        private readonly IMapper _mapper;
        public DishService(CmmsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(int restaurantId, CreateDishDto createDishDto)
        {
            var restaurant = GetRestaurantByID(restaurantId);
            createDishDto.RestaurantId = restaurantId;
            var dish = _mapper.Map<Dish>(createDishDto);

            _dbContext.Dishes.Add(dish);
            _dbContext.SaveChanges();

            return dish.Id;
        }

        public DishDto GetById(int restaurantid, int dishId)
        {
            var restaurant = GetRestaurantByID(restaurantid);

            var dish = _dbContext.Dishes.FirstOrDefault(f => f.Id == dishId && f.RestaurantId == restaurantid);
            if (dish == null)
            {
                throw new NotFoundException("Dish not found");
            }

            var dishDto = _mapper.Map<DishDto>(dish);
            return dishDto;
        }

        public IEnumerable<DishDto> GetAll(int restaurantid)
        {
            var restaurant = GetRestaurantByID(restaurantid);
            // var dishList = _dbContext.Dishes.Where(f =>f.RestaurantId == restaurantid); moje

            var dishDtoList = _mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
            return dishDtoList;
        }

        public void DeleteAll(int restaurantid)
        {
            var restaurant = GetRestaurantByID(restaurantid);
            _dbContext.Dishes.RemoveRange(restaurant.Dishes);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int restaurantid, int dishId)
        {
            var restaurant = GetRestaurantByID(restaurantid);
            var dish = _dbContext.Dishes.FirstOrDefault(f => f.Id == dishId && f.RestaurantId == restaurantid);
            if (dish == null)
            {
                throw new NotFoundException("Dish not found");
            }

            _dbContext.Dishes.Remove(dish);
            _dbContext.SaveChanges();
        }

        private Restaurant GetRestaurantByID(int restaurantId)
        {
            var restaurant = _dbContext.Restaurants
                .Include(i => i.Dishes)
                .FirstOrDefault(f => f.Id == restaurantId);

            if (restaurant == null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            return restaurant;
        }
    }
}
