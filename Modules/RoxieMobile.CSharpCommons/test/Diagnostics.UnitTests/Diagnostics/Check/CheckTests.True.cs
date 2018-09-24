using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.True")]
        public void True(string method)
        {
            CheckThrowsException(method,
                () => Check.True(1 > 2));

            CheckNotThrowsException(method,
                () => Check.True(2 > 1));
        }
    }
}