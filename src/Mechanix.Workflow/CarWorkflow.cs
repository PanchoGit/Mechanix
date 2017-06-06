using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Mechanix.Workflow.Interfaces;
using Mechanix.Domain;
using Mechanix.Repository.Interfaces;
using Mechanix.Common;
using Mechanix.Workflow.Resources;

namespace Mechanix.Workflow
{
    public class CarWorkflow : ICarWorkflow
    {
        private ICarRepository carRepository;
        private ICarOwnerRepository carOwnerRepository;
        private ICarServiceRepository carServiceRepository;
        private DbContext dbContext;

        public CarWorkflow(ICarRepository carRepository, 
            ICarOwnerRepository carOwnerRepository, 
            ICarServiceRepository carServiceRepository, 
            DbContext dbContext)
        {
            this.carRepository = carRepository;
            this.carOwnerRepository = carOwnerRepository;
            this.carServiceRepository = carServiceRepository;
            this.dbContext = dbContext;
        }

        public Result Create(Car car)
        {
            var result = ValidateCreate(car);

            if (result.HasErrors) return result;

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                carRepository.Create(car);

                SetCarService(car);

                transaction.Commit();
            }

            return new Result<Car>(car);
        }

        private void SetCarService(Car car)
        {
            var services = car.Services;

            if (services == null) return;

            var carServices = new List<CarService>();

            foreach (var item in services)
            {
                carServices.Add(new CarService {
                    CarId = car.Id,
                    ServiceId = item.Id,
                    Date = System.DateTime.UtcNow
                });
            }
            carServiceRepository.Create(carServices);
        }

        private Result<Car> ValidateCreate(Car car)
        {
            var result = new Result<Car>();

            car.Brand = car.Brand?.Trim();
            if (string.IsNullOrWhiteSpace(car.Brand))
            {
                result.AddError(MessageResource.Car_NoBrand, nameof(MessageResource.Car_NoBrand), nameof(car.Brand));
            }

            if (car.Year == 0)
            {
                result.AddError(MessageResource.Car_NoYear, nameof(MessageResource.Car_NoYear), nameof(car.Year));
            }

            car.Patent = car.Patent?.Trim();
            if (string.IsNullOrWhiteSpace(car.Patent))
            {
                result.AddError(MessageResource.Car_NoPatent, nameof(MessageResource.Car_NoPatent), nameof(car.Patent));
            }

            car.Owner.FirstName = car.Owner.FirstName?.Trim();
            if (string.IsNullOrWhiteSpace(car.Owner.FirstName))
            {
                result.AddError(MessageResource.Car_NoOwnerFirstName, nameof(MessageResource.Car_NoOwnerFirstName), nameof(car.Owner.FirstName));
            }

            car.Owner.LastName = car.Owner.LastName?.Trim();
            if (string.IsNullOrWhiteSpace(car.Owner.LastName))
            {
                result.AddError(MessageResource.Car_NoOwnerLastName, nameof(MessageResource.Car_NoOwnerLastName), nameof(car.Owner.LastName));
            }

            if (!car.Services.Any())
            {
                result.AddError(MessageResource.Car_NoService, nameof(MessageResource.Car_NoService), nameof(car.Services));
            }

            return result;
        }
    }
}
