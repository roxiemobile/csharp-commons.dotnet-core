using System;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Data.Helpers
{
    /// <summary>Contains methods to create types of objects.</summary>
    public static class GenericActivator
    {
        /// <summary>Creates an instance of the type designated by the specified generic type parameter, using the constructor that best matches the specified parameters.</summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <param name="args">An array of arguments that match in number, order, and type the parameters of the constructor to invoke. If args is an empty array or null, the constructor that takes no parameters (the default constructor) is invoked.</param>
        /// <returns>A reference to the newly created object.</returns>
        public static T NewInstance<T>(params object?[]? args) =>
            Activator.CreateInstance(typeof(T), args).CastTo<T>();
    }
}
