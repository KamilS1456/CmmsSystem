
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Core.Models
{
    public class QuestToUserDto
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int UserId { get; set; }
        public UserInQuestResponsability userInQuestResponsability { get; set; } = UserInQuestResponsability.Observer;
    }
}
