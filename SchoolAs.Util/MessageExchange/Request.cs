using System;

namespace SchoolAs.Util.MessageExchange
{
    public class Request<T> : GenericRequest
    {
        #region Attributes

        // Object to share.
        public T Item { get; set; }

        #endregion Attributes


        public Request()
        {
        }

        public Request(T item)
        {
            this.Item = item;
        }
    }
}
