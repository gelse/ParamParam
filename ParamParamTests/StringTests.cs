using System;
using FluentAssertions;
using ParamParam;
using Xunit;

namespace ParamParamTests
{
    public class StringTests
    {
        [Fact]
        public void NotNullOrEmpty_ShouldThrow_OnNull()
        {
            string value = null;
            new Action(() => value.WithParam(nameof(value)).NotNullOrEmpty()).Should().ThrowExactly<ArgumentException>("NotNullOrEmpty should throw ArgumentException.");
        }
        
        [Fact]
        public void NotNullOrEmpty_ShouldThrow_OnNullWithMessage()
        {
            string value = null;
            new Action(() => value.WithParam(nameof(value)).NotNullOrEmpty()).Should().ThrowExactly<ArgumentException>().WithMessage($"Parameter must not be null or empty. (Parameter '{nameof(value)}')", "NotNullOrEmpty should throw ArgumentException with correct message.");
        }
    }
}