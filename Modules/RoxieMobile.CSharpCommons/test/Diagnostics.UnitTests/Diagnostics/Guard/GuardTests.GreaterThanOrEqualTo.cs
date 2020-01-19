using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.GreaterThanOrEqualTo")]
        public void GreaterThanOrEqualTo(string method)
        {
            GuardThrowsError(method,
                () => Guard.GreaterThanOrEqualTo(1, 2));

            GuardNotThrowsError(method,
                () => Guard.GreaterThanOrEqualTo(2, 2));
            GuardNotThrowsError(method,
                () => Guard.GreaterThanOrEqualTo(2, 1));
        }
    }
}
