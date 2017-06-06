using Mechanix.Domain;
using System.Collections.Generic;

namespace Mechanix.Repository.Interfaces
{
    public interface ICarServiceRepository
    {
        void Create(List<CarService> carServices);
    }
}
