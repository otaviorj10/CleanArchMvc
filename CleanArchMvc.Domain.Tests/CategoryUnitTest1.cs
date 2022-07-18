using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");

            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();

        }


        [Fact]
        public void CreateCategory_NegativeIdValue_ResultObjectValidState()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Id Value");

        }


        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortValue()
        {
            Action action = () => new Category(1, "Ca");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name , too short  , minimium 3 characters");
            
        }


        [Fact]
        public void CreateCategory_NullNameValue_DomainExceptionEmptyValue()
        {
            Action action = () => new Category(3, "");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name.Name is Requerired");
        }

        [Fact]
        public void CreateCategory_NullNameValue_DomainExceptionNullValue()
        {
            Action action = () => new Category(3, null);

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name.Name is Requerired");
        }
    }
}
