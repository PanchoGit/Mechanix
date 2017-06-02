using Mechanix.Domain;
using Mechanix.Workflow.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Mechanix.Web.Controllers
{
    public class ServicesController : ApiController
    {
        private IServiceWorkflow workflow;

        public ServicesController(IServiceWorkflow workflow)
        {
            this.workflow = workflow;
        }

        public List<Service> Get()
        {
            return workflow.Get();
        }
    }
}
