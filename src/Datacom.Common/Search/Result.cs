using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.Common.Search
{
    /// <summary>
    /// Base object for Search Results.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        public Result()
        {
            Items = new List<T>();
        }
        public virtual List<T> Items { get; set; }
        public int TotalRecords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool HasMoreRecords => TotalRecords > PageSize && Pages.Count() > 0 && Page < Pages.Max();
        public IEnumerable<int> Pages
        {
            get
            {
                var e = new List<int>();
                if (!Items.Count().Equals(TotalRecords) && PageSize > 0)
                {
                    var pages = (TotalRecords / PageSize);

                    for (int i = 0; i < pages; i++)
                    {
                        e.Add(i + 1);
                    }

                    if (TotalRecords % PageSize > 0)
                    {
                        e.Add(e.Count() + 1);
                    }
                }
                return e;
            }
        }
    }
}
