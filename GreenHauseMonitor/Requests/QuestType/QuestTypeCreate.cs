using System.ComponentModel.DataAnnotations;

namespace Cmms.Requests.QuestType
{
    public class QuestTypeCreate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int DefaultPriority { get; set; }

    }
}
