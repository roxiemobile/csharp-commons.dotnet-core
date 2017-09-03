using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.IsNull")]
        public void IsNull(string method)
        {
            CheckThrowsException(method,
                () => Check.IsNull(2));

            CheckNotThrowsException(method,
                () => Check.IsNull(null));
        }
    }
}