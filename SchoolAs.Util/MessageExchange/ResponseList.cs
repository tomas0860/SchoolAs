using System;
using System.Collections.Generic;

namespace SchoolAs.Util.MessageExchange
{
    public class ResponseList<T> : GenericResponse
    {
        #region Attributes

        // Count is the total of record available.
        public int Count { get; set; }
        // Total items is the elements taken from the count.
        public int TotalItems { get; set; }

        //List of elements to retrieve.
        public List<T> Items { get; set; }

        #endregion Attributes


        public ResponseList() : base()
        {
            Items = new List<T>();
        }

        public ResponseList(List<T> items) : base()
        {
            this.Items = items;
        }


        protected override void Init()
        {
            Count = 0;
            TotalItems = 0;
        }
    }
}
