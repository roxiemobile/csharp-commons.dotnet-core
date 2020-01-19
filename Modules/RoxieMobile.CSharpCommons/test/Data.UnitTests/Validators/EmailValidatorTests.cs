using RoxieMobile.CSharpCommons.Data.Validators;
using Xunit;

namespace RoxieMobile.CSharpCommons.Data.UnitTests.Validators
{
    public sealed class EmailValidatorTests
    {
        [Theory]
        [InlineData("none@none.com")]
        public void ValidEmails(string email)
        {
            Assert.True(EmailValidator.Shared.IsValid(email));
        }

        [Theory]
        [InlineData("none^none.com")]
        public void InvalidEmails(string email)
        {
            Assert.False(EmailValidator.Shared.IsValid(email));
        }
    }
}
