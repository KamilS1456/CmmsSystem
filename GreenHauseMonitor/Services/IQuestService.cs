using Cmms.Entities;
using Cmms.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cmms.Services
{
    public interface IQuestService
    {
        public QuestDto GetQuestById([FromRoute] int id);
    }
}
