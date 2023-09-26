//using Microsoft.AspNetCore.Mvc;
//using MyStore.Domain;
//using MyStore.Models;
//using MyStore.Services;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace MyStore.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SuppliersController : ControllerBase
//    {
//        private readonly ISupplierService supplierService;

//        public SuppliersController(ISupplierService supplierService)
//        {
//            this.supplierService = supplierService;
//        }

//        [HttpGet]
//        public IEnumerable<SupplierModel> Get(string? text, int pag = 1)
//        {

//            var pageSize = 2;

//            var allSuppliers = supplierService.GetSuppliers(pag, text);

//            var modelsToReturn = new List<SupplierModel>();
//            foreach (var supplier in allSuppliers)
//            {
//                modelsToReturn.Add(supplier.ToSupplierModel());
//            }

//            return modelsToReturn;
//        }


//        [HttpGet("{id}")]
//        public ActionResult<SupplierModel> GetById(int id)
//        {

//            var supplierFromDb = supplierService.GetSupplier(id);

//            if (supplierFromDb == null)
//            {
//                return NotFound();
//            }
//            var model = new SupplierModel();
//            model = supplierFromDb.ToSupplierModel();

//            return Ok(model);
//        }


//        //[HttpPut("{id}")]
//        //public ActionResult<SupplierModel> Update(int id, SupplierModel model)
//        //{
//        //    var existingSuplier = supplierService.GetSupplier(id);
//        //    if (existingSuplier == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    TryUpdateModelAsync(existingSuplier);

//        //    var supplierToUpdate = new Supplier();
//        //    supplierToUpdate = model.ToSupplier();
//        //    supplierService.Update(supplierToUpdate);

//        //    return Ok(supplierToUpdate.ToSupplierModel());
//        //}

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var supplier = supplierService.GetSupplier(id);

//            if (supplier == null)
//            {
//                return NotFound();
//            }

//            supplierService.Remove(supplier);

//            return NoContent();
//        }

//        [HttpPost]
//        public IActionResult Create(SupplierModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            //  business rules
//            if (supplierService.IsDuplicate(model.Companyname))
//            {
//                ModelState.AddModelError("Companyname", $"You can't have the duplicate items with the value {model.Companyname} on Companyname");
//                return Conflict(ModelState);
//            }

//            var supplierToSave = new Supplier();
//            supplierToSave = model.ToSupplier();

//            supplierService.InsertNew(supplierToSave);

//            model.Supplierid = supplierToSave.Supplierid;

//            return CreatedAtAction(nameof(GetById), new { id = supplierToSave.Supplierid }, model);
//        }
//    }
//}
