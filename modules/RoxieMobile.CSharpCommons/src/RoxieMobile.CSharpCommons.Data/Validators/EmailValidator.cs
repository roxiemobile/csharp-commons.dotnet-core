using System;
using RoxieMobile.CSharpCommons.Abstractions.Validators;

namespace RoxieMobile.CSharpCommons.Data.Validators
{
    public sealed class EmailValidator : IValidator
    {
// MARK: - Construction

        public static EmailValidator Shared => _instance.Value;

        private static readonly Lazy<EmailValidator> _instance = new Lazy<EmailValidator>(() => new EmailValidator());

        private EmailValidator()
        {}

// MARK: - Methods

        public bool IsValid(object value) =>
            _validator.IsValid(value);

// MARK: - Constants

        // Regular expression strings for Emails
        // @formatter:off
        private const string EmailPattern = ""
            + "^"
                + "[a-zA-Z0-9_\\.\\%\\-\\+]{1,256}"
                + "\\@"
                + "[a-zA-Z0-9][a-zA-Z0-9\\-]{0,64}"
                + "(\\.[a-zA-Z0-9][a-zA-Z0-9\\-]{0,25})*"
            + "$";
        // @formatter:on

        // RegexValidator for matching Emails
        private static readonly IValidator _validator = new RegexValidator(EmailPattern);
    }
}