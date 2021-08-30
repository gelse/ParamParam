using System;
using FluentAssertions;
using Xunit;
using ParamParam;

namespace ParamParamTests
{
    public class NotNullTests
    {
        [Fact]
        public void NotNullTest_Should_Throw_OnNull()
        {
            object value = null;
            var paramName = "foo";

            new Action(() => value.WithParam(paramName).NotNull()).Should().ThrowExactly<ArgumentNullException>("NotNullTest should throw ArgumentNullException if value is null.");
        }
        
        [Fact]
        public void NotNullTest_Should_Throw_OnNull_WithCorrectMessage()
        {
            object value = null;
            var paramName = "foo";

            new Action(() => value.WithParam(paramName).NotNull()).Should().ThrowExactly<ArgumentNullException>()
                .WithMessage($"Parameter must not be null. (Parameter '{paramName}')", "NotNullTest Exception message should describe which parameter is null.");
        }

        [Fact]
        public void NotNullTest_Should_Not_Throw_On_Not_Null()
        {
            object value = new object();
            var paramName = "foo";

            new Action(() => value.WithParam(paramName).NotNull()).Should().NotThrow("NotNullTest should not throw null if object is not null");
        }
    }
}