namespace RoxieMobile.CSharpCommons.Abstractions.Models
{
    public interface IValidatable
    {
        /// <summary>
        /// Tests the current state of the object.
        /// </summary>
        /// <returns><c>true</c> if object validation succeeded; otherwise, <c>false</c>.</returns>
        bool IsValid();
    }
}