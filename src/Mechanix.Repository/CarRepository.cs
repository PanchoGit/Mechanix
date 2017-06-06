using Mechanix.Repository.Interfaces;
using Mechanix.Domain;
using System.Data.Entity;

namespace Mechanix.Repository
{
    public class CarRepository : RepositoryBase<Car, int>, ICarRepository
    {
        protected DbSet<Owner> Owners { get; set; }

        public CarRepository(DbContext dbContext) : base(dbContext)
        {
            Owners = dbContext.Set<Owner>();
        }

        public void Create(Car car)
        {
            if(car.Owner.Id > 0)
            {
                car.Owner = Owners.Find(car.Owner.Id);
            }

            Save(car);
        }
    }
}
