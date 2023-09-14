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
    }
}
 