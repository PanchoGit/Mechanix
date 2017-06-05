using Mechanix.Repository.Interfaces;
using Mechanix.Domain;
using System.Data.Entity;

namespace Mechanix.Repository
{
    public class CarRepository : RepositoryBase<Car, int>, ICarRepository
    {
        public CarRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void Create(Car car)
        {
            Save(car);
        }
    }
}
