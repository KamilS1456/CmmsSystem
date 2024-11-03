using static Cmms.Dictionary.Dictionary;

namespace Cmms.Models
{
    public class QuestToUserDto
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int UserId { get; set; }
        public UserInQuestResponsability userInQuestResponsability { get; set; } = UserInQuestResponsability.Observer;
    }
}
