using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.False")]
        public void False(string method)
        {
            CheckThrowsException(method,
                () => Check.False(2 > 1));

            CheckNotThrowsException(method,
                () => Check.False(1 > 2));
        }
    }
}