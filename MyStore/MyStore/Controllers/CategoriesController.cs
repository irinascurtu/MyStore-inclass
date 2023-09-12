using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly StoreContext context;

        public CategoriesController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var text = "ala bala porto cala";

            var noOfWords = text.CountWords();
            var noOfWordsMethod = CountWords(text);


            var allCategories = context.Categories.ToList();

            var descriptions = allCategories
                .Where(category => category.Description.Contains("beer"))
                .Select(category => category);

            var matching = new List<Category>();

            foreach (var categoryItem in allCategories)
            {
                if (categoryItem.Description.Contains("beer"))
                {
                    matching.Add(categoryItem);
                }
            }

            // var descriptions = allCategories.Select(x => x.Categoryid % 2 == 0);

            //descriptions eq allOddCategories
            //var allOddCategories = new List<Category>();
            //foreach (var categoryItem in allCategories)
            //{
            //    if (categoryItem.Categoryid % 2 == 0)
            //    {
            //        allOddCategories.Add(categoryItem);
            //    }
            //}

            //var descriptions2 = allCategories.Select(x =>
            //new
            //{
            //    Descr = x.Description,
            //    Id = x.Categoryid
            //});

            //foreach (var anoymous in descriptions2) {
            //    Console.WriteLine($"Id:{anoymous.Id}, Descr:{anoymous.Descr}");
            //}


            //var allProducts = allCategories.SelectMany(x => x.Products);

            var numbers = new List<int>() { 5, 6, 4, 6, 2, 1, 7, 1 };
            var firstThree = numbers.Take(3);
            var firstThree1 = numbers.Skip(3).Take(4);

            return allCategories;
        }
        #region hidden

        public int CountWords(string paragraph)
        {
            var words = paragraph.Split(' ');
            return words.Length;
        }
        #endregion

        [HttpGet("mycoolCategory/{id:alpha}")]
        public ActionResult<Category> GetById(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPut("{id}")]
        public ActionResult<Category> Update(int id, Category category)
        {
            //verificam in db daca avem ceva cu ID-ul respectiv
            // updatam
            // returnam 404

            var existingCategory = context.Categories.Find(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCategory);
            context.Categories.Update(category);
            context.SaveChanges();


            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Babu(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            //exista?
            //stergem
            context.Categories.Remove(category);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(Category categoryToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: business rules

            context.Add(categoryToAdd);
            context.SaveChanges();

            // return Ok(categoryToAdd);
            return CreatedAtAction(nameof(GetById), new { id = categoryToAdd.Categoryid }, categoryToAdd);
        }
    }
}
