using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Datacom.CommonCore.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetPropertyByName(this object helper, string propertyName)
        {
            if (helper != null && (string.IsNullOrEmpty(propertyName)))
            {
                return helper.GetType().GetRuntimeProperty(propertyName);
            }
            return null;
        }
    }
}
