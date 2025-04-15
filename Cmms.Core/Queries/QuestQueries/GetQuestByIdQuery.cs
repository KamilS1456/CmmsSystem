using Cmms.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Queries.QuestQueries
{
    public record GetQuestByIdQuery(int Id) : IRequest<Quest> ;

}
