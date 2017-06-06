using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using Mechanix.Web.Models;

namespace Mechanix.Web.Controllers.Filters
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var responseObject =
                new
                {
                    Data =
                        new
                        {
                            Success = false,
                            Error = new { context.Exception.Message, context.Exception.StackTrace }
                        }
                };

            context.Result = new UnhandledExceptionActionResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError, responseObject));
        }
    }
}