using MyStore.Domain;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category? GetCategory(int id);
        Category InsertNew(Category category);
        int Remove(Category category);
        Category Update(Category category);
    }
}