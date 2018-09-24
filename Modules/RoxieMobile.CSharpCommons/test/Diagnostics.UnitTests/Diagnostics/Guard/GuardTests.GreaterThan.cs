using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.GreaterThan")]
        public void GreaterThan(string method)
        {
            GuardThrowsError(method,
                () => Guard.GreaterThan(1, 2));
            GuardThrowsError(method,
                () => Guard.GreaterThan(2, 2));

            GuardNotThrowsError(method,
                () => Guard.GreaterThan(2, 1));
        }
    }
}