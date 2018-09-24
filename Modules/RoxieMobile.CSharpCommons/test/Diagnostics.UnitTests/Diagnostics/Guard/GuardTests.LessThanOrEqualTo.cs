using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.LessThanOrEqualTo")]
        public void LessThanOrEqualTo(string method)
        {
            GuardThrowsError(method,
                () => Guard.LessThanOrEqualTo(2, 1));

            GuardNotThrowsError(method,
                () => Guard.LessThanOrEqualTo(2, 2));
            GuardNotThrowsError(method,
                () => Guard.LessThanOrEqualTo(1, 2));
        }
    }
}