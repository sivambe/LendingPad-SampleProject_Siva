using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Raven.Abstractions.Exceptions;    

namespace WebApi.Filters
{
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;

            // 1. Domain / Validation Errors -> 400 Bad Request
            if (exception is ArgumentException || exception is InvalidOperationException)
            {
                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    exception.Message
                );
                return;
            }

            // 2. RavenDB or Database Connection / Outage Issues -> 503 Service Unavailable
            if (IsDatabaseException(exception))
            {
                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.ServiceUnavailable,
                    "The service is temporarily unavailable due to a database issue. Please try again later."
                );
                return;
            }

            // 3. Fallback -> 500 Internal Server Error
            context.Response = context.Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                "An unexpected server error occurred."
            );
        }

        private static bool IsDatabaseException(Exception ex)
        {
            if (ex is TimeoutException || ex is ConcurrencyException)
                return true;

            // Catch any exception coming from the RavenDB client assemblies
            var ns = ex.GetType().Namespace ?? string.Empty;
            return ns.StartsWith("Raven.", StringComparison.OrdinalIgnoreCase);
        }
    }
}
