using AutoMapper;
using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Cmms.Excepction;
using Cmms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Cmms.Services
{
    public class QuestService : IQuestService
    {
        private readonly CmmsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<QuestService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public QuestService(CmmsDbContext dbContext, IMapper mapper, ILogger<QuestService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public QuestDto GetQuestById(int id)
        {
            var quest = _dbContext.Quests.Include(i =>i.QuestToUserList).ThenInclude(t => t.User).FirstOrDefault(f => f.Id == id);
            if (quest is null)
            {
                throw new NotFoundException("Quest not found");
            }
            return _mapper.Map<QuestDto>(quest);
        }
    }
}
