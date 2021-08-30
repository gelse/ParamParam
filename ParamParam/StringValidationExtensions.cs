using System;

namespace ParamParam
{
    public static class StringValidationExtensions
    {
        public static ValidationResult<string> NotNullOrEmpty(this IValidation<string> validation)
        {
            TestHelper.Test(validation, string.IsNullOrEmpty, "Parameter must not be null or empty.");
            return new ValidationResult<string>(validation);
        }

        public static ValidationResult<string> NotNullOrWhitespace(this IValidation<string> validation)
        {
            TestHelper.Test(validation, string.IsNullOrWhiteSpace, "Parameter must not be null or whitespace.");
            return new ValidationResult<string>(validation);
        }
        
        private static Predicate<string> HttpUriTest = s => Uri.TryCreate(s, UriKind.Absolute, out var uriResult)
                                              && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        public static ValidationResult<string> Url(this IValidation<string> validation)
        {
            TestHelper.Test(validation, HttpUriTest, "Parameter must be a valid HTTP or HTTPS URI.");
            return new ValidationResult<string>(validation);
        }

        public static ValidationResult<string> MinLength(this IValidation<string> validation, int minLength)
        {
            TestHelper.Test(validation, s => s?.Length >= minLength, "Parameter must not be null or whitespace.");
            return new ValidationResult<string>(validation);
        }

        public static ValidationResult<string> MaxLength(this IValidation<string> validation, int minLength)
        {
            TestHelper.Test(validation, s => s?.Length <= minLength, "Parameter must not be null or whitespace.");
            return new ValidationResult<string>(validation);
        }
    }
}