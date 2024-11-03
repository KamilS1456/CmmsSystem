using AutoMapper;
using Cmms.Authorization;
using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Cmms.Entities.Settings;
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
    public class EquipmentSetService : IEquipmentSetService
    {
        private readonly CmmsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<EquipmentSetService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public EquipmentSetService(CmmsDbContext dbContext, IMapper mapper, ILogger<EquipmentSetService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public int Create(EquipmentSetDto equipmentSetServiceDto)
        {
            var equipmentSet = _mapper.Map<EquipmentSet>(equipmentSetServiceDto);
            equipmentSet.CreatedByUserId = _userContextService.GetUserId;
            _dbContext.EquipmentSets.Add(equipmentSet);
            _dbContext.SaveChanges();
            return equipmentSet.Id;
        }
        public List<EquipmentSetDto> GetAll()
        {
            var equipmentSetList = _dbContext.EquipmentSets.Include(i => i.EquipmentSetToEquipments);
            var equipmentSetDtoList = _mapper.Map<List<EquipmentSetDto>>(equipmentSetList);
            return equipmentSetDtoList;
        }
        public EquipmentSetDto GetById(int id)
        {
            var equipmentSets = _dbContext.EquipmentSets.Include(i => i.EquipmentSetToEquipments)
                //.Include(d => d.)
                //.Include(a => a.Address)
                .FirstOrDefault(f => f.Id == id);

            //var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, restaurant, new SettingAllowedOperation(SettingCodeName.AllowGetingRestaurantByID)).Result;
            //if (!authorizationResult.Succeeded)
            //{
            //    throw new ForbidException();
            //}

            if (equipmentSets is null)
            {
                throw new NotFoundException("EquipmentSet not found");
            }
            return _mapper.Map<EquipmentSetDto>(equipmentSets);
        }

        public void Delete(int id)
        {
            _logger.LogError($"Restaurant with id = {id} DELETE action invoked");
            ; var occurence = _dbContext.EquipmentSets.FirstOrDefault(f => f.Id == id);
            if (occurence is null)
            {
                throw new NotFoundException("EquipmentSet not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, occurence, new ResourcesOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            _dbContext.EquipmentSets.Remove(occurence);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateEquipmentSetDto equipmentSetDto)
        {
            var equipmentSet = _dbContext.EquipmentSets.FirstOrDefault(f => f.Id == id);
            if (equipmentSet is null)
            {
                throw new NotFoundException("EquipmentSet not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, equipmentSet, new ResourcesOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            //equipmentSet.,Name = updateRestaurant.Name;
            // equipmentSet.Description = updateRestaurant.Description;
            // equipmentSet.HasDelivery = updateRestaurant.HasDelivery;
            _dbContext.SaveChanges();
        }
    }
}
