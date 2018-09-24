using System;
using Xunit.Sdk;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Private Methods

        protected void GuardThrowsError<T>(string method, Type classOfT, Action action) where T : Exception
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
                    throw new XunitException($"{method}: Unknown error is thrown");
                }
            }
            else {
                throw new XunitException($"{method}: Method not thrown an error");
            }
        }

        protected void GuardThrowsError(string method, Action action) =>
            GuardThrowsError<GuardError>(method, typeof(GuardError), action);

// --

        protected void GuardNotThrowsError(string method, Type classOfT, Action action)
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
                    throw new XunitException($"{method}: Method thrown an error");
                }
                else {
                    throw new XunitException($"{method}: Unknown error is thrown");
                }
            }
            else {
                // Do nothing
            }
        }

        protected void GuardNotThrowsError(string method, Action action) =>
            GuardNotThrowsError(method, typeof(GuardError), action);

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
    }
}