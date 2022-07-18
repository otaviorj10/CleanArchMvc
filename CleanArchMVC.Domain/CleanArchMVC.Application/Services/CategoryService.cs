using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await categoryRepository.GetCategoriesAsync();
            return mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            return mapper.Map<CategoryDTO>(category);
        }
        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoryDto = mapper.Map<Category>(categoryDTO);
            await categoryRepository.CreateAsync(categoryDto);

        }


        public async Task Remove(int? id)
        {
            var categoryEntity = categoryRepository.GetByIdAsync(id).Result;
            await categoryRepository.RemoveAsync(categoryEntity);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoryDto = mapper.Map<Category>(categoryDTO);
            await categoryRepository.UpdateAsync(categoryDto); ;
        }
    }
}
