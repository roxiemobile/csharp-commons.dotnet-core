using System.ComponentModel.DataAnnotations;

namespace RoxieMobile.CSharpCommons.DataAnnotations
{
    public class OptionalAttribute : ValidationAttribute
    {
// MARK: - Methods

        public override bool IsValid(object value)
        {
            return true;
        }
    }
}
