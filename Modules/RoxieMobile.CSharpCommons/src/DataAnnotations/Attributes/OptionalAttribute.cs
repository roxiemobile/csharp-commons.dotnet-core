using System.ComponentModel.DataAnnotations;

namespace RoxieMobile.CSharpCommons.DataAnnotations.Attributes
{
    public class OptionalAttribute : ValidationAttribute
    {
// MARK: - Methods

        public override bool IsValid(object value) =>
            true;
    }
}