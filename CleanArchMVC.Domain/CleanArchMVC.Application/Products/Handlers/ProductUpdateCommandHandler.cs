using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Products.Handlers
{
    class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {

        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, 
            CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByIdAsync(request.Id);

            if (products == null)
            {
                throw new ApplicationException($"Error could not be found");
            } else  
            {
                products.Upadate(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

                return await _productRepository.UpdateAsync(products);
            }
        }
    }
}
