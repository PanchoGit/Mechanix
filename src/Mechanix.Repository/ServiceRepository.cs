using Mechanix.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mechanix.Domain;

namespace Mechanix.Repository
{
    public class ServiceRepository : IServiceRepository
    {


        public IEnumerable<Service> Get()
        {
            throw new NotImplementedException();
        }
    }
}
