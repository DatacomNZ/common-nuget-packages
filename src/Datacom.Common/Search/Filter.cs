using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.Common.Search
{
    /// <summary>
    /// Base filter object used for filter searches
    /// </summary>
    public class Filter
    {
        public Filter()
        {
            Take = 100;
            Page = 1;
            OrderBy = new FilterSort();
        }

        public FilterSort OrderBy { get; set; }
        public int Take { get; set; }
        public int Page { get; set; }
        public int Skip
        {
            get
            {
                return Take * (Page - 1);
            }
        }
    }
}
