using Cmms.Domain.Entities;
using Cmms.Core.Queries.QuestQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.QuestHandlers.QuestQuerieHandlers
{
    public class GetQuestByIdHandler : IRequestHandler<GetQuestByIdQuery, Quest>
    {
        //private readonly CmmsDbContext _cmmsDbContext;
        //public GetQuestByIdHandler(CmmsDbContext cmmsDbContext)
        //{
        //    _cmmsDbContext = cmmsDbContext;

        //}
        public Task<Quest> Handle(GetQuestByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return Task.FromResult(_cmmsDbContext.Quests.FirstOrDefault(f => f.Id == request.Id));
        }
    }
}

