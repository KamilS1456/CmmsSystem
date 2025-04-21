using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Domain.Entities;
using MediatR;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using Cmms.Core.Commands.QuestCommands;

namespace Cmms.Core.Handlers.QuestHandlers.QuestCommandHandlers
{
    public class CreateQuestCommandHandler : IRequestHandler<CreateQuestCommand, OperationResult<Quest>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public CreateQuestCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<Quest>> Handle(CreateQuestCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Quest>();

            try
            {
                var quest = Quest.CreateQuest(Guid.NewGuid(), request.Name, request.Description, request.QuestTypeId,
                    request.Priority, request.QuestState, request.DeadLineDataTime,null,null);

                _cmmsDbContext.Quests.Add(quest);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);
                result.Payload = quest;
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }

            return result;

        }
    }
}
