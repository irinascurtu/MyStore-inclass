using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class SupplierRepository : ISupplierRepository
    {

        private readonly StoreContext storeContext;
        public SupplierRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Supplier Add(Supplier supplier)
        {
            var addedEntity = storeContext.Suppliers.Add(supplier).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Supplier supplier)
        {
            storeContext.Suppliers.Remove(supplier);
            return storeContext.SaveChanges();
        }

        public IEnumerable<Supplier> GetAll(int page)
        {
            var pageSize = 2;
            var suppliers =
                 storeContext
                .Suppliers
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            return suppliers;
        }

        public IQueryable<Supplier> GetAll()
        {
            return storeContext.Suppliers;
        }

        public IQueryable<Supplier> GetAll(int page, string? text)
        {
            var pageSize = 2;

            var suppliers = storeContext.Suppliers.AsQueryable();

            if (!string.IsNullOrEmpty(text))
            {
                suppliers = suppliers.Where(x => x.Companyname.Contains(text));

            }

            suppliers = suppliers.Skip(pageSize * (page - 1))
                .Take(pageSize);

            return suppliers;
        }

        public Supplier? GetSupplierById(int id)
        {
            return storeContext.Suppliers.Find(id);
        }

        public Supplier Update(Supplier supplier)
        {
            var updatedEntity = storeContext.Suppliers.Update(supplier).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }
    }
}
