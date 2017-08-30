using Datacom.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datacom.Common.Extensions;

namespace Datacom.Common.Collections.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> helper, Filter filter)
        {
            return helper.Skip(filter.Skip).Take(filter.Take);
        }

        public static IOrderedEnumerable<T> SortOrder<T>(this IEnumerable<T> helper, Filter filter)
        {
            return helper.SortOrder(filter.OrderBy);
        }

        public static IOrderedEnumerable<T> SortOrder<T>(this IEnumerable<T> helper, FilterSort sort)
        {
            if (sort == null || string.IsNullOrEmpty(sort.SortOrder))
            {
                throw new PropertyException("Sort", "FilterSort is empty");
            }
            Func<T, object> orderby = x => x.GetPropertyByName(sort.Property);

            if (sort.IsDescending)
            {
                return helper.OrderByDescending(orderby);
            }

            return helper.OrderBy(orderby);
        }
    }
}
