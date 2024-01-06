using System;

namespace Cmms.Excepction
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            :base(message)
        {
        
        }

    }
}
