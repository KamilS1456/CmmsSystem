using Cmms.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Core.Commands.QuestCommands
{
    public record InsertQuestCommand
        (string Name, string Description, DateTime DeadLineDataTime, int Priority, QuestState QuestState, 
        int QuestTypeId, List<QuestToUser> QuestToUsers, List<QuestToEquipment> QuestToEquipmentList)
        : IRequest<Quest>;
}
