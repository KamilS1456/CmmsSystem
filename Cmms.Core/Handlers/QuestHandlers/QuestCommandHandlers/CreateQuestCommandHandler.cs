using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Domain.Entities;
using MediatR;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using Cmms.Core.Commands.QuestCommands;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace Cmms.Core.Handlers.QuestHandlers.QuestCommandHandlers
{
    public class CreateQuestCommandHandler : IRequestHandler<CreateQuestCommand, OperationResult<Quest>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        private readonly IMapper _mapper;
        public CreateQuestCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<Quest>> Handle(CreateQuestCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Quest>();
            try
            {
                var quest = Quest.CreateQuest(request.CreatedByUserID, request.Name, request.Description, request.QuestTypeId,
                    request.Priority, request.QuestState, request.DeadLineDataTime, 
                    _mapper.Map<IEnumerable<QuestToUser>>(request.QuestToUsers), _mapper.Map<IEnumerable<QuestToEquipment>>(request.QuestToEquipments));

                _cmmsDbContext.Quests.Add(quest);
                if (request.QuestToUsers is not null)
                {
                    foreach (var questToUser in request.QuestToUsers)
                    {
                        var newQuestToUser = QuestToUser.CreateQuestToUser(quest.Id, questToUser.UserId, questToUser.UserInQuestResponsability);
                        quest.QuestToUserList.Add(newQuestToUser);
                    }
                }

                if (request.QuestToEquipments is not null)
                {
                    foreach (var questToEquipment in request.QuestToEquipments)
                    {
                        var newQuestToEquipment = QuestToEquipment.CreateQuestToEquipment(quest.Id, questToEquipment.EquipmentId);
                        quest.QuestToEquipmentList.Add(newQuestToEquipment);
                    }
                }
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);
                result.Payload = quest;
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }

            return result;

        }
    }
}
