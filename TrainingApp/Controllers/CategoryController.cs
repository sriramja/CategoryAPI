using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TariningApp.Service.Contracts;
using TrainingApp.Domain;

namespace TrainingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService categoryRepo;

        public CategoryController(ICategoryService categoryRepo, ILogger<CategoryController> logger)
        {
            this._logger = logger;
            this.categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cats = await categoryRepo.GetAll();
            return Ok(cats);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            var _category = categoryRepo.GetById(id);
            return _category;
        }


        [HttpPost]
        //[Route("CategoryAdd")]
        public ActionResult<Category> CategoryAdd([FromBody]Category category)
        {
            try
            {
                categoryRepo.Add(category);
                return categoryRepo.GetById(category.CategoryRowID);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, null);
                return Content("Error");

            }


        }

        [HttpPut("{id}")]
        public IActionResult PutAsync(int id, Category category)
        {
            if (category.CategoryRowID > 0)
            {
                categoryRepo.Update(category);

                return Ok(category);
            }
            return BadRequest(category);
        }

        [HttpDelete("{id}")]
        public void Remove(int id, Category category)
        {
            categoryRepo.Remove(id);

        }

    }
}