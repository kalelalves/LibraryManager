using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Application.UseCases.Categories;
using LibraryManager.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly GetCategoryUseCase _getCategoryUseCase;
        private readonly CreateCategoryUseCase _createCategoryUseCase;
        private readonly UpdateCategoryUseCase _updateCategoryUseCase;
        private readonly DeleteCategoryUseCase _deleteCategoryUseCase;
        private readonly ListCategoriesUseCase _listCategoriesUseCase;

        public CategoriesController(
            ILogger<CategoriesController> logger,
            GetCategoryUseCase getCategoryUseCase,
            CreateCategoryUseCase createCategoryUseCase,
            UpdateCategoryUseCase updateCategoryUseCase,
            DeleteCategoryUseCase deleteCategoryUseCase,
            ListCategoriesUseCase listCategoriesUseCase)
        {
            _logger = logger;
            _getCategoryUseCase = getCategoryUseCase;
            _createCategoryUseCase = createCategoryUseCase;
            _updateCategoryUseCase = updateCategoryUseCase;
            _deleteCategoryUseCase = deleteCategoryUseCase;
            _listCategoriesUseCase = listCategoriesUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            try
            {
                var categories = await _listCategoriesUseCase.Execute();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all categories");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            try
            {
                var category = await _getCategoryUseCase.Execute(id);
                if (category == null)
                    return NotFound();

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting category with id {CategoryId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create([FromBody] Category category)
        {
            try
            {
                var createdCategory = await _createCategoryUseCase.Execute(category);
                return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating category");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            try
            {
                if (id != category.Id)
                    return BadRequest();

                await _updateCategoryUseCase.Execute(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category with id {CategoryId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _deleteCategoryUseCase.Execute(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting category with id {CategoryId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
} 