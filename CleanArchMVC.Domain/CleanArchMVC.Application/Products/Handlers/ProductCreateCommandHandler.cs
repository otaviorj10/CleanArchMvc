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
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public  async Task<Product> Handle(ProductCreateCommand request, 
            CancellationToken cancellationToken)
        {
            var  products =   new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);
            
            if (products == null)
            {
                throw new ApplicationException($"Error creating  entity");

            }
            else
            {
                products.CategoryId = request.CategoryId;
                return await _productRepository.CreateAsync(products);
            }
        
        }
    }
}
