using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.NotEqual")]
        public void NotEqual(string method)
        {
            const string value = "value";
            const string? nilValue = null;


            GuardThrowsError(method,
                () => Guard.NotEqual(2, 2));
            GuardThrowsError(method,
                () => Guard.NotEqual(value, value));

            GuardNotThrowsError(method,
                () => Guard.NotEqual(1, 2));
            GuardNotThrowsError(method,
                () => Guard.NotEqual(value, nilValue));
        }
    }
}
