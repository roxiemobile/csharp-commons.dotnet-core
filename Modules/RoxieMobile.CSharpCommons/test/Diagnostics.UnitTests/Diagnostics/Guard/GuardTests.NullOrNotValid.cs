using System.Diagnostics.CodeAnalysis;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.NullOrNotValid")]
        public void NullOrNotValid(string method)
        {
            IValidatable validObject = new ValidModel();
            IValidatable? nilObject = null;
            IValidatable notValidObject = new NotValidModel();


            GuardThrowsError(method,
                () => Guard.NullOrNotValid(validObject));

            GuardNotThrowsError(method,
                () => Guard.NullOrNotValid(nilObject));
            GuardNotThrowsError(method,
                () => Guard.NullOrNotValid(notValidObject));
        }
    }
}
