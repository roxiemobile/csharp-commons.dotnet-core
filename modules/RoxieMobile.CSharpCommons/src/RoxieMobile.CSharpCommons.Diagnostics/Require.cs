using static RoxieMobile.CSharpCommons.Diagnostics.Expect;

// package com.roxiemobile.androidcommons.diagnostics;
// 
// import android.support.annotation.NonNull;
// 
// import com.roxiemobile.androidcommons.data.model.Validatable;
// 
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectEqual;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectFalse;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNotEmpty;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNotEqual;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNotNull;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNotValid;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNotBlank;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNull;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNullOrEmpty;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNullOrNotValid;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNullOrValid;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectNullOrWhitespace;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectTrue;
// import static com.roxiemobile.androidcommons.diagnostics.Expect.expectValid;
// 
// public final class Require
// {
// // MARK: - Construction
// 
//     private Require() {
//         // Do nothing
//     }
// 
// // MARK: - Methods
// 
//     public static void requireTrue(boolean condition, String message) {
//         rethrowOnFailure(message, () -> expectTrue(condition));
//     }
// 
//     public static void requireTrue(boolean condition) {
//         requireTrue(condition, null);
//     }
// 
//     public static void requireFalse(boolean condition, String message) {
//         rethrowOnFailure(message, () -> expectFalse(condition));
//     }
// 
//     public static void requireFalse(boolean condition) {
//         requireFalse(condition, null);
//     }
// 
// // MARK: - Methods
// 
//     public static void requireEqual(Object expected, Object actual, String message) {
//         rethrowOnFailure(message, () -> expectEqual(expected, actual));
//     }
// 
//     public static void requireEqual(Object expected, Object actual) {
//         requireEqual(expected, actual, null);
//     }
// 
//     public static void requireNotEqual(Object unexpected, Object actual, String message) {
//         rethrowOnFailure(message, () -> expectNotEqual(unexpected, actual));
//     }
// 
//     public static void requireNotEqual(Object unexpected, Object actual) {
//         requireNotEqual(unexpected, actual, null);
//     }
// 
// // MARK: - Methods
// 
//     public static void requireNull(Object object, String message) {
//         rethrowOnFailure(message, () -> expectNull(object));
//     }
// 
//     public static void requireNull(Object object) {
//         requireNull(object, null);
//     }
// 
//     public static void requireNotNull(Object object, String message) {
//         rethrowOnFailure(message, () -> expectNotNull(object));
//     }
// 
//     public static void requireNotNull(Object object) {
//         requireNotNull(object, null);
//     }
// 
// // MARK: - Methods
// 
//     public static void requireNullOrEmpty(CharSequence str, String message) {
//         rethrowOnFailure(message, () -> expectNullOrEmpty(str));
//     }
// 
//     public static void requireNullOrEmpty(CharSequence str) {
//         requireNullOrEmpty(str, null);
//     }
// 
//     public static void requireNullOrEmpty(@NonNull CharSequence[] values, String message) {
//         rethrowOnFailure(message, () -> expectNullOrEmpty(values));
//     }
// 
//     public static void requireNullOrEmpty(@NonNull CharSequence[] values) {
//         requireNullOrEmpty(values, null);
//     }
// 
//     public static void requireNotEmpty(CharSequence str, String message) {
//         rethrowOnFailure(message, () -> expectNotEmpty(str));
//     }
// 
//     public static void requireNotEmpty(CharSequence str) {
//         requireNotEmpty(str, null);
//     }
// 
//     public static void requireNotEmpty(@NonNull CharSequence[] values, String message) {
//         rethrowOnFailure(message, () -> expectNotEmpty(values));
//     }
// 
//     public static void requireNotEmpty(@NonNull CharSequence[] values) {
//         requireNotEmpty(values, null);
//     }
// 
// // MARK: - Methods
// 
//     public static void requireNullOrWhitespace(CharSequence str, String message) {
//         rethrowOnFailure(message, () -> expectNullOrWhitespace(str));
//     }
// 
//     public static void requireNullOrWhitespace(CharSequence str) {
//         requireNullOrWhitespace(str, null);
//     }
// 
//     public static void requireNullOrWhitespace(@NonNull CharSequence[] values, String message) {
//         rethrowOnFailure(message, () -> expectNullOrWhitespace(values));
//     }
// 
//     public static void requireNullOrWhitespace(@NonNull CharSequence[] values) {
//         requireNullOrWhitespace(values, null);
//     }
// 
//     public static void requireNotBlank(CharSequence str, String message) {
//         rethrowOnFailure(message, () -> expectNotBlank(str));
//     }
// 
//     public static void requireNotBlank(CharSequence str) {
//         requireNotBlank(str, null);
//     }
// 
//     public static void requireNotBlank(@NonNull CharSequence[] values, String message) {
//         rethrowOnFailure(message, () -> expectNotBlank(values));
//     }
// 
//     public static void requireNotBlank(@NonNull CharSequence[] values) {
//         requireNotBlank(values, null);
//     }
// 
// // MARK: - Methods
// 
//     public static void requireValid(Validatable obj, String message) {
//         rethrowOnFailure(message, () -> expectValid(obj));
//     }
// 
//     public static void requireValid(Validatable obj) {
//         requireValid(obj, null);
//     }
// 
//     public static void requireValid(@NonNull Validatable[] objects, String message) {
//         rethrowOnFailure(message, () -> expectValid(objects));
//     }
// 
//     public static void requireValid(@NonNull Validatable[] objects) {
//         requireValid(objects, null);
//     }
// 
//     public static void requireNotValid(Validatable obj, String message) {
//         rethrowOnFailure(message, () -> expectNotValid(obj));
//     }
// 
//     public static void requireNotValid(Validatable obj) {
//         requireNotValid(obj, null);
//     }
// 
//     public static void requireNotValid(@NonNull Validatable[] objects, String message) {
//         rethrowOnFailure(message, () -> expectNotValid(objects));
//     }
// 
//     public static void requireNotValid(@NonNull Validatable[] objects) {
//         requireNotValid(objects, null);
//     }
// 
// // MARK: - Methods
// 
//     public static void requireNullOrValid(Validatable obj, String message) {
//         rethrowOnFailure(message, () -> expectNullOrValid(obj));
//     }
// 
//     public static void requireNullOrValid(Validatable obj) {
//         requireNullOrValid(obj, null);
//     }
// 
//     public static void requireNullOrValid(@NonNull Validatable[] objects, String message) {
//         rethrowOnFailure(message, () -> expectNullOrValid(objects));
//     }
// 
//     public static void requireNullOrValid(@NonNull Validatable[] objects) {
//         requireNullOrValid(objects, null);
//     }
// 
//     public static void requireNullOrNotValid(Validatable obj, String message) {
//         rethrowOnFailure(message, () -> expectNullOrNotValid(obj));
//     }
// 
//     public static void requireNullOrNotValid(Validatable obj) {
//         requireNullOrNotValid(obj, null);
//     }
// 
//     public static void requireNullOrNotValid(@NonNull Validatable[] objects, String message) {
//         rethrowOnFailure(message, () -> expectNullOrNotValid(objects));
//     }
// 
//     public static void requireNullOrNotValid(@NonNull Validatable[] objects) {
//         requireNullOrNotValid(objects, null);
//     }
// 
// // MARK: - Private Methods
// 
//     private static void rethrowOnFailure(String message, Runnable task) {
//         if (task == null) {
//             throw new NullPointerException();
//         }
// 
//         try {
//             task.run();
//         }
//         catch (ExpectationException e) {
//             throwError(message, e);
//         }
//     }
// 
//     private static void throwError(String message, Throwable cause) {
//         if (message == null) {
//             throw new RequirementError(cause);
//         }
//         throw new RequirementError(message, cause);
//     }
// 
// }

