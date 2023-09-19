using MyStore.Domain;

namespace MyStore.Data
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        int Delete(Category category);
        IEnumerable<Category> GetAll();
        Category? GetCategoryById(int id);
        Category Update(Category category);
    }
}