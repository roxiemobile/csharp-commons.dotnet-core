using System;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class ObjectExtension
    {
// MARK: - Methods

        /// <summary>
        /// Yields self to the block, and then returns self. The primary purpose of this method is to “tap into” a method chain, in order to perform operations on intermediate results within the chain.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="obj">The object which will be yielded to to the block.</param>
        /// <param name="block">The block in which object will be yielded.</param>
        /// <returns>The passed object.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        public static T Tap<T>(this T obj, Action<T> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            block(obj);
            return obj;
        }
    }
}