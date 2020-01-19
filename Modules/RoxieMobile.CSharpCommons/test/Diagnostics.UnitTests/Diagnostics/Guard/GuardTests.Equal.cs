using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.Equal")]
        public void Equal(string method)
        {
            const string value = "value";
            const string? nilValue = null;


            GuardThrowsError(method,
                () => Guard.Equal(1, 2));
            GuardThrowsError(method,
                () => Guard.Equal(value, nilValue));

            GuardNotThrowsError(method,
                () => Guard.Equal(2, 2));
            GuardNotThrowsError(method,
                () => Guard.Equal(value, value));
        }
    }
}
