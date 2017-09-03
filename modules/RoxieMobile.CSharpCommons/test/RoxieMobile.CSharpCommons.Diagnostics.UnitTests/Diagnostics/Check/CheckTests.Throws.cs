using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.Throws")]
        [Obsolete(Constants.NotImplemented)]
        public void Throws(string method)
        {
            throw new NotImplementedException();
        }
    }
}
