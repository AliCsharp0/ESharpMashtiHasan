 using FramWork.DTOS;
using Shapping.DomainModel.Models;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Shopping.EF
{
    public class SupplierRepository : ISupplierRepository
    {

        private readonly ShoppingMashtiHasanContext db;

        public SupplierRepository(ShoppingMashtiHasanContext db)
        {
            this.db = db;    
        }

        public OperationResult Add(Supplier current)
        {
            throw new NotImplementedException();
        }

        public bool ExistSupplierName(string supplierName)
        {
            return db.Suppliers.Any(x=> x.SupplierName == supplierName);
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.FirstOrDefault(x => x.SupplierID == id);     
        }

        public List<Supplier> GetAll()
        {
           return db.Suppliers.ToList();
        }

        public bool HasRelatedProduct(int ProductID)
        {
            var s = db.Suppliers.FirstOrDefault(x => x.SupplierID == ProductID);
            return s.Products.Any();
        }

        public bool HasRelatedSupplier(int supplierID)//in Agar Product dashte bashe True Bar Migardone;iani Product dare ia na
        {
            var s = db.Suppliers.FirstOrDefault(x=>x.SupplierID == supplierID);
            return s.Products.Any();
        }

        public OperationResult Register(Supplier current)
        {
            OperationResult op = new OperationResult("Add Supplier");
            try
            {
                db.Suppliers.Add(current);
                db.SaveChanges();
              return op.ToSuccess("Register Supplier Successfully" , current.SupplierID);
            }
            catch (Exception ex)
            {
                return op.ToFail("Registrer Supplier Failed" +  ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete Supplier");
            try
            {
                db.Suppliers.Remove(db.Suppliers.FirstOrDefault(x => x.SupplierID == id));
                db.SaveChanges();
                return op.ToSuccess("Delete Supplier Successfully", id);
            }
            catch (Exception ex)
            {
                return op.ToFail("Delete Supplier Failed" + ex.Message);
            }
        }

        public OperationResult Update(Supplier current)
        {
            OperationResult op = new OperationResult("Update Supplier");
            try
            {
                var old = db.Suppliers.FirstOrDefault(x => x.SupplierID == current.SupplierID);
                old.SupplierName = current.SupplierName;
                old.SupplierDescription = current.SupplierDescription;
                db.SaveChanges();
                return op.ToSuccess("Update Supplier Successfully", current.SupplierID);
            }
            catch (Exception ex)
            {
                return op.ToFail("Update Supplier Failed" + ex.Message);
            }
        }
    }
}
