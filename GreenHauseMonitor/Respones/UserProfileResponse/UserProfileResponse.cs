using System;

namespace Cmms.Respones.UserProfileResponse
{
    public record UserProfileResponse
    {
        public Guid UserProfileId { get; set; }
        public UserProfileBasicInfoResponse? UserProfileBasicInfo { get; set; }
    }
}
