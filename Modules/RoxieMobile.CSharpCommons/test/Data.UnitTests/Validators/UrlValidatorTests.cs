using System;
using RoxieMobile.CSharpCommons.Data.Validators;
using Xunit;

namespace RoxieMobile.CSharpCommons.Data.UnitTests.Validators
{
    public sealed class UrlValidatorTests
    {
        [Theory]
        [InlineData("https://google.com")]
        public void ValidUrls(string url)
        {
            Assert.True(UrlValidator.Shared.IsValid(url));

            var uri = new Uri(url);
            Assert.True(UrlValidator.Shared.IsValid(uri));
        }

        [Theory]
        [InlineData("file://path")]
        public void InvalidUrls(string url)
        {
            Assert.False(UrlValidator.Shared.IsValid(url));

            var uri = new Uri(url);
            Assert.False(UrlValidator.Shared.IsValid(uri));
        }
    }
}
