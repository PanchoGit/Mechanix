using Mechanix.Domain;
using Mechanix.Workflow.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Mechanix.Web.Controllers
{
    public class OwnersController : ApiController
    {
        private IOwnerWorkflow workflow;

        public OwnersController(IOwnerWorkflow workflow)
        {
            this.workflow = workflow;
        }

        public List<Owner> Get()
        {
            return workflow.Get();
        }
    }
}