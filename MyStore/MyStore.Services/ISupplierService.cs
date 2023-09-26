using MyStore.Domain;

namespace MyStore.Services
{
    public interface ISupplierService
    {
        Supplier? GetSupplier(int id);
        IEnumerable<Supplier> GetSuppliers(int page);
        IEnumerable<Supplier> GetSuppliers(int page, string? text);
        Supplier InsertNew(Supplier supplier);
        bool IsDuplicate(string SupplierName);
        int Remove(Supplier supplier);
        Supplier Update(Supplier supplier);
    }
}