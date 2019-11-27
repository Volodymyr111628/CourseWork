﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DIContainer.DependencyInjection
{
    public class ServiceDescriptor
    {
        private Type type1;
        private Type type2;
        private ServiceLifetime transient;

        public Type ServiceType { get; }

        public Type ImplementationType { get; set; }

        public object Implementation { get; set; }

        public ServiceLifetime Lifetime { get; }

        public ServiceDescriptor(object implementation,ServiceLifetime lifetime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
            Lifetime = lifetime; 
        }

        public ServiceDescriptor(Type serviceType,ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
        }

        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            transient = lifetime;
        }
    }
}