using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace WebAPI
{
    public class APICustomHandleError : ExceptionFilterAttribute
    {       

        public override void OnException(HttpActionExecutedContext context)
        {
            //Log the exception
            System.Exception ex = context.Exception;
            //logger will be here
           
        }
    }
}