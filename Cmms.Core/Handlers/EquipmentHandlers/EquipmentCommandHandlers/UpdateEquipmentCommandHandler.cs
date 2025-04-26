using Cmms.Core.Commands.EquipmentCommands;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities.Equipments;
using Cmms.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cmms.Core.Handlers.EquipmentHandlers.EquipmentCommandHandlers
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, OperationResult<Equipment>>
    {
        private readonly CmmsDbContext _cmmsDbContext; 

        OperationResult<Equipment> _result = new ();

        public UpdateEquipmentCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }

        public async Task<OperationResult<Equipment>> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var equipment = await _cmmsDbContext.Equipments.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (equipment is null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format("No Equipment found for ID {0}", request.Id));
                    return _result;
                }

                equipment.UpdateEquipment(request.UpdateByUserID, request.Name, request.SN, request.Model, request.Condition, request.LastServiceDateTime);

                _cmmsDbContext.Equipments.Update(equipment);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);

                _result.Payload = equipment;

                return _result;
            } catch (EquipmentNotValidException ex){
                ex.ValidationErrors.ForEach(e => _result.AddError(ErrorCode.ValidationError, e));
            } catch (Exception e){
                _result.AddUnknownError(e.Message);
            }
            return _result;
        }        
    }
}
