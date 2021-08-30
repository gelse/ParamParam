namespace ParamParam
{
    public class ValidationResult<T> : IValidation<T>
    {
        private Validation<T> Validation { get; }

        public ValidationResult(IValidation<T> validation)
        {
            Validation = (Validation<T>)validation;
        }

        public static implicit operator T(ValidationResult<T> validationResult) => validationResult.Validation.Value;

        public static implicit operator Validation<T>(ValidationResult<T> validationResult) =>
            validationResult.Validation;
    }
}