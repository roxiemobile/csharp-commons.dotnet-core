using System;
using System.IO;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.ThrowsAny")]
        public void ThrowsAny(string method)
        {
            GuardThrowsError(method,
                () => Guard.ThrowsAny<Exception>(() => {}));
            GuardThrowsError(method,
                () => Guard.ThrowsAny<IOException>(() => throw new OperationCanceledException()));

            GuardNotThrowsError(method,
                () => Guard.ThrowsAny<Exception>(() => throw new IOException()));
            GuardNotThrowsError(method,
                () => Guard.ThrowsAny<IOException>(() => throw new IOException()));
        }
    }
}
