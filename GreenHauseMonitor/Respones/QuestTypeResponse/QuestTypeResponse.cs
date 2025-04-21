using Cmms.Respones.UserProfileResponse;
using System;

namespace Cmms.Respones.QuestTypeResponse
{
    public record QuestTypeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DefaultPriority { get; set; }
    }
}
