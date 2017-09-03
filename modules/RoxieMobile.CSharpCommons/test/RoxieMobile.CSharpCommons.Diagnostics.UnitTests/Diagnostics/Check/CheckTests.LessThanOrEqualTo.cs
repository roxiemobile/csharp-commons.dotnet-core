using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.LessThanOrEqualTo")]
        public void LessThanOrEqualTo(string method)
        {
            CheckThrowsException(method,
                () => Check.LessThanOrEqualTo(2, 1));

            CheckNotThrowsException(method,
                () => Check.LessThanOrEqualTo(2, 2));
            CheckNotThrowsException(method,
                () => Check.LessThanOrEqualTo(1, 2));
        }
    }
}