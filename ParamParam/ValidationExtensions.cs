using System;
using System.Diagnostics.CodeAnalysis;

namespace ParamParam
{
    internal static class TestHelper
    {
        public static void Test<T>(IValidation<T> validationInterface, [NotNull] Predicate<T> test, string failmessage, Func<string, string, ArgumentException> createException = null)
        {
            createException ??= ((message, parameterName) => new ArgumentException(message, parameterName)); 
            var validation = ((Validation<T>) validationInterface);
            var value = validation.Value;
            var success = test(value);
            if (!success)
            {
                throw createException(failmessage, validation.ParamName);
            }
        }
    }
    
    public static class ValidationExtensions
    {
        public static IValidation<T> WithParam<T>(this T value, string paramName)
        {
            return new Validation<T>(value, paramName);
        }

        public static ValidationResult<T> NotNull<T>(this IValidation<T> validation)
        {
            TestHelper.Test(validation, o => o != null, "Parameter must not be null.", (message, parameterName) => new ArgumentNullException(message, parameterName));
            return new ValidationResult<T>(validation);
        }
    }
}