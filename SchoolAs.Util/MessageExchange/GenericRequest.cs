using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolAs.Util.MessageExchange
{
    public abstract class GenericRequest
    {
        #region Attributes

        // How many tries aplies with this request.
        public int Tries { get; set; }

        // Token to identify a user.
        public int Token { get; set; }

        #endregion Attributes


        public GenericRequest()
        {
            Tries = 1;
            Token = 0;
        }
    }
}
