using System;
using System.Collections.Generic;

namespace SchoolAs.Util.MessageExchange
{
    public static class OperationCode
    {
        public enum ResponseCode { SUCCESS = 0, PARTIAL = 1, NO_FOUND = 2, ERROR = 3, EXCEPTION = 4 };
    }
}
