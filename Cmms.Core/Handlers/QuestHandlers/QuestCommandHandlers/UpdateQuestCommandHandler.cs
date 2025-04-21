using Cmms.Core.Commands.QuestCommands;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities.Quest;
using Cmms.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cmms.Core.Handlers.QuestHandlers.QuestCommandHandlers
{
    public class UpdateQuestCommandHandler : IRequestHandler<UpdateQuestCommand, OperationResult<Quest>>
    {
        private readonly CmmsDbContext _cmmsDbContext; 

        public UpdateQuestCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }

        public async Task<OperationResult<Quest>> Handle(UpdateQuestCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Quest>();

            try
            {
                var quest = await _cmmsDbContext.Quests.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (quest is null)
                {
                    result.AddError(ErrorCode.NotFound, string.Format("No Quest found for ID {0}", request.Id));
                    return result;
                }

                quest.UpdateQuest(Guid.NewGuid(), request.Name, request.Description, request.QuestTypeId,
                    request.Priority, request.QuestState, request.DeadLineDataTime, null, null);

                _cmmsDbContext.Quests.Update(quest);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);

                result.Payload = quest;

                return result;
            } catch (QuestNotValidException ex){
                ex.ValidationErrors.ForEach(e => result.AddError(ErrorCode.ValidationError, e));
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
