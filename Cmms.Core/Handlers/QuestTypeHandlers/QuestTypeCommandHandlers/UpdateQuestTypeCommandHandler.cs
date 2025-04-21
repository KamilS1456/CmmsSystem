using Cmms.Core.Commands.QuestTypeCommand;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;
using Cmms.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cmms.Core.Handlers.QuestTypeHandlers.QuestTypeCommandHandlers
{
    public class UpdateQuestTypeCommandHandler : IRequestHandler<UpdateQuestTypeCommand, OperationResult<QuestType>>
    {
        private readonly CmmsDbContext _cmmsDbContext; 

        public UpdateQuestTypeCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }

        public async Task<OperationResult<QuestType>> Handle(UpdateQuestTypeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<QuestType>();

            try
            {
                var questType = await _cmmsDbContext.QuestTypes.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (questType is null)
                {
                    result.AddError(ErrorCode.NotFound, string.Format("No QuestType found for ID {0}", request.Id));
                    return result;
                }

                questType.UpdateQuestType(request.Name, request.DefaultPriority);

                _cmmsDbContext.QuestTypes.Update(questType);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);

                result.Payload = questType;

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
