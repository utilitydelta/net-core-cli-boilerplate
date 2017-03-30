using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Dependencies
{
    public class Setup : IServiceResolver
    {
        private readonly ILifetimeScope _scope;

        public Setup()
        {
            var builder = new ContainerBuilder();

            //TODO: Register types here

            _scope = builder.Build().BeginLifetimeScope();
        }

        public T GetService<T>()
        {
            return _scope.Resolve<T>();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
