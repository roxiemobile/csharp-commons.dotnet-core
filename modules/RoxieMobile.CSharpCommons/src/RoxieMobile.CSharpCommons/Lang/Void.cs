namespace RoxieMobile.CSharpCommons.Lang
{
    /// <summary>
    /// The {@code Void} class is an uninstantiable placeholder class to hold a reference
    /// to the {@code Class} object representing the C# keyword void.
    /// </summary>
    public sealed class Void
    {
        /// <summary>
        /// The Void class cannot be instantiated.
        /// </summary>
        private Void() {}

        /// <summary>
        /// Gets the single unit value.
        /// </summary>
        public static Void Default { get; } = new Void();
    }
}