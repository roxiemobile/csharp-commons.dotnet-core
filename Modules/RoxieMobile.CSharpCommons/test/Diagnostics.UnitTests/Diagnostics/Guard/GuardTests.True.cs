using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.True")]
        public void True(string method)
        {
            GuardThrowsError(method,
                () => Guard.True(1 > 2));

            GuardNotThrowsError(method,
                () => Guard.True(2 > 1));
        }
    }
}
