using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Enums
{
    public enum ErrorCode
    {

        ValidationError = 101,

        NotFound = 404,
        ServerError = 500,

        IdentityUserAlreadyExists = 201,
        IdentityCreationFailed = 202,

        IdentityUserDoesNotExist = 304,
        IncorrectPassword = 305,
        UserNotPermitedForAction = 306,

        UnknownError = 999

    }
}
