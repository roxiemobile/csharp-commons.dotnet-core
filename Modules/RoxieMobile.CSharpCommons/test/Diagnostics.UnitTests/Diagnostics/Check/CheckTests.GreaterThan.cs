using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.GreaterThan")]
        public void GreaterThan(string method)
        {
            CheckThrowsException(method,
                () => Check.GreaterThan(1, 2));
            CheckThrowsException(method,
                () => Check.GreaterThan(2, 2));

            CheckNotThrowsException(method,
                () => Check.GreaterThan(2, 1));
        }
    }
}
