using System;
using System.Runtime.CompilerServices;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    public static partial class Funcs
    {
// Guard.AllBlank.cs
// Guard.AllEmpty.cs
// Guard.AllNotBlank.cs
// Guard.AllNotEmpty.cs
// Guard.AllNotNull.cs
// Guard.AllNotValid.cs
// Guard.AllNull.cs
// Guard.AllNullOrNotValid.cs
// Guard.AllNullOrValid.cs

        // Guard.AllValid.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NotAllValid(string name) =>
            () => $"Some objects of ‘{name}’ is invalid";

        // Guard.Blank.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> Blank(string name) =>
            () => $"‘{name}’ is blank";

        // Guard.Empty.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> Empty(string name) =>
            () => $"‘{name}’ is empty";

        // Guard.Equal.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> Equal(string name, string otherName) =>
            () => $"‘{name}’ and ‘{otherName}’ is equal";

        // Guard.False.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> False() =>
            () => "Condition is FALSE";

        // Guard.GreaterThan.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> GreaterThan<T>(string name, T value) =>
            () => $"‘{name}’ is greater than ‘{value}’";

        // Guard.GreaterThanOrEqualTo.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> GreaterThanOrEqualTo<T>(string name, T value) =>
            () => $"‘{name}’ is greater than or equal to ‘{value}’";

        // Guard.LessThan.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> LessThan<T>(string name, T value) =>
            () => $"‘{name}’ is less than ‘{value}’";

        // Guard.LessThanOrEqualTo.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> LessThanOrEqualTo<T>(string name, T value) =>
            () => $"‘{name}’ is less than or equal to ‘{value}’";

        // Guard.NotBlank.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NotBlank(string name) =>
            () => $"‘{name}’ is not blank";

        // Guard.NotEmpty.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NotEmpty(string name) =>
            () => $"‘{name}’ is not empty";

        // Guard.NotEqual.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NotEqual(string name, string otherName) =>
            () => $"‘{name}’ and ‘{otherName}’ is not equal";

        // Guard.NotNull.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NotNull(string name) =>
            () => $"‘{name}’ is not null";

        // Guard.NotSame.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NotSame(string name, string otherName) =>
            () => $"‘{otherName}’ is not the same as ‘{name}’";

        // Guard.NotValid.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NotValid(string name) =>
            () => $"‘{name}’ is invalid";

        // Guard.Null.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> Null(string name) =>
            () => $"‘{name}’ is null";

        // Guard.NullOrNotValid.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NullOrNotValid(string name) =>
            () => $"‘{name}’ is null or not valid";

        // Guard.NullOrValid.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NullOrValid(string name) =>
            () => $"‘{name}’ is null or valid";

        // Guard.Same.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> Same(string name, string otherName) =>
            () => $"‘{otherName}’ is the same as ‘{name}’";

// Guard.Throws.cs
// Guard.ThrowsAny.cs

        // Guard.True.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> True() =>
            () => "Condition is TRUE";

        // Guard.Valid.cs
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> Valid(string name) =>
            () => $"‘{name}’ is valid";
    }

    public static partial class Funcs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> LengthIsGreaterThan<T>(string name, T value) =>
            () => "Length of " + GreaterThan(name, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> LengthIsGreaterThanOrEqualTo<T>(string name, T value) =>
            () => "Length of " + GreaterThanOrEqualTo(name, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> LengthIsLessThan<T>(string name, T value) =>
            () => "Length of " + LessThan(name, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> LengthIsLessThanOrEqualTo<T>(string name, T value) =>
            () => "Length of " + LessThanOrEqualTo(name, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> LengthIsEqual<T>(string name, T value) =>
            () => $"Length of ‘{name}’ is equal to ‘{value}’";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> LengthIsNotEqual<T>(string name, T value) =>
            () => $"Length of ‘{name}’ is not equal to ‘{value}’";
    }

    public static partial class Funcs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<string> NotEqualTo<T>(string name, T value) =>
            () => $"‘{name}’ is not equal to ‘{value}’";
    }
}
