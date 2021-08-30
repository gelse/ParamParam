using System;

namespace ParamParam
{
    public interface IValidation<T>
    {
        // NOOP
    }

    public class Validation<T> : IValidation<T>
    {
        public T Value { get; }
        public string ParamName { get; }

        public Validation(T value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramName))
                throw new ArgumentException("{paramName} must not be null or empty.", nameof(paramName));
            Value = value;
            ParamName = paramName;
        }
    }
}