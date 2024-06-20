using FramWork.BaseRepository;
using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Category;
using Shapping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccessServiceContract.Repositories
{
    public interface ICategoryRepositrory : IBaseRepositorySearchable<Category, int, CategorySearchModel, CategoryListItem>
    {
        bool ExistCategoryName(string categoriesName);

        bool ExistCategoryName(string categoriesName, int categoryID);

        void IncrementParentDirectChildCount(int categoryID);//افزایش تعداد فرزندان مستقیم والدین

        void DeccrementParentDirectChildCount(int categoryID);//کاهش تعداد فرزندان مستقیم والدین

        string GenerateLinage(int categoryID); //این ای دی یک نود رو میگیره و بهد لاینج رو تولید میکنه

        OperationResult SetLinage(string Linage, int categoryID);//این لاینج تولید شده رو ست میکنه

        bool HasRelatedProduct(int categoryID);//دارای محصول مرتبط?

        bool HasChildCategory(int categoryID);   

        void RemoveCategoryFeatures(int categoryID);

        List<Category> GetChildren(int categoryID);

        bool GenerateAndSetLineageOnUpdateParentIDForNodeAndItsChildren(int categoryID, int? newParentID);

        List<FastCatList> GetDrp();
    }
}
