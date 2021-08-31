using System;
using System.Text.RegularExpressions;

namespace ParamParam
{
    public static class StringValidationExtensions
    {
        public static ValidationResult<string> NotNullOrEmpty(this IValidation<string> validation)
        {
            TestHelper.Test(validation, s => !string.IsNullOrEmpty(s), "Parameter must not be null or empty.");
            return new ValidationResult<string>(validation);
        }

        public static ValidationResult<string> NotNullOrWhitespace(this IValidation<string> validation)
        {
            TestHelper.Test(validation, s => !string.IsNullOrWhiteSpace(s), "Parameter must not be null or whitespace.");
            return new ValidationResult<string>(validation);
        }
        
        private static Predicate<string> HttpUriTest = s => Uri.TryCreate(s, UriKind.Absolute, out var uriResult)
                                              && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        public static ValidationResult<string> Url(this IValidation<string> validation)
        {
            TestHelper.Test(validation, HttpUriTest, "Parameter must be a valid HTTP or HTTPS URI.");
            return new ValidationResult<string>(validation);
        }

        public static ValidationResult<string> Regex(this IValidation<string> validation, string regex)
        {
            // notice: Regex.IsMatch has an internal cache for the pattern - no need to do something ourself.
            TestHelper.Test(validation, s => System.Text.RegularExpressions.Regex.IsMatch(s, regex), $"Parameter must match regular expression /{regex}/.");
            return new ValidationResult<string>(validation);
        }
    }
}