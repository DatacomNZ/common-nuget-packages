using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.Common.Search
{
    public class FilterSort
    {
        /// <summary>
        /// Full order string i.e. "PropertyName asc"
        /// </summary>
        public string SortOrder { get; set; }

        public string Property
        {
            get
            {
                if (!string.IsNullOrEmpty(SortOrder))
                {
                    var e = SortOrder.Split(' ');
                    return e.FirstOrDefault();
                }
                return string.Empty;
            }
        }

        public bool IsDescending
        {
            get
            {
                if (!string.IsNullOrEmpty(SortOrder))
                {
                    var e = SortOrder.Split(' ');
                    return e.LastOrDefault() == "desc";
                }
                return false;
            }
        }
    }
}
