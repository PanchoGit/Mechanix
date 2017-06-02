using System.Collections.Generic;
using System.Data.Entity;
using Mechanix.Domain;
using Mechanix.Repository.Interfaces;

namespace Mechanix.Repository
{
    public class ServiceRepository : RepositoryBase<Service, int>, IServiceRepository
    {
        public ServiceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Service> Get()
        {
            return set.ToListAsync().Result;
        }
    }
}
