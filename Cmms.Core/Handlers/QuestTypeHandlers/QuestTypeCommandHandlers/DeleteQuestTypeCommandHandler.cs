using Cmms.Core.Commands.QuestTypeCommand;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities.Quest;
using Cmms.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cmms.Core.Handlers.QuestTypeHandlers.QuestTypeCommandHandlers
{
    class DeleteQuestTypeCommandHandler : IRequestHandler<DeleteQuestTypeCommand, OperationResult<QuestType>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public DeleteQuestTypeCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<QuestType>> Handle(DeleteQuestTypeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<QuestType>();

            try
            {
                var questType = await _cmmsDbContext.QuestTypes.FirstOrDefaultAsync(f => f.Id == request.Id);
                result.Payload = questType;
                if (questType is null)
                {
                    result.AddError(ErrorCode.NotFound, string.Format("No QuestType found for ID {0}", request.Id));
                }
                else
                {
                    _cmmsDbContext.QuestTypes.Remove(questType);
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
