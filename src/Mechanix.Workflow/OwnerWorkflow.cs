using System.Linq;
using System.Collections.Generic;
using Mechanix.Workflow.Interfaces;
using Mechanix.Domain;
using Mechanix.Repository.Interfaces;

namespace Mechanix.Workflow
{
    public class OwnerWorkflow : IOwnerWorkflow
    {
        private IOwnerRepository repository;

        public OwnerWorkflow(IOwnerRepository repository)
        {
            this.repository = repository;
        }

        public List<Owner> Get()
        {
            return repository.Get().ToList();
        }
    }
}
