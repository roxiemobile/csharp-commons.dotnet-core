using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.Null")]
        public void Null(string method)
        {
            GuardThrowsError(method,
                () => Guard.Null(2));

            GuardNotThrowsError(method,
                () => Guard.Null(null));
        }
    }
}
