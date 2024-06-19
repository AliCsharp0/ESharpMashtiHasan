using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Product;
using Shapping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationServiceContract.Services
{
    public interface IProductApplication
    {
       // bool ExistProductName(string productName);

       // bool ExistProductNameForAnotherProduct(string productName, int PrductID);

        //bool ExistSlug(string slug);

        //  bool ExistSlugForAnotherProduct(string slug, int ProductID);

        //  bool ExistProductKey(int ProductID, int KeyWordID);

        OperationResult AssignKeyWordToProduct(int KeyWordID, int ProductID);

        OperationResult RegisterKeyWordAndassignItToTheProduct(string KeyWord, int ProductID);

        // bool ExistKeyWord(string KeyWord);

        OperationResult DisAboveKeyWordFromProduct(int KeyWordID, int ProductID);

        //OperationResult AssignCategoryFeatureToProductAfterRegistration(int ProductID);

        OperationResult AssignFeatureValueForSpecificProductAndFeature(int ProductID, int FeatureID, string FeatureValue, int EffectOnUnitPrice);

        // bool ExistFeature(string FeatureName);

        OperationResult RegisterFeatureAndAssignItToTheProduct(ProductFeatureAddModel pf);

        ProductAddEditModel Get(int id);

        OperationResult Remove(int id);

        OperationResult Update(ProductAddEditModel current);

        OperationResult Register(ProductAddEditModel current);

        // List<Product> GetAll();

        List<ProductListItem> Search(ProductSearchModel sm, out int RecordCount);
    }
}
