using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Supplier;
using Shapping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Services;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application
{

    public class SupplierApplication : ISupplierApplication
    {
        private readonly ISupplierRepository repo;
        public SupplierApplication(ISupplierRepository repo)
        {
            this.repo = repo;
        }

        public SupplierAddEditModel Get(int supplierID)
        {
            var s = repo.Get(supplierID);
            SupplierAddEditModel sup = new SupplierAddEditModel
            {
                SupplierDescription = s.SupplierDescription,
                SupplierID = s.SupplierID,
                SupplierName = s.SupplierName,
            };
            return sup;
        }

        public List<Supplier> GetAll()
        {
            return repo.GetAll();
        }

        public OperationResult Register(SupplierAddEditModel supplier)
        {
           OperationResult op = new OperationResult("Add Supplier");
            try
            {
                if (repo.ExistSupplierName(supplier.SupplierName))
                {
                    return op.ToFail("Supplier Name Already Exist");//chekk
                }
                Supplier s = new Supplier { SupplierDescription = supplier.SupplierDescription, SupplierName = supplier.SupplierName };
                op = repo.Register(s);
                return op;
            }
            catch (Exception ex)
            {
                return op.ToFail("Supplier Registration Failed");
            }
        }

        public OperationResult Remove(int supplierID)
        {
            if (repo.HasRelatedProduct(supplierID))
            {
                return new OperationResult("Remove Suplier", supplierID).ToFail(" Suplier Has Related Product");
            }
            return repo.Remove(supplierID); 
        }

        public OperationResult Update(SupplierAddEditModel supplier)
        {
            Supplier s = new Supplier
            {
				SupplierID = supplier.SupplierID,
				SupplierName = supplier.SupplierName,
                SupplierDescription = supplier.SupplierDescription,
            };
            return repo.Update(s);
        }
    }
}
