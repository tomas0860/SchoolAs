using System;
using System.Collections.Generic;

namespace SchoolAs.Util.MessageExchange
{
    public class Response<T> : GenericResponse
    {
        #region ATTRIBUTES

        // Object to retrieve.
        public T Item { get; set; }

        #endregion ATTRIBUTES


        public Response() : base()
        {
        }

        public Response(T item) : base()
        {
            this.Item = item;
        }


        protected override void Init()
        {
        }
    }
}
