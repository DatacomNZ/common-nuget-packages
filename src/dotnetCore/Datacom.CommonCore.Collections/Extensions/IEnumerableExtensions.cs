using Datacom.CommonCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datacom.CommonCore.Collections.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// used Page throw lists that are in memory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> helper, PagingFilter filter)
        {
            return helper.Skip(filter.Skip).Take(filter.Take);
        }

        /// <summary>
        /// Used to Sort lists in memory using the Filter object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<T> SortOrder<T>(this IEnumerable<T> helper, BaseSearchFilter filter)
        {
            return helper.SortOrder(filter.Sort);
        }

        /// <summary>
        /// Used to Sort Lists in memory using the FilterSort Object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<T> SortOrder<T>(this IEnumerable<T> helper, SortFilter sort)
        {
            if (sort == null || string.IsNullOrEmpty(sort.SortOrder))
            {
                throw new ArgumentException("Sort is empty", "Sort");
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
