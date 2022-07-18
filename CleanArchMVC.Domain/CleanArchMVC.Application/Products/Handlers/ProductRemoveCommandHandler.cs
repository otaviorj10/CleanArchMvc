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
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByIdAsync(request.Id);

            if (products == null)
            {
                throw new ArgumentException($"Error could not be found");
            }
            else
            {
              var result  =  await _productRepository.RemoveAsync(products);

                return result;
            }

        }
    }
}
