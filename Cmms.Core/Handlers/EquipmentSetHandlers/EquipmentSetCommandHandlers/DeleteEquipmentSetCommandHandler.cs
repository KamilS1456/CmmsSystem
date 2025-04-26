using Cmms.Core.Commands.EquipmentCommands;
using Cmms.Core.Commands.EquipmentSetCommands;
using Cmms.Core.Commands.QuestCommands;
using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities.Equipments;
using Cmms.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Cmms.Core.Handlers.EquipmentHandlers.EquipmentCommandHandlers
{
    class DeleteEquipmentSetCommandHandler : IRequestHandler<DeleteEquipmentSetCommand, OperationResult<EquipmentSet>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public DeleteEquipmentSetCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<EquipmentSet>> Handle(DeleteEquipmentSetCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<EquipmentSet>();

            try
            {
                var equipmentSet = await _cmmsDbContext.EquipmentSets.FirstOrDefaultAsync(f => f.Id == request.Id);
                result.Payload = equipmentSet;
                if (equipmentSet is null)
                {
                    result.AddError(ErrorCode.NotFound, string.Format("No EquipmentSet found for ID {0}", request.Id));
                }
                else
                {
                    _cmmsDbContext.EquipmentSets.Remove(equipmentSet);
                    await _cmmsDbContext.SaveChangesAsync();
                }
            } catch (EquipmentNotValidException ex){
                ex.ValidationErrors.ForEach(e => result.AddError(ErrorCode.ValidationError, e));
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }

            return result;
        }
    }
}
