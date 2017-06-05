using Mechanix.Data.Entity.Conventions;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace Mechanix.Data.Entity
{
    public class MechanixContext : DbContext
    {
        private const string Schema = "app";
        private const string MappingClassPostfix = "Configuration";

        public MechanixContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());

            AddMappingConfigurations(modelBuilder);
        }

        private void AddMappingConfigurations(DbModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes().Where(x => x.FullName.EndsWith(MappingClassPostfix));

            foreach (var type in types)
            {
                dynamic entityConfiguration = Activator.CreateInstance(type);

                modelBuilder.Configurations.Add(entityConfiguration);
            }
        }
    }
}
