using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.LessThan")]
        public void LessThan(string method)
        {
            CheckThrowsException(method,
                () => Check.LessThan(2, 1));
            CheckThrowsException(method,
                () => Check.LessThan(2, 2));

            CheckNotThrowsException(method,
                () => Check.LessThan(1, 2));
        }
    }
}
