﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Datacom.Common.Extensions
{
    public static class ObjectExtensions
    {
        internal static object GetPropertyByName(this object helper, string propertyName)
        {
            if (helper != null && (string.IsNullOrEmpty(propertyName)))
            {
                return helper.GetType().GetRuntimeProperty(propertyName);
            }
            return null;
        }
    }
}
