namespace RoxieMobile.CSharpCommons.Abstractions.Validators
{
    public interface IValidator
    {
        /// <summary>
        /// Tests the current state of the object.
        /// </summary>
        /// <returns><c>true</c> if object validation succeeded; otherwise, <c>false</c>.</returns>
        bool IsValid(object value);
    }
}