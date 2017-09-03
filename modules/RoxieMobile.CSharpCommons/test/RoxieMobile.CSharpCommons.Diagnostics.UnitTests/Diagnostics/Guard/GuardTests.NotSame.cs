using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.NotSame")]
        public void NotSame(string method)
        {
            const string value = "value";
            const string otherString = "otherValue";

            GuardThrowsError(method,
                () => Guard.NotSame(value, value));

            GuardNotThrowsError(method,
                () => Guard.NotSame(value, otherString));
        }
    }
}