using Mechanix.Domain;
using System.Collections.Generic;

namespace Mechanix.Repository.Interfaces
{
    public interface IServiceRepository
    {
        IEnumerable<Service> Get();
    }
}
