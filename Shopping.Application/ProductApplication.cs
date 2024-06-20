using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Product;
using Shapping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Services;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shopping.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository repo;//be in migan inject kardan

        public ProductApplication(IProductRepository repo)
        {
            this.repo = repo;
        }

        private Product ToModel(ProductAddEditModel model)//این  جا مدل یوای رو تبدیل میکنیم به مدل دیتابیس پسند 
        {
            Product product = new Product
            {
                CategoryID = model.CategoryID,
                Description = model.Description,
                ImagUrl = model.ImagUrl,
                JSONLDInformation = model.JSONLDInformation,
                MataDescription = model.MataDescription,
                MetaKeyWord = model.MetaKeyWord,
                PageTitle = model.PageTitle,
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                Slup = model.Slup,
                SupplierID = model.SupplierID,
                UnitPrice = model.UnitPrice,
            };
            return product;
        }

        private ProductAddEditModel ToAddEditModel(Product model)//این یک مودل دیتا بیسی میگیره تبدیل میکنه به یک مدل اپلیکیشنی و برمیگردونه
            //این جا مدل دیتابیس رو تبدیل میکنیم به مدل یو ای پسند
        {
            ProductAddEditModel productAddEdit = new ProductAddEditModel
            {
                CategoryID = model.CategoryID,
                Description = model.Description,
                ImagUrl = model.ImagUrl,
                JSONLDInformation = model.JSONLDInformation,
                MataDescription = model.MataDescription,
                MetaKeyWord = model.MetaKeyWord,
                PageTitle = model.PageTitle,
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                Slup = model.Slup,
                SupplierID = model.SupplierID,
                UnitPrice = model.UnitPrice,
            };
            return productAddEdit;
        }

        public OperationResult AssignFeatureValueForSpecificProductAndFeature(int ProductID, int FeatureID, string FeatureValue, int EffectOnUnitPrice)
        {
           return repo.AssignFeatureValueForSpecificProductAndFeature(ProductID , FeatureID , FeatureValue, EffectOnUnitPrice);
        }//به پروداکت و فیچر ویژگی ها رو اختصاص دهید

        public OperationResult AssignKeyWordToProduct(int KeyWordID, int ProductID)
        {
            if(repo.ExistProductKey(ProductID , KeyWordID))
            {
                return new OperationResult("AssignKeyWordToProduct").ToFail("");
            }
            return repo.AssignKeyWordToProduct(KeyWordID , ProductID);
        }//کیبرد را پروداکت اختصاص میدهد

        public OperationResult DisAboveKeyWordFromProduct(int KeyWordID, int ProductID)
        {
            return repo.DisAboveKeyWordFromProduct (KeyWordID , ProductID);
        }//این یک کیبرد را در پروداکت حذف میکنه

        public ProductAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public OperationResult Register(ProductAddEditModel current)
        {
            if (repo.ExistProductName(current.ProductName))
            {
                return new OperationResult("Register Product").ToFail("Duplicate Product Name");
            }
            if (repo.ExistSlug(current.Slup))
            {
                return new OperationResult("Register Product").ToFail("Duplicate Slug");
            }
            Product product = ToModel(current);
            var opProduct = repo.Register(product);
            if (opProduct.Success)
            {
                repo.AssignCategoryFeatureToProductAfterRegistration(opProduct.RecordID.Value);
            }
            return opProduct;
        }

        public OperationResult RegisterFeatureAndAssignItToTheProduct(ProductFeatureAddModel pf)
        {
            if (repo.ExistFeature(pf.FeatureName))
            {
                return new OperationResult("RegisterFeatureAndAssignItToTheProduct").ToFail("Duplicate Feature");
            }
            return repo.RegisterFeatureAndAssignItToTheProduct(pf);
        }//فیچر را ثبت کنید و آن را به پروداکت اختصاص دهید

        public OperationResult RegisterKeyWordAndassignItToTheProduct(string KeyWord, int ProductID)
        {
            if (repo.ExistKeyWord(KeyWord))
            {
                return new OperationResult("RegisterKeyWordAndassignItToTheProduct").ToFail("Duplicate KeyWord");
            }
            return repo.RegisterKeyWordAndassignItToTheProduct(KeyWord, ProductID);
        }//کیبرد را ثبت کنید و آن را به پروداکت اختصاص دهید

        public OperationResult Remove(int id)
        {
            if (repo.HasRelatedOrders(id))
            {
                return new OperationResult("Remove Product ").ToFail("Product has Related Orders");
            }
            return repo.Remove(id);
        }

        public List<ProductListItem> Search(ProductSearchModel sm, out int RecordCount)
        {
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult Update(ProductAddEditModel current)
        {
            if (repo.ExistProductNameForAnotherProduct(current.ProductName, current.ProductID))
            {
                return new OperationResult("Update Product").ToFail("Product Name belongs to Another Product");
            }
            if (repo.ExistSlugForAnotherProduct(current.Slup, current.ProductID))
            {
                return new OperationResult("Update Product").ToFail("Slug Already belongs to Anther Product");
            }
            Product prod = ToModel(current);
            return repo.Update(prod);
        }
    }
}
