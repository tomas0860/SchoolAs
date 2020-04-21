using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace SchoolAs.WebAPI.Filters
{
    public class EnableCorsAttribute : ActionFilterAttribute
    {
        const string Origin = "Origin";
        const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        const string AccessControlAllowMethod = "Access-Control-Allow-Methods";

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            /*if (actionExecutedContext.Request.Headers.Contains(Origin))
            {
                string originHeader = actionExecutedContext.Request.Headers.GetValues(Origin).FirstOrDefault();
                if (!string.IsNullOrEmpty(originHeader))
                {
                    actionExecutedContext.Response.Headers.Add(AccessControlAllowOrigin, originHeader);
                }
                actionExecutedContext.Response.Headers.Add(AccessControlAllowMethod, "GET, POST, PUT, DELETE, OPTIONS");
            }*/
        }
    }
}