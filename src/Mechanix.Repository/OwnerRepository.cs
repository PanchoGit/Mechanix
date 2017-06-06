using System.Data.Entity;
using System.Collections.Generic;
using Mechanix.Repository.Interfaces;
using Mechanix.Domain;

namespace Mechanix.Repository
{
    public class OwnerRepository : RepositoryBase<Owner, int>, IOwnerRepository
    {
        public OwnerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Owner> Get()
        {
            return set.ToListAsync().Result;
        }
    }
}
