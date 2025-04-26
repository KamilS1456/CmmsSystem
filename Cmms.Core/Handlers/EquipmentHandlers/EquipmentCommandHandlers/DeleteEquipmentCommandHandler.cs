using Cmms.Core.Commands.EquipmentCommands;
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
    class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand, OperationResult<Equipment>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public DeleteEquipmentCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<Equipment>> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Equipment>();

            try
            {
                var equipment = await _cmmsDbContext.Equipments.FirstOrDefaultAsync(f => f.Id == request.Id);
                result.Payload = equipment;
                if (equipment is null)
                {
                    result.AddError(ErrorCode.NotFound, string.Format("No Equipment found for ID {0}", request.Id));
                }
                else
                {
                    _cmmsDbContext.Equipments.Remove(equipment);
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
