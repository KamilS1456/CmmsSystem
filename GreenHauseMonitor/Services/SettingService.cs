using Cmms.Authorization;
using Cmms.Entities.Settings;
using Cmms.Entities;
using Cmms.Excepction;
using Cmms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Cmms.EntitieDbCOntext;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Cmms.Services
{
    public class SettingService : ISettingService
    {
        private readonly CmmsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<SettingService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public SettingService(CmmsDbContext dbContext, IMapper mapper, ILogger<SettingService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }


        public IEnumerable<SettingDto> GetAll()
        {
            var settingList = _dbContext.Settings.Include(i => i.SettingValueBoolList);

            var settingDtoList = _mapper.Map<List<SettingDto>>(settingList);
            return settingDtoList;
        }
        public SettingDto GetSettingById(int id)
        {
            var setting = _dbContext.Settings.Include(i => i.SettingValueBoolList).FirstOrDefault(f => f.Id == id);
            if (setting is null)
            {
                throw new NotFoundException("Setting not found");
            }
            return _mapper.Map<SettingDto>(setting);
        }
        public SettingValueBoolDto GetSettingBoolById(int id)
        {
            var setting = _dbContext.SettingValueBools.FirstOrDefault(f => f.Id == id);
            if (setting is null)
            {
                throw new NotFoundException("Setting not found");
            }
            return _mapper.Map<SettingValueBoolDto>(setting);
        }
    }
}
