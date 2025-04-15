using AutoMapper;
using Cmms.Authorization;
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
    public class OccurrenceService : IOccurrenceService
    {
        private readonly CmmsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<OccurrenceService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public OccurrenceService(CmmsDbContext dbContext, IMapper mapper, ILogger<OccurrenceService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public int Create(OccurrenceDto occurrenceServiceDto)
        {
            var occurrence = _mapper.Map<Occurrence>(occurrenceServiceDto);
            occurrence.CreatedByUserId = _userContextService.GetUserId;
            _dbContext.Occurrences.Add(occurrence);
            _dbContext.SaveChanges();
            return occurrence.Id;
        }
        public List<OccurrenceDto> GetAll()
        {
            var occurrenceList = _dbContext.Occurrences;            
            var occurrenceDtoList = _mapper.Map<List<OccurrenceDto>>(occurrenceList);
            return occurrenceDtoList;
        }
        public OccurrenceDto GetById(int id)
        {
            var occurrences = _dbContext.Occurrences
                //.Include(d => d.)
                //.Include(a => a.Address)
                .FirstOrDefault(f => f.Id == id);

            //var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, restaurant, new SettingAllowedOperation(SettingCodeName.AllowGetingRestaurantByID)).Result;
            //if (!authorizationResult.Succeeded)
            //{
            //    throw new ForbidException();
            //}

            if (occurrences is null)
            {
                throw new NotFoundException("Occurrence not found");
            }
            return _mapper.Map<OccurrenceDto>(occurrences);
        }

        public void Delete(int id)
        {
            _logger.LogError($"Restaurant with id = {id} DELETE action invoked");
            ; var occurence = _dbContext.Occurrences.FirstOrDefault(f => f.Id == id);
            if (occurence is null)
            {
                throw new NotFoundException("Occurrence not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, occurence, new ResourcesOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            _dbContext.Occurrences.Remove(occurence);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateOccurrenceDto occurrenceDto)
        {
            var occurrence = _dbContext.Occurrences.FirstOrDefault(f => f.Id == id);
            if (occurrence is null)
            {
                throw new NotFoundException("Occurrence not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, occurrence, new ResourcesOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            //occurrence.,Name = updateRestaurant.Name;
           // occurrence.Description = updateRestaurant.Description;
           // occurrence.HasDelivery = updateRestaurant.HasDelivery;
            _dbContext.SaveChanges();
        }
    }
}
