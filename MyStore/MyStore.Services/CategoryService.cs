using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        public Category? GetCategory(int id)
        {
            var existingCategory = categoryRepository.GetCategoryById(id);
            return existingCategory;

            //return categoryRepository.GetCategoryById(id); ;
        }


        public IEnumerable<Category> GetCategories(int page)
        {

            return categoryRepository.GetAll(page);
        }

        public IEnumerable<Category> GetCategories(int page, string? text)
        {

            return categoryRepository.GetAll(page, text);
        }

        public Category InsertNew(Category category)
        {

            return categoryRepository.Add(category);
        }


        public int Remove(Category category)
        {
            return categoryRepository.Delete(category);
        }

        public Category Update(Category category)
        {
            return categoryRepository.Update(category);
        }
            
        public bool IsDuplicate(string Categoryname)
        {
            var categories = categoryRepository.GetAll();//1
            categories = categories.Where(x => x.Categoryname == Categoryname);//2
            categories.Where(x => x.Description.Contains("x"));//3
                //.ToList();//load in memory



            return categories.Any();
        }

    }
}
