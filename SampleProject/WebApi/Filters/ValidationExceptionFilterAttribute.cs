using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;  

namespace WebApi.Filters
{
    public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ArgumentException argEx)
            {
                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    argEx.Message
                );
            }
        }
    }
}
