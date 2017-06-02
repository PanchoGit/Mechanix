using Mechanix.Domain;
using Mechanix.Repository.Interfaces;
using Mechanix.Workflow.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Mechanix.Workflow
{
    public class ServiceWorkflow : IServiceWorkflow
    {
        private IServiceRepository repository;

        public ServiceWorkflow(IServiceRepository repository)
        {
            this.repository = repository;
        }

        public List<Service> Get()
        {
            return repository.Get().ToList();
        }
    }
}
