using MyStore.Domain;

namespace MyStore.Data
{
    public interface ICategoryRepository
    {
        Category? GetCategoryById(int id);
    }
}