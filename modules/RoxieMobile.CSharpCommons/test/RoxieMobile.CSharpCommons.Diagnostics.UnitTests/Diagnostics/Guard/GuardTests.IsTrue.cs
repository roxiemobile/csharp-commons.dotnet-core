using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.IsTrue")]
        public void IsTrue(string method)
        {
            GuardThrowsError(method,
                () => Guard.IsTrue(1 > 2));

            GuardNotThrowsError(method,
                () => Guard.IsTrue(2 > 1));
        }
    }
}