using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.IsFalse")]
        public void IsFalse(string method)
        {
            CheckThrowsException(method,
                () => Check.IsFalse(2 > 1));

            CheckNotThrowsException(method,
                () => Check.IsFalse(1 > 2));
        }
    }
}