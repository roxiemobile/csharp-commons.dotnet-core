using System.Diagnostics.CodeAnalysis;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.NullOrValid")]
        public void NullOrValid(string method)
        {
            IValidatable validObject = new ValidModel();
            IValidatable nilObject = null;
            IValidatable notValidObject = new NotValidModel();


            CheckThrowsException(method,
                () => Check.NullOrValid(notValidObject));

            CheckNotThrowsException(method,
                () => Check.NullOrValid(validObject));
            CheckNotThrowsException(method,
                () => Check.NullOrValid(nilObject));
        }
    }
}