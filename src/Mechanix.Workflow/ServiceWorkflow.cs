using Mechanix.Domain;
using Mechanix.Workflow.Interfaces;
using System.Collections.Generic;

namespace Mechanix.Workflow
{
    public class ServiceWorkflow : IServiceWorkflow
    {
        public List<Service> Get()
        {
            return new List<Service>()
            {
                new Service{ Id=1, Name="111"}
            };
        }
    }
}
