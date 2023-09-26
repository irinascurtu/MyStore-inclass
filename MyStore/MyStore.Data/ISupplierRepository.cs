using MyStore.Domain;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        Supplier Add(Supplier supplier);
        int Delete(Supplier supplier);
        IQueryable<Supplier> GetAll();
        IEnumerable<Supplier> GetAll(int page);
        IQueryable<Supplier> GetAll(int page, string? text);
        Supplier? GetSupplierById(int id);
        Supplier Update(Supplier supplier);
    }
}