using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolAs.Util.MessageExchange
{
    public abstract class GenericResponse
    {
        #region Attributes

        // Final operation status
        public OperationCode.ResponseCode Code { get; set; }

        // Messages to share.
        public List<string> MessageList { get; set; }
        // Error reported
        public List<string> ErrorList { get; set; }
        // Not found message reported
        public List<string> NotFoundList { get; set; }
        // Exception Message reported in the process.
        public List<string> ExceptionMessageList { get; set; }
        // Exception reported in the process.
        public List<Exception> ExceptionList { get; set; }

        #endregion Attibutes



        public GenericResponse()
        {
            MessageList = new List<string>();
            ErrorList = new List<string>();
            NotFoundList = new List<string>();
            ExceptionMessageList = new List<string>();
            ExceptionList = new List<Exception>();

            // Init addicional components
            Init();
        }


        /// <summary>
        /// Custom initializer method
        /// </summary>
        protected abstract void Init();
    }
}
