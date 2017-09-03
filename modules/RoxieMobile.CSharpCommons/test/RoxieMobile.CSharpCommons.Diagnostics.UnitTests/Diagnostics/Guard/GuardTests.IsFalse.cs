using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.IsFalse")]
        public void IsFalse(string method)
        {
            GuardThrowsError(method,
                () => Guard.IsFalse(2 > 1));

            GuardNotThrowsError(method,
                () => Guard.IsFalse(1 > 2));
        }
    }
}