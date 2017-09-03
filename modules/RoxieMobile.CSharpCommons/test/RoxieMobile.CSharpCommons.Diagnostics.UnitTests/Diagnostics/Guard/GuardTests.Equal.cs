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
            const string nilString = null;


            GuardThrowsError(method,
                () => Guard.Equal(1, 2));
            GuardThrowsError(method,
                () => Guard.Equal(value, nilString));

            GuardNotThrowsError(method,
                () => Guard.Equal(2, 2));
            GuardNotThrowsError(method,
                () => Guard.Equal(value, value));
        }
    }
}