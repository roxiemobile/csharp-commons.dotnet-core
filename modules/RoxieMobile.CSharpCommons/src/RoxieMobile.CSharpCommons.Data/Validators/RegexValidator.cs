// FIXME: Delete!
/*
public class RegexValidator: Validator
{
// MARK: - Construction

    public init?(_ pattern: String, options: NSRegularExpression.Options = .caseInsensitive)
    {
        // Init instance variables
        self.regex = try? NSRegularExpression(pattern: pattern, options: options)

        // Validate instance
        if pattern.isEmpty || (self.regex == nil) {
            return nil
        }
    }

// MARK: - Methods

    public func isValid(_ value: Any?) -> Bool {
        var result = false

        // Validate incoming value
        if let str = (value as? String) {
            let matches = self.regex.matches(in: str, options: [], range: NSMakeRange(0, str.length))
            result = (matches.count > 0)
        }

        // Done
        return result
    }

// MARK: - Variables

    private let regex: NSRegularExpression!
}
*/

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