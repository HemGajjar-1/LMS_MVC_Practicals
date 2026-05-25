using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Filters
{
    public class MyExceptionFilter : FilterAttribute , IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ContentResult()
            {
                Content = "Error Occurred :" + filterContext.Exception.Message
            };
            filterContext.ExceptionHandled = true;
        }
    }
}