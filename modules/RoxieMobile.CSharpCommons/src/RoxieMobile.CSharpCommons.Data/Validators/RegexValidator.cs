using System.Text.RegularExpressions;
using RoxieMobile.CSharpCommons.Abstractions.Validators;

namespace RoxieMobile.CSharpCommons.Data.Validators
{
    public sealed class RegexValidator : IValidator
    {
// MARK: - Construction

        public RegexValidator(string pattern) =>
            _pattern = new Regex(pattern, RegexOptions.IgnoreCase);

// MARK: - Methods

        public bool IsValid(object value) =>
            (value is string str) && _pattern.IsMatch(str);

// MARK: - Variables

        private readonly Regex _pattern;
    }
}