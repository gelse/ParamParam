namespace ParamParam
{
    public static class IntValidationExtensions
    {
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