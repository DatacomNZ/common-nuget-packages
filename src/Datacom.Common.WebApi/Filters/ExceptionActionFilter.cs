using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace Datacom.Common.WebApi.Filters
{
    /// <summary>
    /// 
    /// </summary>
    //public class ExceptionActionFilter : FilterAttribute, IExceptionFilter
    //{
    //    const string DefaultPropertyName = "error";
    //    public void OnException(ExceptionContext filterContext)
    //    {
    //        if (filterContext.ExceptionHandled)
    //        {
    //            return;
    //        }
    //        HandleAggregateException(filterContext);
    //        HandlePropertyException(filterContext);
    //        HandleGenericException(filterContext);

    //        filterContext.ExceptionHandled = true;
    //        filterContext.Result = new ViewResult
    //        {
    //            ViewName = ((RouteData)filterContext.RouteData).Values["action"].ToString(),
    //            TempData = filterContext.Controller.TempData,
    //            ViewData = filterContext.Controller.ViewData
    //        };
    //    }

    //    private void HandleGenericException(ExceptionContext filterContext)
    //    {
    //        var modelState = filterContext.Controller.ViewData.ModelState;
    //        modelState.AddModelError("", filterContext.Exception.Message);
    //    }

    //    private void HandlePropertyException(ExceptionContext filterContext)
    //    {
    //        if (filterContext.Exception is PropertyException)
    //        {
    //            var ex = (PropertyException)filterContext.Exception;
    //            var modelState = filterContext.Controller.ViewData.ModelState;

    //            modelState.AddModelError(ex.Property, ex.Message);
    //        }
    //    }

    //    private void HandleAggregateException(ExceptionContext filterContext)
    //    {
    //        if (filterContext.Exception is AggregateException)
    //        {
    //            var ex = (AggregateException)filterContext.Exception;
    //            var modelState = filterContext.Controller.ViewData.ModelState;

    //            foreach (var exc in ex.InnerExceptions)
    //            {
    //                if (exc is PropertyException)
    //                {
    //                    var pe = (PropertyException)exc;
    //                    modelState.AddModelError(string.IsNullOrEmpty(pe.Property) ? DefaultPropertyName : pe.Property, pe.Message);
    //                }
    //                else
    //                {
    //                    modelState.AddModelError(DefaultPropertyName, exc.Message);
    //                }
    //            }
    //        }
    //    }
    //}
}
