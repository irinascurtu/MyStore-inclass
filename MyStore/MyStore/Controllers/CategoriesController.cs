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

        [HttpGet("{id}")]
        public Category GetById(int id)
        {
            var category = context.Categories.Find(id);
            return category;
        }


        [HttpPut("{id}")]
        public Category Update(int id, Category category)
        {
            //verificam in db daca avem ceva cu ID-ul respectiv
            // updatam
            // returnam 404

            var existingCategory = context.Categories.Find(id);
            if (existingCategory != null)
            {
                TryUpdateModelAsync(existingCategory);
                context.Categories.Update(category);
                context.SaveChanges();

            }

            return category;
        }

        [HttpDelete("{id}")]
        public Category? Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            ///exista?
            /// stergem
            /// returnam NotFound()
            return null;
        }

        [HttpPost]
        public Category Create(Category categoryToAdd)
        {
            context.Add(categoryToAdd);
            context.SaveChanges();

            return categoryToAdd;

        }
    }
}
