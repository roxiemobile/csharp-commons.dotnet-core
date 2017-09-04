using System;
using System.IO;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.ThrowsAny")]
        public void ThrowsAny(string method)
        {
            CheckThrowsException(method,
                () => Check.ThrowsAny<Exception>(() => {}));
            CheckThrowsException(method,
                () => Check.ThrowsAny<IOException>(() => throw new OperationCanceledException()));

            CheckNotThrowsException(method,
                () => Check.ThrowsAny<Exception>(() => throw new IOException()));
            CheckNotThrowsException(method,
                () => Check.ThrowsAny<IOException>(() => throw new IOException()));
        }
    }
}
