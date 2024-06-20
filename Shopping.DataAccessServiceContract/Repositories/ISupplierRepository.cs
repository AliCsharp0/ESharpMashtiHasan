using FramWork.BaseRepository;
using Shapping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccessServiceContract.Repositories
{
    public interface ISupplierRepository : IBaseRepository<Supplier , int>
    {
        bool ExistSupplierName(string supplierName);
        bool HasRelatedProduct(int ProductID);
    }
}
