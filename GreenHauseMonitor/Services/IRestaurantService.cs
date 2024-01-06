using Cmms.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

namespace Cmms.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto restaurantDto);
        PagedResult<RestaurantDto> GetAll(RestaurantQuery restaurantQuery);
        RestaurantDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateRestaurantDto updateRestaurant);
    }
}