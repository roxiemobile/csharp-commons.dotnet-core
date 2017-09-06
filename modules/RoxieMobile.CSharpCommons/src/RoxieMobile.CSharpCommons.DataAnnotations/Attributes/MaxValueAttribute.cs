using System;
using System.ComponentModel.DataAnnotations;

namespace RoxieMobile.CSharpCommons.DataAnnotations.Attributes
{
    public class MaxValueAttribute : ValidationAttribute
    {
// MARK: - Construction

        public MaxValueAttribute(long value)
        {
            // Init instance variables
            _maxValue = value;
        }

// MARK: - Methods

        public override bool IsValid(object value) =>
            _maxValue >= Convert.ToInt64(value);

// MARK: - Variables

        private readonly long _maxValue;
    }
}