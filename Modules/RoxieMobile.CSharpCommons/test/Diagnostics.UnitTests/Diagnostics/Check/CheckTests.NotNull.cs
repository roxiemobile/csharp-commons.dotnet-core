using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.NotNull")]
        public void NotNull(string method)
        {
            CheckThrowsException(method,
                () => Check.NotNull(null));

            CheckNotThrowsException(method,
                () => Check.NotNull(2));
        }
    }
}
