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
        /// <summary>
        /// used Page throw lists that are in memory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> helper, Filter filter)
        {
            return helper.Skip(filter.Skip).Take(filter.Take);
        }

        /// <summary>
        /// Used to Sort lists in memory using the Filter object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<T> SortOrder<T>(this IEnumerable<T> helper, Filter filter)
        {
            return helper.SortOrder(filter.OrderBy);
        }

        /// <summary>
        /// Used to Sort Lists in memory using the FilterSort Object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sort"></param>
        /// <returns></returns>
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
