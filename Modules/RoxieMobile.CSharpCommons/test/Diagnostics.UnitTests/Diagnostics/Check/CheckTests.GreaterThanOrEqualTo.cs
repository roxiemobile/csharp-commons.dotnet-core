using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.GreaterThanOrEqualTo")]
        public void GreaterThanOrEqualTo(string method)
        {
            CheckThrowsException(method,
                () => Check.GreaterThanOrEqualTo(1, 2));

            CheckNotThrowsException(method,
                () => Check.GreaterThanOrEqualTo(2, 2));
            CheckNotThrowsException(method,
                () => Check.GreaterThanOrEqualTo(2, 1));
        }
    }
}
