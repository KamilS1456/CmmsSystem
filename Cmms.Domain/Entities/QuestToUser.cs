using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Domain.Entities
{
    public class QuestToUser
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int UserId { get; set; }
        public UserInQuestResponsability userInQuestResponsability { get; set; } = UserInQuestResponsability.Observer;

        public virtual Quest Quest { get; set; }
        //public virtual User User { get; set; }
    }
}
