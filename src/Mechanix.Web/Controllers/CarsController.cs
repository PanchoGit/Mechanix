using Mechanix.Domain;
using Mechanix.Workflow.Interfaces;
using Mechanix.Web.Extensions;
using System.Web.Http;

namespace Mechanix.Web.Controllers
{
    public class CarsController : ApiController
    {
        private ICarWorkflow workflow;

        public CarsController(ICarWorkflow workflow)
        {
            this.workflow = workflow;
        }

        public IHttpActionResult Post(Car model)
        {
            var result = workflow.Create(model);

            return result.CreateResponse(this);
        }
    }
}