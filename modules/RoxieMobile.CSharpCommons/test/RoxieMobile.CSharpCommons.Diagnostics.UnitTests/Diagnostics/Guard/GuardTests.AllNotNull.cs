using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.AllNotNull")]
        [Obsolete(Constants.NotImplemented)]
        public void AllNotNull(string method)
        {
            throw new NotImplementedException();
        }
    }
}
