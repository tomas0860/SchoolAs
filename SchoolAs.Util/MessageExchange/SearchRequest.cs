using System;
using System.Collections.Generic;

namespace SchoolAs.Util.MessageExchange
{
    public class SearchRequest<T> : GenericRequest
    {
        #region Attributes
        
        // Minimun to take with the pagination.
        private const int DEFAULT_TAKE = -1;
        public int page;
        public int take;
        // Search criteria object.
        public T Criteria { get; set; }

        public int Page { get { return this.page; } set { this.page = (value < 0 ? 0 : value); } }
        public int Take { get { return this.take; } set { this.take = (value < 1 ? DEFAULT_TAKE : value); } }

        // true => count all elements involved in this request.
        public bool CountTotal { get; set; }

        #endregion Attributes


        public SearchRequest()
        {
            Init();
        }

        public SearchRequest(T criteria)
        {
            this.Criteria = criteria;
            Init();
        }

        private void Init()
        {
            Page = 0;
            Take = 0;
            CountTotal = false;
        }
    }
}
