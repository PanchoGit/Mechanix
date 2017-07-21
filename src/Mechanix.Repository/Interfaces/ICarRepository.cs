using Mechanix.Domain;
using System.Collections.Generic;

namespace Mechanix.Repository.Interfaces
{
    public interface ICarRepository
    {
        void Create(Car car);

        List<Car> Get();
    }
}
