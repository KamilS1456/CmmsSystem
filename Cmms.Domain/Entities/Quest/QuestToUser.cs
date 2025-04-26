
using static Cmms.Domain.Dictionary.UserInQuestResponsabilityEnum;

namespace Cmms.Domain.Entities.Quest
{
    public class QuestToUser
    {
        public Guid Id { get; private set; }
        public Guid QuestId { get; private set; }
        public Guid UserId { get; private set; }
        public UserInQuestResponsability UserInQuestResponsability { get; private set; } = UserInQuestResponsability.Observer;



        public static QuestToUser CreateQuestToUser(Guid questId, Guid userId, UserInQuestResponsability userInQuestResponsability)
        {
            return new QuestToUser
            {
                QuestId = questId,
                UserId = userId,
                UserInQuestResponsability = userInQuestResponsability
            };
        }

        public void UpdateQuestToUser(UserInQuestResponsability userInQuestResponsability)
        {
            UserInQuestResponsability = userInQuestResponsability;
        }
    }
}

