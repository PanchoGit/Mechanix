using System.Data.Entity;
using Mechanix.Repository.Interfaces;
using Mechanix.Domain;
using System.Collections.Generic;

namespace Mechanix.Repository
{
    public class CarServiceRepository : RepositoryBase<CarService, int>, ICarServiceRepository
    {
        public CarServiceRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public void Create(List<CarService> carServices)
        {
            foreach(var item in carServices)
            {
                set.Add(item);
            }

            context.SaveChanges();
        }
    }
}
