//using Cmms.Core.EntitieDbCOntext;
using Cmms.Domain.Entities;
using Cmms.Queries.QuestQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.QuestHandlers.QuestQuerieHandlers
{
    public class GetQuestListHandler : IRequestHandler<GetQuestListQuery, List<Quest>>
    {
        //private readonly CmmsDbContext _cmmsDbContext;
        //public GetQuestListHandler(CmmsDbContext cmmsDbContext)
        //{
        //    _cmmsDbContext = cmmsDbContext;

        //}
        public Task<List<Quest>> Handle(GetQuestListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return Task.FromResult(_cmmsDbContext.Quests.ToList());
        }
    }
}
