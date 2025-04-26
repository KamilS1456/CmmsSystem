using static Cmms.Domain.Dictionary.UserInQuestResponsabilityEnum;

namespace Cmms.DtoModels
{
    public class QuestToUserDto
    {
        public Guid UserId { get; set; }
        public UserInQuestResponsability UserInQuestResponsability { get; set; }
    }
}
