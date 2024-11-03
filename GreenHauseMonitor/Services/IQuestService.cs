using Cmms.Entities;
using Cmms.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cmms.Services
{
    public interface IQuestService
    {
        public QuestDto GetById([FromRoute] int id);
        public List<QuestDto> GetAll();
        void Delete(int id);
        void Update(int id, QuestDto questDto);
    }
}
