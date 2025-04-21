using Cmms.Core.Commands.QuestCommands;
using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;
using Cmms.Domain.Entities.Quest;
using Cmms.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.QuestHandlers.QuestCommandHandlers
{
    class DeleteQuestCommandHandler : IRequestHandler<DeleteQuestCommand, OperationResult<Quest>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public DeleteQuestCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<Quest>> Handle(DeleteQuestCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Quest>();

            try
            {
                var quest = await _cmmsDbContext.Quests.FirstOrDefaultAsync(f => f.Id == request.Id);
                result.Payload = quest;
                if (quest is null)
                {
                    result.AddError(ErrorCode.NotFound, string.Format("No Quest found for ID {0}", request.Id));
                }
                else
                {
                    _cmmsDbContext.Quests.Remove(quest);
                    await _cmmsDbContext.SaveChangesAsync();
                }
            } catch (QuestNotValidException ex){
                ex.ValidationErrors.ForEach(e => result.AddError(ErrorCode.ValidationError, e));
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }

            return result;
        }
    }
}
