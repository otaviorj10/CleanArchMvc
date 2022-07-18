using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var producsQuery = new GetProductsQuery();

            if (producsQuery == null)
                throw new Exception($"Entity could  not be lodead");


            var result = await _mediator.Send(producsQuery);

            return mapper.Map<IEnumerable<ProductDTO>>(result);


            //var products = await productRepository.GetProductsAsync();
            //return mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productById = new GetProductByIdQuery(id.Value);
            if ( productById == null)
                throw new Exception($"Entity could  not be lodead");

            var result = await _mediator.Send(productById);

            return mapper.Map<ProductDTO>(result);

        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productById = new GetProductByIdQuery(id.Value);
        //    if (productById == null)
        //        throw new Exception($"Entity could  not be lodead");

        //    var result = await _mediator.Send(productById);

        //    return mapper.Map<ProductDTO>(result);
        //}

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand =   mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);

        }
        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be load");

            await _mediator.Send(productRemoveCommand);


        }

    }
}