using System;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    public static class Require
    {
// MARK: - Methods

        public static void RequireTrue(bool condition, string message = null) {
            RethrowOnFailure(message, () => ExpectTrue(condition));
        }

        public static void RequireFalse(bool condition, string message = null) {
            RethrowOnFailure(message, () => ExpectFalse(condition));
        }

// MARK: - Methods
//
//     public static void requireEqual(Object expected, Object actual, String message) {
//         rethrowOnFailure(message, () -> expectEqual(expected, actual));
//     }
//
//     public static void requireEqual(Object expected, Object actual) {
//         requireEqual(expected, actual, null);
//     }
//
//     public static void requireNotEqual(Object unexpected, Object actual, String message) {
//         rethrowOnFailure(message, () -> expectNotEqual(unexpected, actual));
//     }
//
//     public static void requireNotEqual(Object unexpected, Object actual) {
//         requireNotEqual(unexpected, actual, null);
//     }

// MARK: - Methods

        public static void RequireNull(object obj, string message = null) {
            RethrowOnFailure(message, () => ExpectNull(obj));
        }

        public static void RequireNotNull(object obj, string message = null) {
            RethrowOnFailure(message, () => ExpectNotNull(obj));
        }

// MARK: - Methods

        public static void RequireNullOrEmpty(string str, string message = null) {
            RethrowOnFailure(message, () => ExpectNullOrEmpty(str));
        }

// FIXME: Uncomment!
//        public static void RequireNullOrEmpty(string[] values, string message = null) {
//            RethrowOnFailure(message, () => ExpectNullOrEmpty(values));
//        }

        public static void RequireNotEmpty(string str, string message = null) {
            RethrowOnFailure(message, () => ExpectNotEmpty(str));
        }

// FIXME: Uncomment!
//        public static void RequireNotEmpty(string[] values, string message = null) {
//            RethrowOnFailure(message, () => ExpectNotEmpty(values));
//        }

// MARK: - Methods

//     public static void requireNullOrWhitespace(CharSequence str, String message) {
//         rethrowOnFailure(message, () -> expectNullOrWhitespace(str));
//     }
//
//     public static void requireNullOrWhitespace(CharSequence str) {
//         requireNullOrWhitespace(str, null);
//     }
//
//     public static void requireNullOrWhitespace(@NonNull CharSequence[] values, String message) {
//         rethrowOnFailure(message, () -> expectNullOrWhitespace(values));
//     }
//
//     public static void requireNullOrWhitespace(@NonNull CharSequence[] values) {
//         requireNullOrWhitespace(values, null);
//     }

        public static void RequireNotBlank(string str, string message = null) {
            RethrowOnFailure(message, () => ExpectNotBlank(str));
        }

//     public static void requireNotBlank(CharSequence str) {
//         requireNotBlank(str, null);
//     }
//
//     public static void requireNotBlank(@NonNull CharSequence[] values, String message) {
//         rethrowOnFailure(message, () -> expectNotBlank(values));
//     }
//
//     public static void requireNotBlank(@NonNull CharSequence[] values) {
//         requireNotBlank(values, null);
//     }
//
// // MARK: - Methods
//
//     public static void requireValid(Validatable obj, String message) {
//         rethrowOnFailure(message, () -> expectValid(obj));
//     }
//
//     public static void requireValid(Validatable obj) {
//         requireValid(obj, null);
//     }
//
//     public static void requireValid(@NonNull Validatable[] objects, String message) {
//         rethrowOnFailure(message, () -> expectValid(objects));
//     }
//
//     public static void requireValid(@NonNull Validatable[] objects) {
//         requireValid(objects, null);
//     }
//
//     public static void requireNotValid(Validatable obj, String message) {
//         rethrowOnFailure(message, () -> expectNotValid(obj));
//     }
//
//     public static void requireNotValid(Validatable obj) {
//         requireNotValid(obj, null);
//     }
//
//     public static void requireNotValid(@NonNull Validatable[] objects, String message) {
//         rethrowOnFailure(message, () -> expectNotValid(objects));
//     }
//
//     public static void requireNotValid(@NonNull Validatable[] objects) {
//         requireNotValid(objects, null);
//     }
//
// // MARK: - Methods
//
//     public static void requireNullOrValid(Validatable obj, String message) {
//         rethrowOnFailure(message, () -> expectNullOrValid(obj));
//     }
//
//     public static void requireNullOrValid(Validatable obj) {
//         requireNullOrValid(obj, null);
//     }
//
//     public static void requireNullOrValid(@NonNull Validatable[] objects, String message) {
//         rethrowOnFailure(message, () -> expectNullOrValid(objects));
//     }
//
//     public static void requireNullOrValid(@NonNull Validatable[] objects) {
//         requireNullOrValid(objects, null);
//     }
//
//     public static void requireNullOrNotValid(Validatable obj, String message) {
//         rethrowOnFailure(message, () -> expectNullOrNotValid(obj));
//     }
//
//     public static void requireNullOrNotValid(Validatable obj) {
//         requireNullOrNotValid(obj, null);
//     }
//
//     public static void requireNullOrNotValid(@NonNull Validatable[] objects, String message) {
//         rethrowOnFailure(message, () -> expectNullOrNotValid(objects));
//     }
//
//     public static void requireNullOrNotValid(@NonNull Validatable[] objects) {
//         requireNullOrNotValid(objects, null);
//     }

// MARK: - Private Methods

        // FIXME
        private static void RethrowOnFailure(string message, Action task)
        {
            if (task == null) {
                throw new NullReferenceException();
            }

            try {
                task();
            }
            catch (ExpectationException e) {
                ThrowError(message, e);
            }
        }

        // FIXME
        private static void ThrowError(string message, Exception cause)
        {
            if (message == null) {
                throw new RequirementError(cause);
            }
            throw new RequirementError(message, cause);
        }
    }
}
