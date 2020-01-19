using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.LessThan")]
        public void LessThan(string method)
        {
            GuardThrowsError(method,
                () => Guard.LessThan(2, 1));
            GuardThrowsError(method,
                () => Guard.LessThan(2, 1));

            GuardNotThrowsError(method,
                () => Guard.LessThan(1, 2));
        }
    }
}
