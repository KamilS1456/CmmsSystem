using AutoMapper;
using Cmms.Excepction;
using Cmms.Core.Models;
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
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;

namespace Cmms.Services
{
    public class EquipmentService //: IEquipmentService
    {
        //private readonly CmmsDbContext _dbContext;
        //private readonly IMapper _mapper;
        //private readonly ILogger<EquipmentService> _logger;
        //private readonly IAuthorizationService _authorizationService;
        //private readonly IUserContextService _userContextService;
        //public EquipmentService(CmmsDbContext dbContext, IMapper mapper, ILogger<EquipmentService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        //{
        //    _dbContext = dbContext;
        //    _mapper = mapper;
        //    _logger = logger;
        //    _authorizationService = authorizationService;
        //    _userContextService = userContextService;
        //}

        //public int Create(EquipmentDto equipmentServiceDto)
        //{
        //    //var equipment = _mapper.Map<Equipment>(equipmentServiceDto);
        //    //equipment.CreatedByUserId = _userContextService.GetUserId;
        //    //_dbContext.Equipments.Add(equipment);
        //    //_dbContext.SaveChanges();
        //    //return equipment.Id;
        //    return 0;
        //}
        //public List<EquipmentDto> GetAll()
        //{
        //    var equipmentList = _dbContext.Equipments;
        //    var equipmentDtoList = _mapper.Map<List<EquipmentDto>>(equipmentList);

        //    return equipmentDtoList;
        //}
        //public EquipmentDto GetById(int id)
        //{
        //    var equipments = _dbContext.Equipments.First();

        //    if (equipments is null)
        //    {
        //        throw new NotFoundException("Equipment not found");
        //    }
        //    return _mapper.Map<EquipmentDto>(equipments);
        //}

        //public void Delete(int id)
        //{
        //    _logger.LogError($"Restaurant with id = {id} DELETE action invoked");
        //    ; var occurence = _dbContext.Equipments.First();
        //    if (occurence is null)
        //    {
        //        throw new NotFoundException("Equipment not found");
        //    }
        //    var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, occurence, new ResourcesOperationRequirement(ResourceOperation.Delete)).Result;
        //    if (!authorizationResult.Succeeded)
        //    {
        //        throw new ForbidException();
        //    }
        //    _dbContext.Equipments.Remove(occurence);
        //    _dbContext.SaveChanges();
        //}

        //public void Update(int id, UpdateEquipmentDto equipmentDto)
        //{
        //    var equipment = _dbContext.Equipments.First();
        //    if (equipment is null)
        //    {
        //        throw new NotFoundException("Equipment not found");
        //    }
        //    var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, equipment, new ResourcesOperationRequirement(ResourceOperation.Update)).Result;
        //    if (!authorizationResult.Succeeded)
        //    {
        //        throw new ForbidException();
        //    }
        //    //equipment.,Name = updateRestaurant.Name;
        //    // equipment.Description = updateRestaurant.Description;
        //    // equipment.HasDelivery = updateRestaurant.HasDelivery;
        //    _dbContext.SaveChanges();
        //}
    }
}
