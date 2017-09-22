using Datacom.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Datacom.Common.Collections.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Used to page through query objects using filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IEnumerable<T> Page<T>(this IQueryable<T> helper, Filter filter)
        {
            return helper.Skip(filter.Skip).Take(filter.Take);
        }

        /// <summary>
        /// Used to build sort query using the Filter object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> SortOrder<T>(this IQueryable<T> helper, Filter filter)
        {
            return helper.SortOrder(filter.OrderBy);
        }

        /// <summary>
        /// Used to build sort query using the FilterSort Object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> SortOrder<T>(this IQueryable<T> helper, FilterSort sort)
        {
            if (sort == null || string.IsNullOrEmpty(sort.SortOrder))
            {
                throw new PropertyException("Sort", "FilterSort is empty");
            }

            //http://stackoverflow.com/questions/31955025/generate-ef-orderby-expression-by-string
            var entityType = typeof(T);

            //Create x=>x.PropName
            var propertyInfo = entityType.GetRuntimeProperty(sort.Property);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, sort.Property);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            var enumarableType = typeof(System.Linq.IQueryable);
            var methodName = (sort.IsDescending) ? "OrderByDescending" : "OrderBy";

            var method = enumarableType.GetRuntimeMethods()
                 .Where(m => m.Name == methodName && m.IsGenericMethodDefinition)
                 .Where(m =>
                 {
                     var parameters = m.GetParameters().ToList();
                     //Put more restriction here to ensure selecting the right overload                
                     return parameters.Count == 2;//overload that has 2 parameters
                 }).Single();

            //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

            /*Call query.OrderBy(selector), with query and selector: x=> x.PropName
              Note that we pass the selector as Expression to the method and we don't compile it.
              By doing so EF can extract "order by" columns and generate SQL for it.*/
            var newQuery = (IOrderedQueryable<T>)genericMethod
                 .Invoke(genericMethod, new object[] { helper, selector });
            return newQuery;
        }
    }
}
