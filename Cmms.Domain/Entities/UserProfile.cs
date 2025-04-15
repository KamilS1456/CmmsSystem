using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Domain.Entities
{
    public class UserProfile
    {
        public Guid UserProfileId { get; private set; }
        public string IdentityId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }

        public UserProfileBasicInfo UserProfileBasicInfo { get; private set; }


        // Factory method
        public static UserProfile CreateUserProfile(string identityId, UserProfileBasicInfo basicInfo)
        {
            return new UserProfile
            {
                IdentityId = identityId,
                UserProfileBasicInfo = basicInfo,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };
        }

        //public methods

        public void UpdateBasicInfo(UserProfileBasicInfo newInfo)
        {
            UserProfileBasicInfo = newInfo;
            LastModified = DateTime.UtcNow;
        }
    }
}
