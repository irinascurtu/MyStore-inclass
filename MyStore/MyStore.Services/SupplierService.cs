using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Supplier? GetSupplier(int id)
        {
            var existingSupplier = supplierRepository.GetSupplierById(id);
            return existingSupplier;
        }

        public IEnumerable<Supplier> GetSuppliers(int page)
        {
            return supplierRepository.GetAll(page);
        }

        public IEnumerable<Supplier> GetSuppliers(int page, string? text)
        {
            return supplierRepository.GetAll(page, text);
        }

        public Supplier InsertNew(Supplier supplier)
        {
            return supplierRepository.Add(supplier);
        }

        public bool IsDuplicate(string SupplierName)
        {
            var supplier = supplierRepository.GetAll();//1
            supplier = supplier.Where(x => x.Companyname == SupplierName);//2
            supplier.Where(x => x.Phone.Contains("07"));//3
                                                        //.ToList();//load in memory

            return supplier.Any();
        }

        public int Remove(Supplier supplier)
        {
            return supplierRepository.Delete(supplier);
        }

        public Supplier Update(Supplier supplier)
        {
            return supplierRepository.Update(supplier);
        }
    }
}
