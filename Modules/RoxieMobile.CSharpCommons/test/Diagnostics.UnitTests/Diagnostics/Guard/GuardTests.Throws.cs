using System;
using System.IO;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.Throws")]
        public void Throws(string method)
        {
            GuardThrowsError(method,
                () => Guard.Throws<Exception>(() => {}));
            GuardThrowsError(method,
                () => Guard.Throws<IOException>(() => throw new OperationCanceledException()));
            GuardThrowsError(method,
                () => Guard.Throws<Exception>(() => throw new IOException()));

            GuardNotThrowsError(method,
                () => Guard.Throws<IOException>(() => throw new IOException()));
        }
    }
}
