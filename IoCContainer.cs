using Microsoft.Extensions.DependencyInjection;

namespace Trizetto.Facets.Benefit.Core.IoC
{
    using System;
    using System.Collections.Generic;
    using di;

    //using Microsoft.Practices.Unity;
    //using Unity;
    // using Unity.Lifetime;
    // using Trizetto.Facets.Benefit.Core.Interfaces.IoC;

    /// <summary>
    /// Defines a class named IoCContainer
    /// </summary>
    public class IoCContainer : IContainer, IDisposable
    {
        /// <summary>
        /// Declares a static object named SyncRoot
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Declares an object named instance that is of type private and static
        /// </summary>
        private static volatile IoCContainer instance;

        /// <summary>
        /// Defines an object 
        /// </summary>
        //private readonly IUnityContainer unityContainer = new UnityContainer();

        private readonly IServiceProvider serviceProvider;
        private readonly IServiceCollection services;

        /// <summary>
        /// Initializes a boolean object named disposed with value false
        /// </summary>
        private bool disposed = false;


        public IoCContainer(IServiceCollection _services, ServiceProvider _serviceProvider)
        {
            services = _services;
            serviceProvider = _serviceProvider;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="IoCContainer"/> class from being created.
        /// </summary>
        private IoCContainer() 
        {
        }

        /// <summary>
        /// Gets a static instance of IContainer
        /// </summary>
        public static IContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
//                          instance = new IoCContainer();
//                          instance.unityContainer.RegisterInstance<IContainer>(instance, new ExternallyControlledLifetimeManager());
                            // instance = new IoCContainer();

                            instance = Startup.sp.GetService<IoCContainer>();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets a value 
        /// </summary>
        //public IUnityContainer UnityContainer
        //{
        //    get
        //    {
        //        return null;//this.unityContainer;
        //    }
        //}

        /// <summary>
        /// Defines an interface
        /// </summary>
        /// <typeparam name="TFrom">First parameter</typeparam>
        /// <typeparam name="TTo">Second parameter</typeparam>
        /// <returns>a result</returns>
        public IContainer RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            //this.unityContainer.RegisterType<TFrom, TTo>();
            services.AddScoped(typeof(TFrom), typeof(TTo));
            //services.AddScoped<TFrom, TTo>(); //This does not compile
            return instance;
        }

        /// <summary>
        /// Defines an interface
        /// </summary>
        /// <typeparam name="T">Parameter type</typeparam>
        /// <param name="typeInstance">First parameter</param>
        /// <returns>a result</returns>
        public IContainer RegisterInstance<T>(T typeInstance)
        {
            //this.unityContainer.RegisterInstance<T>(typeInstance, new ExternallyControlledLifetimeManager());
            services.AddSingleton(typeof(T), typeInstance);
            return instance;
        }

        /// <summary>
        /// Defines a method Resolve of type object
        /// </summary>
        /// <param name="t">Parameter type</param>
        /// <returns>a result</returns>
        public object Resolve(Type t)
        {
//            return this.unityContainer.Resolve(t);
            return this.serviceProvider.GetService(t);
        }

        /// <summary>
        /// Defines an instance method on any object of type IUnityContainer
        /// </summary>
        /// <typeparam name="T">First parameter</typeparam>
        /// <returns>a result</returns>
        public T Resolve<T>()
        {
//            return this.unityContainer.Resolve<T>();
            return this.serviceProvider.GetService<T>();
        }

        /// <summary>
        /// Defines an interface
        /// </summary>
        /// <param name="t">Parameter type</param>
        /// <returns>a result</returns>
        public IEnumerable<object> ResolveAll(Type t)
        {
//            return this.unityContainer.ResolveAll(t);
            return serviceProvider.GetServices(t);
        }

        /// <summary>
        /// Defines an interface named IContainer
        /// </summary>
        /// <returns>a result</returns>
        public IContainer CreateChildContainer()
        {
            //// TODO: Verify & Validate if this is the right thing to do
            ////return new IoCContainer();
            return instance;
        }

        /// <summary>
        /// Defines a method Dispose
       /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Defines a virtual method named Dispose that takes a boolean value as an argument
        /// </summary>
        /// <param name="disposing">First parameter</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (!disposing)
            {
                return;
            }

            //if (this.unityContainer != null)
            //{
            //    this.unityContainer.Dispose();
            //}

            this.disposed = true;
        }
    }
}
