using AutoMapper;
using Cmms.Excepction;
using Cmms.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities.Quest;

namespace Cmms.Services
{
    public class QuestService
    {
        //private readonly CmmsDbContext _dbContext;
        //private readonly IMapper _mapper;
        //private readonly ILogger<QuestService> _logger;
        //private readonly IAuthorizationService _authorizationService;
        //private readonly IUserContextService _userContextService;
        //public QuestService(CmmsDbContext dbContext, IMapper mapper, ILogger<QuestService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        //{
        //    _dbContext = dbContext;
        //    _mapper = mapper;
        //    _logger = logger;
        //    _authorizationService = authorizationService;
        //    _userContextService = userContextService;
        //}
        //[Authorize(Roles = "Admin,Menager,User")]
        //public QuestDto GetById(int id)
        //{
        //    var quest = _dbContext.Quests.Include(i =>i.QuestToUserList).FirstOrDefault(f => f.Id == id);
        //    if (quest is null)
        //    {
        //        throw new NotFoundException("Quest not found");
        //    }
        //    return _mapper.Map<QuestDto>(quest);
        //}

        //public List<QuestDto> GetAll()
        //{
        //    var questList = _dbContext.Quests.Include(i => i.QuestToUserList);

        //    return _mapper.Map<List<QuestDto>>(questList);
        //}

        //public int Create(QuestDto questDto)
        //{
        //    var quest = _mapper.Map<Quest>(questDto);
        //    quest.CreatedByUserId = _userContextService.GetUserId;
        //    _dbContext.Quests.Add(quest);
        //    //foreach (var questToUsersDto in questDto.AssignedUsers)
        //    //{
        //    //    var questTouser = _mapper.Map<QuestToUser>(questToUsersDto);
        //    //    questTouser.QuestId = quest.Id;
        //    //    _dbContext.QuestToUsers.Add(questTouser);

        //    //}
        //    foreach (var questToEquipmentDto in questDto.TargetedEquipments)
        //    {
        //        var questToEquipment = _mapper.Map<QuestToEquipment>(questToEquipmentDto);
        //        questToEquipment.QuestId = quest.Id;
        //        _dbContext.QuestToEquipments.Add(questToEquipment);
        //    }
        //    _dbContext.SaveChanges();
        //    return quest.Id;
        //}

        //public void Delete(int id)
        //{
        //    //_logger.LogError($"Quest with id = {id} DELETE action invoked");
        //    ; var quest = _dbContext.Quests.FirstOrDefault(f => f.Id == id);
        //    if (quest is null)
        //    {
        //        throw new NotFoundException("Restaurant not found");
        //    }
        //    var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, quest, new ResourcesOperationRequirement(ResourceOperation.Delete)).Result;
        //    if (!authorizationResult.Succeeded)
        //    {
        //        throw new ForbidException();
        //    }
        //    _dbContext.Quests.Remove(quest);
        //    _dbContext.SaveChanges();
        //}

        //public void Update(int id, QuestDto updateRestaurant)
        //{
        //    var quest = _dbContext.Quests.FirstOrDefault(f => f.Id == id);
        //    if (quest is null)
        //    {
        //        throw new NotFoundException("Restaurant not found");
        //    }
        //    var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, quest, new ResourcesOperationRequirement(ResourceOperation.Update)).Result;
        //    if (!authorizationResult.Succeeded)
        //    {
        //        throw new ForbidException();
        //    }

        //    _dbContext.SaveChanges();
        //}
    }
}
