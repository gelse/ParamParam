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
    }
}