using Datacom.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Datacom.Common.Mvc.Extensions
{
    public static class ModelStateExtensions
    {
        const string defaultErrorProperty = "error";

        public static void AddException(this ModelStateDictionary helper, Exception ex)
        {
            if (ex is PropertyException)
            {
                var e = (PropertyException)ex;

                helper.AddModelError(e.Property, ex.Message);
            }
            else if (ex is AggregateException)
            {
                foreach (var item in ((AggregateException)ex).InnerExceptions)
                {
                    if (item is PropertyException)
                    {
                        var p = (PropertyException)item;
                        helper.AddModelError(p.Property, p.Message);
                    }
                    else
                    {
                        helper.AddModelError(defaultErrorProperty, item.Message);
                    }
                }
            }
            else
            {
                helper.AddModelError(defaultErrorProperty, ex.Message);
            }
        }
    }
}
