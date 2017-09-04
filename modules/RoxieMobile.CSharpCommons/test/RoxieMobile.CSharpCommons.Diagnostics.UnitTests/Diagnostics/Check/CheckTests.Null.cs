using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.Null")]
        public void Null(string method)
        {
            CheckThrowsException(method,
                () => Check.Null(2));

            CheckNotThrowsException(method,
                () => Check.Null(null));
        }
    }
}