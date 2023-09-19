using Microsoft.VisualBasic;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext storeContext;

        public CategoryRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Category? GetCategoryById(int id)
        {
            return storeContext.Categories.Find(id);
        }

        public Category Add(Category category)
        {
            var addedEntity = storeContext.Categories.Add(category).Entity;
            storeContext.SaveChanges();
            return addedEntity;

        }

        public int Delete(Category category)
        {
            storeContext.Categories.Remove(category);
            return storeContext.SaveChanges();
        }

        public Category Update(Category category)
        {
            var updatedEntity = storeContext.Categories.Update(category).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Category> GetAll()
        {
            return storeContext.Categories.ToList();
        }
    }
}
