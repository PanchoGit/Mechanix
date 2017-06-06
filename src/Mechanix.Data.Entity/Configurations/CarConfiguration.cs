using Mechanix.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Mechanix.Data.Entity.Configurations
{
    class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            Ignore(x => x.Services);
        }
    }
}
