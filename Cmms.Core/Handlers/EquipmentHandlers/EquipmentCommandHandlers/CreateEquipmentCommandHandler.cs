using Cmms.Core.Commands.UserProfileCommands;
using MediatR;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using Cmms.Core.Commands.EquipmentCommands;

namespace Cmms.Core.Handlers.EquipmentHandlers.EquipmentCommandHandlers
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, OperationResult<Equipment>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public CreateEquipmentCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<Equipment>> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Equipment>();
            try
            {
                var equipment = Equipment.CreateEquipment(request.CreatedByUserID, request.Name, request.SN, request.Model,
                    request.Condition, request.LastServiceDateTime);

                _cmmsDbContext.Equipments.Add(equipment);

                await _cmmsDbContext.SaveChangesAsync(cancellationToken);
                result.Payload = equipment;
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }

            return result;

        }
    }
}
