using RoxieMobile.CSharpCommons.Abstractions.Models;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models
{
    public class NotValidModel : IValidatable
    {
        public bool IsValid() => false;
    }
}
