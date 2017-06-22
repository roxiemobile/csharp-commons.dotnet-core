using System;
using System.ComponentModel.DataAnnotations;

namespace RoxieMobile.CSharpCommons.DataAnnotations
{
    public class MaxValueAttribute : ValidationAttribute
    {
// MARK: - Construction

        public MaxValueAttribute(long value)
        {
            _maxValue = value;
        }

// MARK: - Methods

        public override bool IsValid(object value)
        {
            return _maxValue >= Convert.ToInt64(value);
        }

// MARK: - Variables

        private readonly long _maxValue;
    }
}
