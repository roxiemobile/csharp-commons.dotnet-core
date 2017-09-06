using System;
using System.ComponentModel.DataAnnotations;

namespace RoxieMobile.CSharpCommons.DataAnnotations.Attributes
{
    public class MinValueAttribute : ValidationAttribute
    {
// MARK: - Construction

        public MinValueAttribute(long value)
        {
            // Init instance variables
            _minValue = value;
        }

// MARK: - Methods

        public override bool IsValid(object value) =>
            Convert.ToInt64(value) >= _minValue;

// MARK: - Variables

        private readonly long _minValue;
    }
}