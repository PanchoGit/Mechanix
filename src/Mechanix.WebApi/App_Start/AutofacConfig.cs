using Autofac;
using Autofac.Integration.WebApi;
using Mechanix.Data.Entity;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Mechanix.WebApi
{
    public static class AutofacConfig
    {
        private const string WorkflowAssemblyEndName = "Workflow";
        private const string RepositoryAssemblyEndName = "Repository";
        private const string DataAssemblyEndName = "Data";
        private const string DefaultConnectionString = "default";

        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            RegisterDependencies(builder);

            RegisterEntityDependencies(builder);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(s => s.Name.EndsWith(WorkflowAssemblyEndName))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(s => s.Name.EndsWith(DataAssemblyEndName))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(s => s.Name.EndsWith(RepositoryAssemblyEndName))
                .AsImplementedInterfaces();
        }

        private static void RegisterEntityDependencies(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(MechanixContext))
                .As<DbContext>()
                .WithParameter("connectionString", ConfigurationManager.ConnectionStrings[DefaultConnectionString].ToString())
                .InstancePerRequest();
        }
    }
}