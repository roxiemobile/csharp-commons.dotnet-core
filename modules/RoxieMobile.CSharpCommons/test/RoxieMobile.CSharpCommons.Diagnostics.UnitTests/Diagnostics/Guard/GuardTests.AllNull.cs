using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.AllNull")]
        [Obsolete(Constants.NotImplemented)]
        public void AllNull(string method)
        {
            throw new NotImplementedException();
        }
    }
}
