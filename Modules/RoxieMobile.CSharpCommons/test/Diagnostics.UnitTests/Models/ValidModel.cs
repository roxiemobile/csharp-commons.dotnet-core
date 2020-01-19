using RoxieMobile.CSharpCommons.Abstractions.Models;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models
{
    public class ValidModel : IValidatable
    {
        public bool IsValid() => true;
    }
}
