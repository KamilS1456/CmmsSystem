using Cmms.Core.Commands.UserProfileCommands;
using MediatR;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Core.Models;
using Cmms.Domain.Entities.Equipments;
using Cmms.Core.Commands.EquipmentCommands;
using Cmms.Core.Commands.EquipmentSetCommands;
using Cmms.Domain.Entities.Quest;
using AutoMapper;

namespace Cmms.Core.Handlers.EquipmentHandlers.EquipmentCommandHandlers
{
    public class CreateEquipmentSetCommandHandler : IRequestHandler<CreateEquipmentSetCommand, OperationResult<EquipmentSet>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        private readonly IMapper _mapper;
        public CreateEquipmentSetCommandHandler(CmmsDbContext cmmsDbContext, IMapper mapper)
        {
            _cmmsDbContext = cmmsDbContext;
            _mapper = mapper;
        }
        public async Task<OperationResult<EquipmentSet>> Handle(CreateEquipmentSetCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<EquipmentSet>();
            try
            {
                var equipment = EquipmentSet.CreateEquipmentSet(request.CreatedByUserID, request.Name, request.Description, 
                    _mapper.Map<IEnumerable<EquipmentSetToEquipment>>(request.EquipmentSetToEquipments));

                _cmmsDbContext.EquipmentSets.Add(equipment);

                await _cmmsDbContext.SaveChangesAsync(cancellationToken);
                result.Payload = equipment;
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }

            return result;

        }
    }
}
