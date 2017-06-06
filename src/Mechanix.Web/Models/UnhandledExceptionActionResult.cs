using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mechanix.Web.Models
{
    public class UnhandledExceptionActionResult : IHttpActionResult
    {
        private readonly HttpResponseMessage httpResponseMessage;

        public UnhandledExceptionActionResult(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(httpResponseMessage);
        }
    }
}