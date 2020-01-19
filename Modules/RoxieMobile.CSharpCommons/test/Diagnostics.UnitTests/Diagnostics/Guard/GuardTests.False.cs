using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.False")]
        public void False(string method)
        {
            GuardThrowsError(method,
                () => Guard.False(2 > 1));

            GuardNotThrowsError(method,
                () => Guard.False(1 > 2));
        }
    }
}
