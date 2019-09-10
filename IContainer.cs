using System;
using System.Collections.Generic;

namespace Trizetto.Facets.Benefit.Core.IoC
{
    public interface IContainer : IDisposable
    {
        /// <summary>
        /// Defines a method named RegisterType
        /// </summary>
        /// <typeparam name="TFrom">First parameter</typeparam>
        /// <typeparam name="TTo">Second parameter</typeparam>
        /// <returns>a result</returns>
        IContainer RegisterType<TFrom, TTo>() where TTo : TFrom;

        /// <summary>
        /// Defines a method named RegisterInstance
        /// </summary>
        /// <typeparam name="T">Parameter type</typeparam>
        /// <param name="instance">First parameter</param>
        /// <returns>a result</returns>
        IContainer RegisterInstance<T>(T instance);

        /// <summary>
        /// Defines a method named Resolve
        /// </summary>
        /// <param name="t">Type parameter</param>
        /// <returns>a result</returns>
        object Resolve(Type t);

        /// <summary>
        /// Defines a method 
        /// </summary>
        /// <typeparam name="T">T type parameter</typeparam>
        /// <returns>a result</returns>
        T Resolve<T>();

        /// <summary>
        /// Defines a method named ResolveALL
        /// </summary>
        /// <param name="t">Type t parameter</param>
        /// <returns>a result</returns>
        IEnumerable<object> ResolveAll(Type t);

        /// <summary>
        /// Defines a method named CreateChildContainer
        /// </summary>
        /// <returns>a result</returns>
        IContainer CreateChildContainer();

        // TODO: Add additional methods for registration
    }
}