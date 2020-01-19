using System;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Extensions
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ObjectExtension
    {
// MARK: - Methods

        /// <summary>
        /// Yields self to the block, and then returns self. The primary purpose of this method is to “tap into” a method chain, in order to perform operations on intermediate results within the chain.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="source">The object which will be yielded to to the block.</param>
        /// <param name="action">The block in which object will be yielded.</param>
        /// <returns>The passed object.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="action"/> is <c>null</c>.</exception>
        [return: NotNull]
        public static T Tap<T>([NotNull] this T source, Action<T> action)
        {
            if (action == null) {
                throw new ArgumentNullException(nameof(action));
            }

            action(source);
            return source;
        }

        /// <summary>
        /// Casts the object to the specified generic type.
        /// </summary>
        /// <typeparam name="T">The type to cast to.</typeparam>
        /// <param name="source">The object being casted.</param>
        /// <param name="defaultValue">A optional default value of the target-<see cref="Type"/><typeparamref name="T"/>.</param>
        /// <returns>Returns the object as casted type.</returns>
        [return: MaybeNull]
        public static T CastTo<T>(this object? source, [AllowNull] T defaultValue = default)
        {
            // @link https://github.com/lsauer/dotnet-portable-cast-convert-transform/blob/master/TypeCast/Extension/ObjectExtension%5BCast%5D.cs

            TryCast(source, out var result, defaultValue);
            return result;
        }

        /// <summary>The cast method following the `Try` function convention of the .Net Framework, returning a <see langword="bool"/> success 
        /// status rather than throwing an <see cref="Exception"/> upon a failed conversion.</summary>
        /// <typeparam name="T">The type to cast to.</typeparam>
        /// <param name="source">The object being casted.</param>
        /// <param name="result">The variable reference to which the type cast result is assigned.</param>
        /// <param name="defaultValue">An optional default value of the target-<see cref="Type"/><typeparamref name="T"/>.</param>
        /// <returns>The success state as <see cref="bool" /> indicating if the type cast succeeded (`true`) or failed (`false`).</returns>
        public static bool TryCast<T>(this object? source, [MaybeNull] out T result, [AllowNull] T defaultValue = default)
        {
            // @link https://github.com/lsauer/dotnet-portable-cast-convert-transform/blob/master/TypeCast/Extension/ObjectExtension%5BCast%5D.cs
            // @link https://github.com/ehsanrashid/Extensions/blob/master/System/ObjectExtension.cs

            switch (source) {
                case T obj: {
                    result = obj;
                    return true;
                }
                case null: {
                    result = defaultValue;
                    return true;
                }
                default: {
                    result = defaultValue;
                    return false;
                }
            }
        }
    }
}
