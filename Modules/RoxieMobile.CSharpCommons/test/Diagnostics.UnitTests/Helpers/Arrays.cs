namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Helpers
{
    public static class Arrays
    {
        /// <summary>
        /// Create a type-safe generic array.
        /// 
        /// This method makes only sense to provide arguments of the same type so that the compiler
        /// can deduce the type of the array itself.
        /// </summary>
        /// <param name="items">The varargs array items, <c>null</c> allowed</param>
        /// <typeparam name="T">The array's element type</typeparam>
        /// <returns>The array, not <c>null</c> unless a null array is passed in</returns>
        public static T[] ToArray<T>(params T[] items) =>
            items;
    }
}
