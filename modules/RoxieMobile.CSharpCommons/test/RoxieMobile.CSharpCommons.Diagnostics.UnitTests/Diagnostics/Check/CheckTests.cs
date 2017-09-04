using System;
using System.IO;
using RoxieMobile.CSharpCommons.Extensions;
using Xunit.Sdk;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Private Methods

        protected void CheckThrowsException(string method, Type classOfT, Action action)
        {
            CheckArgument(!string.IsNullOrEmpty(method), () => $"{nameof(method)} is empty");
            CheckArgument(classOfT != null, () => $"{nameof(classOfT)} is null");
            CheckArgument(action != null, () => $"{nameof(action)} is null");

            Exception cause = null;
            try {
                action?.Invoke();
            }
            catch (Exception e) {
                cause = e;
            }

            if (cause != null) {
                if (cause.GetType() == classOfT) {
                    // Do nothing
                }
                else {
                    throw new XunitException($"{method}: Unknown exception is thrown");
                }
            }
            else {
                throw new XunitException($"{method}: Method not thrown an exception");
            }
        }

        protected void CheckThrowsException(string method, Action action) =>
            CheckThrowsException(method, typeof(CheckException), action);

// --

        protected void CheckNotThrowsException(string method, Type classOfT, Action action)
        {
            CheckArgument(!string.IsNullOrEmpty(method), () => $"{nameof(method)} is empty");
            CheckArgument(classOfT != null, () => $"{nameof(classOfT)} is null");
            CheckArgument(action != null, () => $"{nameof(action)} is null");

            Exception cause = null;
            try {
                action?.Invoke();
            }
            catch (Exception e) {
                cause = e;
            }

            if (cause != null) {
                if (cause.GetType() == classOfT) {
                    throw new XunitException($"{method}: Method thrown an exception");
                }
                else {
                    throw new XunitException($"{method}: Unknown exception is thrown");
                }
            }
            else {
                // Do nothing
            }
        }

        protected void CheckNotThrowsException(string method, Action action) =>
            CheckNotThrowsException(method, typeof(CheckException), action);

// --

        protected void CheckArgument(bool condition, Func<string> block)
        {
            if (condition) {
                return;
            }

            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }
            throw new ArgumentException(block());
        }

// MARK: - Private Methods

        protected string LoadJsonString(string filename)
        {
            if (filename.IsEmpty()) {
                throw new ArgumentException(nameof(filename));
            }

            var fixturePath = $"Fixtures/{filename}.json";
            var filePath = Path.Combine(AppContext.BaseDirectory, fixturePath);

            return File.ReadAllText(filePath);
        }
    }
}