using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {

        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "product name", "product description", 9.99m,
                99, "productImage");

            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();

        }


        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m,
                99, "product image");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Id Value");

        }


        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product description", 9.99m, 99,
                "Product Image");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name , too short  , minimium 3 characters");

        }

        [Fact]
        public void CreateProduct_PricInvalid_DomainExceptionPriceInvalid()
        {
            Action action = () => new Product(1, "product name", "product ", -99.9m, 99, "product image");

            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price Value");
        }


        [Fact]
        public void CreateProduct_NullNameValue_DomainExceptionLongName()
        {
            Action action = () => new Product(1, " Product Name", "Pr", 99.9m,
                99, "product image");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name , too short  , minimium 5 characters");
        }

        [Fact]
        public void CreateProduct__DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, " Product Name", "Product Description", 99.9m,
               99, "product image tooooooooooooooooooooooooooooooooooooooooooooooooodddddddoooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooonnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnng");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid image name , too long , maximum 250 characters");
        }


        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, " Product Name", "Product Description", 99.9m,
                99, null);

            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageNameNllImage_DomainException()
        {
            Action action = () => new Product(1, " Product Name", "Product Description", 99.9m,
                99, null);

            action.Should()
                .NotThrow<NullReferenceException>();
        }


        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidSotckValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, " pro", "Product Description", 99.9m,
                value, "product image");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }


    }
}
