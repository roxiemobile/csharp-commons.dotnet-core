namespace RoxieMobile.CSharpCommons.Lang
{
    /// <summary>
    /// The <see cref="Void"/> class is an uninstantiable placeholder class to hold a reference
    /// to the class object representing the C# keyword void.
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