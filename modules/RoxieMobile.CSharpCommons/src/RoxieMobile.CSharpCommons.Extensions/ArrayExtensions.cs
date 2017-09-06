namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Checks that an array is <c>null</c> or empty. 
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="array">The array to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="array"/> parameter is <c>null</c> or empty.</returns>
        public static bool IsEmpty<T>(this T[] array) =>
            (array == null) || (array.Length < 1);

        /// <summary>
        /// Checks that an array is not <c>null</c> and not empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="array">The array to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="array"/> parameter is not <c>null</c> and not empty.</returns>
        public static bool IsNotEmpty<T>(this T[] array) =>
            !array.IsEmpty();
    }
}