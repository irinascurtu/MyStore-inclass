using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class NewCategoryRepository : ICategoryRepository
    {
        public Category? GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
