using Cmms.Domain.Dictionary;
using static Cmms.Domain.Dictionary.Dictionary;
using System;
using System.ComponentModel.DataAnnotations;
using Cmms.Filters;

namespace Cmms.Requests.QuestType
{
    public class QuestTypeUpdate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int DefaultPriority { get; set; }
    }
}
