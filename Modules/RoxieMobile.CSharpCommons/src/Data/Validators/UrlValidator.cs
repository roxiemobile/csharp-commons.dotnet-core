using System;
using RoxieMobile.CSharpCommons.Abstractions.Validators;

namespace RoxieMobile.CSharpCommons.Data.Validators
{
    public sealed class UrlValidator : IValidator
    {
// MARK: - Construction

        public static UrlValidator Shared => _instance.Value;

        private static readonly Lazy<UrlValidator> _instance = new Lazy<UrlValidator>(() => new UrlValidator());

        private UrlValidator()
        {}

// MARK: - Methods

        public bool IsValid(object? value)
        {
            switch (value) {
                case string str: {
                    return _validator.IsValid(str);
                }
                case Uri obj: {
                    return _validator.IsValid(obj.AbsoluteUri);
                }
                default: {
                    return false;
                }
            }
        }

// MARK: - Constants

        // Regular expression strings for URLs
        // @formatter:off
        private const string UrlPattern = ""
            + "^"
                // Protocol identifier
                + "(?:(?:https?|ftp)://)"
                // User:Pass authentication
                + "(?:\\S+(?::\\S*)?@)?"
                + "(?:"
                    // IP address exclusion private & local networks
                    // + "(?!(?:10|127)(?:\\.\\d{1,3}){3})"
                    // + "(?!(?:169\\.254|192\\.168)(?:\\.\\d{1,3}){2})"
                    // + "(?!172\\.(?:1[6-9]|2\\d|3[0-1])(?:\\.\\d{1,3}){2})"

                    // IP address dotted notation octets
                    // excludes loopback network 0.0.0.0
                    // excludes reserved space >= 224.0.0.0
                    // excludes network & broadcast addresses (first & last IP address of each class)
                    + "(?:[1-9]\\d?|1\\d\\d|2[01]\\d|22[0-3])"
                    + "(?:\\.(?:1?\\d{1,2}|2[0-4]\\d|25[0-5])){2}"
                    + "(?:\\.(?:[1-9]\\d?|1\\d\\d|2[0-4]\\d|25[0-4]))"
                + "|"
                    // Host name
                    + "(?:(?:[a-z\\u00a1-\\uffff0-9]-*)*[a-z\\u00a1-\\uffff0-9]+)"
                    // Domain name
                    + "(?:\\.(?:[a-z\\u00a1-\\uffff0-9]-*)*[a-z\\u00a1-\\uffff0-9]+)*"
                    // TLD identifier
                    + "(?:\\.(?:[a-z\\u00a1-\\uffff]{2,}))"
                + ")"
                // Port number
                + "(?::\\d{2,5})?"
                // Resource path
                + "(?:/\\S*)?"
            + "$";
        // @formatter:on

        // RegexValidator for matching Emails
        private static readonly IValidator _validator = new RegexValidator(UrlPattern);
    }
}
