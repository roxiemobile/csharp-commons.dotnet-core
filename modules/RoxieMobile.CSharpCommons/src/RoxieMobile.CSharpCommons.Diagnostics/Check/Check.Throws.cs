using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods

//     /**
//      * This interface facilitates the use of expectThrows from Java 8. It allows method references
//      * to void methods (that declare checked exceptions) to be passed directly into expectThrows
//      * without wrapping. It is not meant to be implemented directly.
//      */
//     public interface ThrowingRunnable {
//         void run() throws Throwable;
//     }
// 
//     /**
//      * Checks that {@code runnable} throws an exception of type {@code expectedThrowable} when
//      * executed. If it does, the exception object is returned. If it does not throw an exception, an
//      * <see cref="CheckException"/> is thrown. If it throws the wrong type of exception, an {@code
//      * ExpectationException} is thrown describing the mismatch; the exception that was actually thrown can
//      * be obtained by calling {@link ExpectationException#getCause}.
//      *
//      * @param expectedThrowable The expected type of the exception
//      * @param runnable          A function that is expected to throw an exception when executed
//      * @return The exception thrown by {@code runnable}
//      */
//     public static <T extends Throwable> T expectThrows(final Class<T> expectedThrowable, final ThrowingRunnable runnable) {
//         try {
//             runnable.run();
//         }
//         catch (Throwable actualThrown)
//         {
//             if (expectedThrowable.isInstance(actualThrown)) {
//                 @SuppressWarnings("unchecked")
//                 T retVal = (T) actualThrown;
//                 return retVal;
//             }
//             else
//             {
//                 String mismatchMessage = format("Unexpected exception type thrown;",
//                         expectedThrowable.getSimpleName(), actualThrown.getClass().getSimpleName());
//                 throw new ExpectationException(mismatchMessage, actualThrown);
//             }
//         }
// 
//         String message = String.format("Expected %s to be thrown, but nothing was thrown", expectedThrowable.getSimpleName());
//         throw new ExpectationException(message);
//     }

        [Obsolete(Constants.NotImplemented)]
        public static void Throws(Type expectedException, Action action, string message = null)
        {
            throw new NotImplementedException();
        }

        [Obsolete(Constants.NotImplemented)]
        public static void Throws(Type expectedException, Action action, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            throw new NotImplementedException();
        }

//    static String format(final String message, final Object expected, final Object actual) {
//        String formatted = "";
//
//        if (message != null && !message.equals("")) {
//            formatted = message + " ";
//        }
//
//        String expectedString = String.valueOf(expected);
//        String actualString = String.valueOf(actual);
//
//        if (expectedString.equals(actualString)) {
//            return formatted + "expected: " + formatClassAndValue(expected, expectedString)
//                    + " but was: " + formatClassAndValue(actual, actualString);
//        }
//        else {
//            return formatted + "expected:<" + expectedString + "> but was:<" + actualString + ">";
//        }
//    }

//    private static String formatClassAndValue(final Object value, final String valueString) {
//        String className = (value == null) ? "null" : value.getClass().getName();
//        return className + "<" + valueString + ">";
//    }
    }
}