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
            new Action(() => value.WithParam(nameof(value)).NotNullOrEmpty())
                .Should().ThrowExactly<ArgumentException>("NotNullOrEmpty should throw ArgumentException.");
        }
        
        [Fact]
        public void NotNullOrEmpty_ShouldThrow_OnNullWithMessage()
        {
            string value = null;
            new Action(() => value.WithParam(nameof(value)).NotNullOrEmpty())
                .Should().ThrowExactly<ArgumentException>().WithMessage($"Parameter must not be null or empty. (Parameter '{nameof(value)}')", "NotNullOrEmpty should throw ArgumentException with correct message.");
        }
        
        [Fact]
        public void NotNullOrEmpty_ShouldThrow_OnEmpty()
        {
            var value = string.Empty;
            new Action(() => value.WithParam(nameof(value)).NotNullOrEmpty())
                .Should().ThrowExactly<ArgumentException>("NotNullOrEmpty should throw ArgumentException.");
        }
        
        [Fact]
        public void NotNullOrEmpty_ShouldThrow_OnEmptyWithMessage()
        {
            var value = String.Empty;
            new Action(() => value.WithParam(nameof(value)).NotNullOrEmpty())
                .Should().ThrowExactly<ArgumentException>().WithMessage($"Parameter must not be null or empty. (Parameter '{nameof(value)}')", "NotNullOrEmpty should throw ArgumentException with correct message.");
        }

        [Fact]
        public void NotNullOrEmpty_ShouldNotThrow_OnWhitespace()
        {
            var value = " ";
            var result = value.WithParam(nameof(value)).NotNullOrEmpty();
            
            // the cast is necessary in this case, because we must force an implicit conversion.
            ((string)result).Should().BeSameAs(value);
        }
        
        [Fact]
        public void NotNullOrWhitespace_ShouldThrow_OnNull()
        {
            string value = null;
            new Action(() => value.WithParam(nameof(value)).NotNullOrWhitespace())
                .Should().ThrowExactly<ArgumentException>("NotNullOrWhitespace should throw ArgumentException.");
        }
        
        [Fact]
        public void NotNullOrWhitespace_ShouldThrow_OnNullWithMessage()
        {
            string value = null;
            new Action(() => value.WithParam(nameof(value)).NotNullOrWhitespace())
                .Should().ThrowExactly<ArgumentException>().WithMessage($"Parameter must not be null or whitespace. (Parameter '{nameof(value)}')", "NotNullOrWhitespace should throw ArgumentException with correct message.");
        }
        
        [Fact]
        public void NotNullOrWhitespace_ShouldThrow_OnEmpty()
        {
            var value = string.Empty;
            new Action(() => value.WithParam(nameof(value)).NotNullOrWhitespace())
                .Should().ThrowExactly<ArgumentException>("NotNullOrWhitespace should throw ArgumentException.");
        }
        
        [Fact]
        public void NotNullOrWhitespace_ShouldThrow_OnEmptyWithMessage()
        {
            var value = String.Empty;
            new Action(() => value.WithParam(nameof(value)).NotNullOrWhitespace())
                .Should().ThrowExactly<ArgumentException>().WithMessage($"Parameter must not be null or whitespace. (Parameter '{nameof(value)}')", "NotNullOrWhitespace should throw ArgumentException with correct message.");
        }
        
        [Fact]
        public void NotNullOrWhitespace_ShouldThrow_OnSpace()
        {
            var value = " ";
            new Action(() => value.WithParam(nameof(value)).NotNullOrWhitespace())
                .Should().ThrowExactly<ArgumentException>("NotNullOrWhitespace should throw ArgumentException.");
        }
        
        [Fact]
        public void NotNullOrWhitespace_ShouldThrow_OnSpaceWithMessage()
        {
            var value = " ";
            new Action(() => value.WithParam(nameof(value)).NotNullOrWhitespace())
                .Should().ThrowExactly<ArgumentException>().WithMessage($"Parameter must not be null or whitespace. (Parameter '{nameof(value)}')", "NotNullOrWhitespace should throw ArgumentException with correct message.");
        }
        
        [Fact]
        public void NotNullOrWhitespace_ShouldThrow_OnTab()
        {
            var value = "\t";
            new Action(() => value.WithParam(nameof(value)).NotNullOrWhitespace())
                .Should().ThrowExactly<ArgumentException>("NotNullOrWhitespace should throw ArgumentException.");
        }
        
        [Fact]
        public void NotNullOrWhitespace_ShouldThrow_OnTabWithMessage()
        {
            var value = "\t";
            new Action(() => value.WithParam(nameof(value)).NotNullOrWhitespace())
                .Should().ThrowExactly<ArgumentException>().WithMessage($"Parameter must not be null or whitespace. (Parameter '{nameof(value)}')", "NotNullOrWhitespace should throw ArgumentException with correct message.");
        }
    }
}