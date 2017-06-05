using Mechanix.Workflow.Interfaces;
using Mechanix.Domain;
using Mechanix.Repository.Interfaces;

namespace Mechanix.Workflow
{
    public class CarWorkflow : ICarWorkflow
    {
        private ICarRepository carRepository;
        private ICarOwnerRepository carOwnerrepository;

        public CarWorkflow(ICarRepository carRepository, ICarOwnerRepository carOwnerrepository)
        {
            this.carRepository = carRepository;
            this.carOwnerrepository = carOwnerrepository;
        }

        public Car Create(Car car)
        {
            carRepository.Create(car);

            SetOwner(car);

            return car;
        }

        private void SetOwner(Car car)
        {
            var owner = car.Owner;

            if (owner == null || owner.Id != 0) return;

            var carOwner = new CarOwner
            {
                CarId = car.Id,
                OwnerId = owner.Id
            };

            carOwnerrepository.Create(carOwner);
        }
    }
}
