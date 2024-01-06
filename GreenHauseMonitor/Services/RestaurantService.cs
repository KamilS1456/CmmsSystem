using AutoMapper;
using Cmms.Authorization;
using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Cmms.Excepction;
using Cmms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cmms.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly CmmsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public RestaurantService(CmmsDbContext dbContext, IMapper mapper, ILogger<RestaurantService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public int Create(CreateRestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            restaurant.CreatedById = _userContextService.GetUserId;
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant.Id;
        }
        public PagedResult<RestaurantDto> GetAll(RestaurantQuery query)
        {
            var restaurantList = _dbContext.Restaurants
                .Include(d => d.Dishes)
                .Include(a => a.Address)
                .Where(w => query == null || w.Name.ToLower().Contains(query.SearchPhrases.ToLower()) || w.Description.ToLower().Contains(query.SearchPhrases.ToLower()));
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Restaurant, object>>>
                {
                        { nameof(Restaurant.Name), r => r.Name},
                        { nameof(Restaurant.Description), r => r.Description},
                        { nameof(Restaurant.Category), r => r.Category},
                };

                var selectdColumn = columnsSelector[query.SortBy];
                if (query.SortDirection == SortDirection.Desc)
                {
                    restaurantList = restaurantList.OrderByDescending(selectdColumn);
                }
                else
                {
                    restaurantList = restaurantList.OrderBy(selectdColumn);
                }
            }

            var pageCutRestaurantList = restaurantList.Skip(query.PageSize * (query.PageNumber - 1)).Take(query.PageSize).ToList();
            var restaurantDtoList = _mapper.Map<List<RestaurantDto>>(pageCutRestaurantList);
            var result = new PagedResult<RestaurantDto>(restaurantDtoList, restaurantList.Count(), query.PageSize, query.PageNumber);
            return result;
        }
        public RestaurantDto GetById(int id)
        {
            var restaurant = _dbContext.Restaurants
                .Include(d => d.Dishes)
                .Include(a => a.Address)
                .FirstOrDefault(f => f.Id == id);
            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            return _mapper.Map<RestaurantDto>(restaurant);
        }

        public void Delete(int id)
        {
            _logger.LogError($"Restaurant with id = {id} DELETE action invoked");
            ; var restaurant = _dbContext.Restaurants.FirstOrDefault(f => f.Id == id);
            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, restaurant, new ResourcesOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            _dbContext.Restaurants.Remove(restaurant);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateRestaurantDto updateRestaurant)
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(f => f.Id == id);
            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, restaurant, new ResourcesOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            restaurant.Name = updateRestaurant.Name;
            restaurant.Description = updateRestaurant.Description;
            restaurant.HasDelivery = updateRestaurant.HasDelivery;
            _dbContext.SaveChanges();
        }
    }
}
