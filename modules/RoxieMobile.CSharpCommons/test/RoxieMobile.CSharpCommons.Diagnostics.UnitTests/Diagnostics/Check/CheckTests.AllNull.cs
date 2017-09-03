using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.AllNull")]
        [Obsolete(Constants.NotImplemented)]
        public void AllNull(string method)
        {
            throw new NotImplementedException();
        }
    }
}
