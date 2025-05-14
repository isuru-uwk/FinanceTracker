using FinanceTracker.BLL.Interfaces;
using FinanceTracker.DAL.Db.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace FinanceTracker.Api.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    [Produces("application/json")]
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        /// <summary>
        /// Retrieves all categories
        /// </summary>
        /// <returns>A list of all categories</returns>
        /// <response code="200">If the categories are retrieved successfully</response>
        /// <response code="500">If there was an internal server error</response>
        [EndpointSummary("Get All Categories")]
        [Description("Endpoint that retrieves all categories")]
        [HttpGet(Name = nameof(GetAllCategories))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            try
            {
                var categories = await categoryService.GetAllCategoriesAsync();

                if (categories == null || categories.Any())
                {
                    return NotFound("No categories found.");
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
