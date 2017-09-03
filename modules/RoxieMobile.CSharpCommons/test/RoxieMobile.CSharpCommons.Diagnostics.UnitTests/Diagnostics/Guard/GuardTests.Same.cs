using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.Same")]
        public void Same(string method)
        {
            const string value = "value";
            const string otherString = "otherValue";

            GuardThrowsError(method,
                () => Guard.Same(value, otherString));

            GuardNotThrowsError(method,
                () => Guard.Same(value, value));
        }
    }
}