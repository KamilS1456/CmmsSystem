using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Domain.Entities.Quest
{
    public class QuestToUser
    {
        public Guid Id { get; private set; }
        public Guid QuestId { get; private set; }
        public Guid UserId { get; private set; }
        public UserInQuestResponsability userInQuestResponsability { get; private set; } = UserInQuestResponsability.Observer;

    }
}
