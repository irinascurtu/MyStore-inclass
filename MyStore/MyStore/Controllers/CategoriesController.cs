using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository repository;

        public CategoriesController(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            var allCategories = repository.GetAll();

            var modelsToReturn = new List<CategoryModel>();
            foreach (var category in allCategories)
            {
                modelsToReturn.Add(category.ToCategoryModel());
            }

            return modelsToReturn;
        }


        // [HttpGet("mycoolCategory/{id:alpha}")]
        [HttpGet("{id}")]
        public ActionResult<CategoryModel> GetById(int id)
        {

            var categoryFromDb = repository.GetCategoryById(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            var model = new CategoryModel();
            model = categoryFromDb.ToCategoryModel();

            return Ok(model);
        }


        [HttpPut("{id}")]
        public ActionResult<CategoryModel> Update(int id, CategoryModel model)
        {
            //verificam in db daca avem ceva cu ID-ul respectiv
            // updatam
            // returnam 404

            var existingCategory = repository.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCategory);

            var categoryToUpdate = new Category();
            categoryToUpdate = model.ToCategory();
            repository.Update(categoryToUpdate);

            return Ok(categoryToUpdate.ToCategoryModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Babu(int id)
        {
            var category = repository.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            //exista?
            //stergem
            repository.Delete(category);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: business rules
            //we need Category
            var categoryToSave = new Category();
            categoryToSave = model.ToCategory();

            repository.Add(categoryToSave);

            model.Categoryid = categoryToSave.Categoryid;
            // return Ok(categoryToAdd);
            return CreatedAtAction(nameof(GetById), new { id = categoryToSave.Categoryid }, model);
        }
    }
}
