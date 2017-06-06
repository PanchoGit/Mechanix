using Mechanix.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanix.Repository.Interfaces
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> Get();
    }
}
