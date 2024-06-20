using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Category;
//using Shapping.DomainModel.BusinessModel.Category02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationServiceContract.Services
{
    public interface ICategoryApplication
    {
        OperationResult Register(CategoryAddEditModel model);

        OperationResult Update(CategoryAddEditModel newCat);

        OperationResult Remove(int categoryID);

        List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount);

        CategoryAddEditModel Get(int CategoryID);

        List<FastCatList> GetDrp();
    }
}
