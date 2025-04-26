using AutoMapper;
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
        private readonly IMapper _mapper;

        OperationResult<Quest> _result = new ();

        public UpdateQuestCommandHandler(CmmsDbContext cmmsDbContext, IMapper mapper)
        {
            _cmmsDbContext = cmmsDbContext;
            _mapper = mapper;
        }

        public async Task<OperationResult<Quest>> Handle(UpdateQuestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var quest = await _cmmsDbContext.Quests.Include(i => i.QuestToEquipmentList).Include(i => i.QuestToUserList).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (quest is null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format("No Quest found for ID {0}", request.Id));
                    return _result;
                }

                quest.UpdateQuest(request.UpdateByUserID, request.Name, request.Description, request.QuestTypeId,
                    request.Priority, request.QuestState, request.DeadLineDataTime, 
                    _mapper.Map<IEnumerable<QuestToUser>>(request.QuestToUsers), _mapper.Map<IEnumerable<QuestToEquipment>>(request.QuestToEquipments));

                _cmmsDbContext.Quests.Update(quest);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);

                _result.Payload = quest;

                return _result;
            } catch (QuestNotValidException ex){
                ex.ValidationErrors.ForEach(e => _result.AddError(ErrorCode.ValidationError, e));
            } catch (Exception e){
                _result.AddUnknownError(e.Message);
            }
            return _result;
        }        
    }
}
