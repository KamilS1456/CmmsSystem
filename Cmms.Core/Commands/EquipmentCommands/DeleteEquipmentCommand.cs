using Cmms.Core.Models;
using Cmms.Domain.Entities;
using Cmms.Domain.Entities.Equipments;
using Cmms.Domain.Entities.Quest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Commands.EquipmentCommands
{
    public class DeleteEquipmentCommand : IRequest<OperationResult<Equipment>>
    {
        public Guid Id { get; set; }

        public Guid DeletingByUserID { get; set; }
    }
}
