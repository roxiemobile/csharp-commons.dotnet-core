using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.IsTrue")]
        public void IsTrue(string method)
        {
            CheckThrowsException(method,
                () => Check.IsTrue(1 > 2));

            CheckNotThrowsException(method,
                () => Check.IsTrue(2 > 1));
        }
    }
}