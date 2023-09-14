using MyStore.Domain;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        Category? GetCategory(int id);
    }
}