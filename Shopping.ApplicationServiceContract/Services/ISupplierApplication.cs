using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Supplier;
using Shapping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationServiceContract.Services
{
    public interface ISupplierApplication
    {
        OperationResult Register(SupplierAddEditModel supplier);

        OperationResult Remove(int supplierID);

        OperationResult Update(SupplierAddEditModel supplier);

        List<Supplier> GetAll();

        SupplierAddEditModel Get(int supplierID);
    }
}
