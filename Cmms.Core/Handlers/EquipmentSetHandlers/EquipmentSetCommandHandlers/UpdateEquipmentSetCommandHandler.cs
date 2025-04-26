using AutoMapper;
using Cmms.Core.Commands.EquipmentCommands;
using Cmms.Core.Commands.EquipmentSetCommands;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities.Equipments;
using Cmms.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cmms.Core.Handlers.EquipmentHandlers.EquipmentCommandHandlers
{
    public class UpdateEquipmentSetCommandHandler : IRequestHandler<UpdateEquipmentSetCommand, OperationResult<EquipmentSet>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        private readonly IMapper _mapper;

        OperationResult<EquipmentSet> _result = new ();

        public UpdateEquipmentSetCommandHandler(CmmsDbContext cmmsDbContext, IMapper mapper)
        {
            _cmmsDbContext = cmmsDbContext;
            _mapper = mapper;
        }

        public async Task<OperationResult<EquipmentSet>> Handle(UpdateEquipmentSetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var equipmentSet = await _cmmsDbContext.EquipmentSets.Include(i => i.EquipmentSetToEquipments).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (equipmentSet is null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format("No EquipmentSet found for ID {0}", request.Id));
                    return _result;
                }

                equipmentSet.UpdateEquipmentSet(request.UpdateByUserID, request.Name, request.Description,
                    _mapper.Map<IEnumerable<EquipmentSetToEquipment>>(request.EquipmentSetToEquipments));

                _cmmsDbContext.EquipmentSets.Update(equipmentSet);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);

                _result.Payload = equipmentSet;

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
