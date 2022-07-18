using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMVC.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                await categoryService.Add(categoryDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var categoryDto = await categoryService.GetById(id);
            if (categoryDto == null) return NotFound();
            return View(categoryDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await categoryService.Update(categoryDTO);
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id )
        {
            if (id == null)
                return NotFound();

            var categoryDto = await categoryService.GetById(id);

            if (categoryDto == null) return NotFound();

            return View();
              
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await categoryService.Remove(id);
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Details ( int? id)
        {
            if (id == null)
                return NotFound();
            var categoryDto = await categoryService.GetById(id);

            if (categoryDto == null)
                return NotFound();

            return View(categoryDto);
        }

    }
}
