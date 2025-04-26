using MediatR;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using Cmms.Core.Commands.QuestTypeCommand;

namespace Cmms.Core.Handlers.QuestTypeHandlers.QuestTypeCommandHandlers
{
    public class CreateQuestTypeCommandHandler : IRequestHandler<CreateQuestTypeCommand, OperationResult<QuestType>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public CreateQuestTypeCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<QuestType>> Handle(CreateQuestTypeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<QuestType>();

            try
            {
                var questType = QuestType.CreateQuestType(request.CreatedByUserID, request.Name, request.DefaultPriority);

                _cmmsDbContext.QuestTypes.Add(questType);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);
                result.Payload = questType;
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }

            return result;

        }
    }
}
