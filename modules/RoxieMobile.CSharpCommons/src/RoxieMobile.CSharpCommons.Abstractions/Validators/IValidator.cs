using System;

namespace RoxieMobile.CSharpCommons.Abstractions.Validators
{
    public interface IValidator
    {
        [Obsolete("Write a description.")]
        bool IsValid(object value);
    }
}