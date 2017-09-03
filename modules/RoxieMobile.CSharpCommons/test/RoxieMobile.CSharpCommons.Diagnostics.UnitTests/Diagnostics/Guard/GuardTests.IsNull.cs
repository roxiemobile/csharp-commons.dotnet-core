using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.IsNull")]
        public void IsNull(string method)
        {
            GuardThrowsError(method,
                () => Guard.IsNull(2));

            GuardNotThrowsError(method,
                () => Guard.IsNull(null));
        }
    }
}