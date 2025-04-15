using System;

namespace Cmms.Core.Respones.UserProfileResponse
{
    public record UserProfileResponse
    {
        public Guid UserProfileId { get; set; }
        public UserProfileBasicInfoResponse? UserProfileBasicInfo { get; set; }
    }
}
