using RoxieMobile.CSharpCommons.Abstractions.Models;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models.Abstractions
{
    public abstract class AbstractValidatableModel : IValidatable, IPostValidatable
    {
// MARK: - Methods

        public virtual bool IsValid()
        {
            var result = true;
            try {
                Validate();
            }
            catch (CheckException) {
                result = false;
            }
            return result;
        }

        public virtual bool IsShouldPostValidate() =>
            true;

        public abstract void Validate();
    }
}
