using FramWork.BaseRepository;
using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Category;
using Shapping.DomainModel.BusinessModel.Product;
using Shapping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccessServiceContract.Repositories
{
    public interface IProductRepository : IBaseRepositorySearchable<Product , int , ProductSearchModel , ProductListItem>
    {
        bool ExistProductName(string productName);//نام محصول موجود?

        bool ExistProductNameForAnotherProduct(string productName, int PrductID);//?نام محصول برای محصول دیگری وجود دارد

        bool ExistSlug(string slug);//slug vojod darad ia na?

        bool ExistSlugForAnotherProduct(string slug, int ProductID);//نام اسلوگ برای اسلوگ دیگری وجود دارد؟

        bool ExistProductKey(int ProductID, int KeyWordID);//in ja chek mishe ke keyword be product vasl shodeh ia na ke dobare vasl nakonim

        OperationResult AssignKeyWordToProduct(int KeyWordID , int ProductID);//کلمه کلیدی را به محصول اختصاص دهید  

        OperationResult RegisterKeyWordAndassignItToTheProduct(string KeyWord , int ProductID);//in keyword sabt mikone bad idish ro be dast miare va dar jadval janktionsh ro mizane ,کلمه کلیدی را ثبت کنید و آن را به محصول اختصاص دهید

        bool ExistKeyWord(string KeyWord);//chek mikone ke keyword vojod darad ia na

        OperationResult DisAboveKeyWordFromProduct(int KeyWordID , int ProductID);

        OperationResult AssignCategoryFeatureToProductAfterRegistration(int ProductID);//پس از ثبت نام، ویژگی کتگوریفیچر  را به محصول اختصاص دهید (CategoryFeature =کتگوریفیچر

        OperationResult AssignFeatureValueForSpecificProductAndFeature(int ProductID, int FeatureID , string FeatureValue , int EffectOnUnitPrice); //in ja Feature haii ke vojod darad ro mitavanad entekhab konad

        bool ExistFeature(string FeatureName);//in chek mikone ke FeatureName vojod dare ia na

        OperationResult RegisterFeatureAndAssignItToTheProduct(ProductFeatureAddModel pf);//in agar Feature nashte bashe mige ke sabat konim , ویژگی را ثبت کنید و آن را به محصول اختصاص دهید(feature = vijegi)

        bool HasRelatedOrders(int ProductID);

    }

}
