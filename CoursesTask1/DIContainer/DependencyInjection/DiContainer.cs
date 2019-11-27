using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DIContainer.DependencyInjection
{
    public class DiContainer
    {
        private List<ServiceDescriptor> _serviceDescriptors;

        public DiContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        internal T GetService<T>()
        {
            var descriptor = _serviceDescriptors
                .SingleOrDefault(x => x.ServiceType == typeof(T));

            if(descriptor==null)
            {
                throw new Exception($"Service of type {typeof(T).Name} isn't registered \n");
            }

            if(descriptor.Implementation!=null)
            {
                return (T)descriptor.Implementation;
            }

            var implementation = (T)Activator.CreateInstance(descriptor.ServiceType);

            if(descriptor.Lifetime==ServiceLifetime.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            return implementation;
        }
    }
}
