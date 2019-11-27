using System;
using System.Collections.Generic;
using System.Text;
using DIContainer.Common;

namespace DIContainer.DependencyInjection
{
    public class DiServiceCollection
    {
        private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();

        public void RegisterSingleton<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifetime.Singleton));
        }

        internal void RegisterTransient<TService, TImplementation>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }

        public void RegisterSingleton<TService>(TService implementation)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
        }

        public void RegisterTransient<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifetime.Transient));
        }

        public DiContainer GenerateContainer()
        {
            return new DiContainer(_serviceDescriptors);
        }
    }
}
