using Cmms.Core.Models;
using Cmms.Domain.Entities;
using Cmms.Domain.Entities.Quest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Commands.QuestCommands
{
    public class DeleteQuestCommand : IRequest<OperationResult<Quest>>
    {
        public Guid Id { get; set; }
    }
}
