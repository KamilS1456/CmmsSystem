using Cmms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.Services
{
    public interface IDishService
    {
        public int Create(int restaurantId, CreateDishDto createDishDto);
        public DishDto GetById(int restaurantid, int dishId);
        public IEnumerable<DishDto> GetAll(int restaurantid);
        public void DeleteAll(int restaurantid);
        public void DeleteById(int restaurantid, int dishId);
    }
}
