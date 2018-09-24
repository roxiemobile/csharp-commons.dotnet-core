namespace RoxieMobile.CSharpCommons.Abstractions.Models
{
    public interface IPostValidatable
    {
        /// <summary>
        /// Checks if object should be validated after construction.
        /// </summary>
        /// <returns><c>true</c> if object should be validated after construction; otherwise, <c>false</c>.</returns>
        bool IsShouldPostValidate();

        /// <summary>
        /// Checks the current state of the object for correctness.
        /// </summary>
        void Validate();
    }
}