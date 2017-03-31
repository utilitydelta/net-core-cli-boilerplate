using System.Reflection;
using Autofac;
using UtilityDelta.Domain;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Dependencies
{
    public class Setup : IServiceResolver
    {
        private readonly ILifetimeScope _scope;

        public Setup()
        {
            var builder = new ContainerBuilder();

            //Register types here
            builder.RegisterAssemblyTypes(typeof(CalculateEngine).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .SingleInstance();

            _scope = builder.Build().BeginLifetimeScope();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }

        public T GetService<T>()
        {
            return _scope.Resolve<T>();
        }
    }
}