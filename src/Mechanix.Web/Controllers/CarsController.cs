using Mechanix.Domain;
using Mechanix.Workflow.Interfaces;
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

        public Car Post(Car model)
        {
            return workflow.Create(model);
        }
    }
}