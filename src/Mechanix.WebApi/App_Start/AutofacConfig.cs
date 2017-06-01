using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Mechanix.WebApi
{
    public static class AutofacConfig
    {
        private const string WorkflowAssemblyEndName = "Workflow";
        private const string DataAssemblyEndName = "Data";
        private const string RepositoryAssemblyEndName = "Repository";
        private const string ServiceAssemblyEndName = "Service";
        private const string ManagerAssemblyEndName = "Manager";
        private const string SettingAssemblyEndName = "Setting";
        public static IContainer Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            RegisterDependencies(builder);

            RegisterNhibernateDependencies(builder);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
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

            builder.RegisterAssemblyTypes(assemblies)
                .Where(s => s.Name.EndsWith(ServiceAssemblyEndName))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(s => s.Name.EndsWith(ManagerAssemblyEndName))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(s => s.Name.EndsWith(SettingAssemblyEndName))
                .AsImplementedInterfaces()
                .SingleInstance();
        }

        private static void RegisterNhibernateDependencies(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryBase<>))
                .AsImplementedInterfaces();

            builder.Register(c => c.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>()
                .InstancePerRequest();

            builder.Register(c => NhibernateConfig.BuildSessionFactory())
                   .As<ISessionFactory>()
                   .SingleInstance();
        }
    }
}