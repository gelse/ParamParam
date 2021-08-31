using System;
using FluentAssertions;
using Xunit;
using ParamParam;

namespace ParamParamTests
{
    public class NotNullTests
    {
        [Fact]
        public void NotNull_ShouldThrow_OnNull()
        {
            object value = null;

            new Action(() => value.WithParam(nameof(value)).NotNull()).Should().ThrowExactly<ArgumentNullException>("NotNull should throw ArgumentNullException if value is null.");
        }
        
        [Fact]
        public void NotNull_ShouldThrow_OnNullWithCorrectMessage()
        {
            object value = null;

            new Action(() => value.WithParam(nameof(value)).NotNull()).Should().ThrowExactly<ArgumentNullException>()
                .WithMessage($"Parameter must not be null. (Parameter '{nameof(value)}')", "NotNull Exception message should describe which parameter is null.");
        }

        [Fact]
        public void NotNull_ShouldNotThrow_OnNotNull()
        {
            var value = new object();

            new Action(() => value.WithParam(nameof(value)).NotNull()).Should().NotThrow("NotNull should not throw null if object is not null");
        }
        
        private class TestClass
        {
            
        }

        [Fact]
        public void NotNull_ShouldNotThrow_OnNotNull_ReturnsInput()
        {
            var value = new TestClass();

            var result = value.WithParam(nameof(value)).NotNull();

            // the cast is necessary in this case, because of the implicit conversion.
            ((TestClass) result).Should().BeSameAs(value);
        }
    }
}