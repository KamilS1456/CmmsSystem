using Cmms.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Models
{
    public class OperationResult<T>
    {
        public T Payload { get; set; }
        public bool IsError { get { return ErrorList.Any(); } }
        public List<Error> ErrorList { get; set; } = new ();

        /// <summary>
        /// Adds an error to the Error list and sets the IsError flag to true
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public void AddError(ErrorCode code, string message)
        {
            HandleError(code, message);
        }

        /// <summary>
        /// Adds a default error to the Error list with the error code UnknownError
        /// </summary>
        /// <param name="message"></param>
        public void AddUnknownError(string message)
        {
            HandleError(ErrorCode.UnknownError, message);
        }


        #region Private methods

        private void HandleError(ErrorCode code, string message)
        {
            ErrorList.Add(new Error { Code = code, Message = message });
        }

        #endregion
    }
}
