using System;
using System.ComponentModel.DataAnnotations;

namespace RoxieMobile.CSharpCommons.DataAnnotations
{
    public class MinValueAttribute : ValidationAttribute
    {
// MARK: - Construction

        public MinValueAttribute(long value)
        {
            _minValue = value;
        }

// MARK: - Methods

        public override bool IsValid(object value)
        {
            return Convert.ToInt64(value) >= _minValue;
        }

// MARK: - Variables

        private readonly long _minValue;
    }
}
