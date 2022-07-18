using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            //eager loading
            //return await _context.Products.FindAsync(id);
            return await _context.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);

        }

        //public async Task<Product> GetProductCategoryAsync(int? id)
        //{
        //    return await _context.Products.Include(p => p.Category).SingleOrDefaultAsync(p=>p.Id==id);
            
        //}

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }


        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
