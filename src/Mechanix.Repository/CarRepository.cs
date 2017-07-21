using Mechanix.Repository.Interfaces;
using Mechanix.Domain;
using System.Data.Entity;
using System.Collections.Generic;

namespace Mechanix.Repository
{
    public class CarRepository : RepositoryBase<Car, int>, ICarRepository
    {
        protected DbSet<Owner> Owners { get; set; }

        protected DbSet<Car> Cars { get; set; }

        public CarRepository(DbContext dbContext) : base(dbContext)
        {
            Owners = dbContext.Set<Owner>();
            Cars = dbContext.Set<Car>();
        }

        public void Create(Car car)
        {
            if(car.Owner.Id > 0)
            {
                car.Owner = Owners.Find(car.Owner.Id);
            }

            Save(car);
        }

        public List<Car> Get()
        {
            return Cars.ToListAsync().Result;
        }
    }
}
