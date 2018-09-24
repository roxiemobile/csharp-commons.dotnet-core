using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.NotNull")]
        public void NotNull(string method)
        {
            GuardThrowsError(method,
                () => Guard.NotNull(null));

            GuardNotThrowsError(method,
                () => Guard.NotNull(2));
        }
    }
}