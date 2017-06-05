using Mechanix.Domain;
using Mechanix.Repository.Interfaces;
using System.Data.Entity;

namespace Mechanix.Repository
{
    class CarOwnerRepository : RepositoryBase<CarOwner, int>, ICarOwnerRepository
    {
        public CarOwnerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void Create(CarOwner carOwner)
        {
            Save(carOwner);
        }
    }
}
