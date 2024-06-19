using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Product;
using Shapping.DomainModel.Models;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Shopping.EF
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingMashtiHasanContext db;

        public ProductRepository(ShoppingMashtiHasanContext db)
        {
            this.db = db;
        }

        public OperationResult AssignCategoryFeatureToProductAfterRegistration(int ProductID)
        {
            OperationResult op = new OperationResult("AssignCategoryFeatureToProductAfterRegistration");
            try
            {
                var prod = Get(ProductID);
                var category = db.Categories.FirstOrDefault(x => x.CategoryID == prod.CategoryID);
                var categoryFeature = db.CategoryFeatures.ToList();
                foreach (CategoryFeature item in categoryFeature)
                {
                    ProductFeature pf = new ProductFeature
                    {
                        EffectOnUnitPrice = 0,
                        FeatureID = item.FeatureID,
                        FeatureValue = String.Empty,
                        ProductID = ProductID,
                    };
                    db.ProductFeatures.Add(pf);
                }
                db.SaveChanges();
                return op.ToSuccess("All CategoryFeature Assignment Successfull", ProductID);
            }
            catch (Exception ex)
            {
                return op.ToFail("Feature Assignment Failed" + ex.Message);
            }
        }

        public OperationResult AssignFeatureValueForSpecificProductAndFeature(int ProductID, int FeatureID, string FeatureValue, int EffectOnUnitPrice)
        {
            OperationResult op = new OperationResult("AssignFeatureValueForSpecificProductAndFeature");
            try
            {
                var prodFeature = db.ProductFeatures.FirstOrDefault(x => x.FeatureID == FeatureID && x.ProductID ==ProductID);
                prodFeature.EffectOnUnitPrice = EffectOnUnitPrice;
                prodFeature.FeatureValue = FeatureValue;
                db.SaveChanges();
                return op.ToSuccess("Feature Assignment Successfull");
            }
            catch(Exception ex)
            {
                return op.ToFail("Feature Assignment Failed" + ex.Message);
            }
        }

        public OperationResult AssignKeyWordToProduct(int KeyWordID, int ProductID)
        {
            OperationResult op = new OperationResult("AssignKeyWordToProduct");
            try
            {
                ProductKeyWord pk = new ProductKeyWord { KeyWordID = KeyWordID, ProductID = ProductID };
                db.ProductKeyWords.Add(pk);
                db.SaveChanges();
                return op.ToSuccess("KeyWord Assignment Successfull");
            }
            catch( Exception ex)
            {
                return op.ToFail("KeyWord Assignment Failed" + ex.Message);
            }
        }

        public OperationResult DisAboveKeyWordFromProduct(int KeyWordID, int ProductID)//این یک کیبورد رو از پروداکت حظف میکنه 
        {
            OperationResult op = new OperationResult("DisAboveKeyWordFromProduct");
            try
            {
                db.ProductKeyWords.Remove(db.ProductKeyWords.FirstOrDefault(x => x.KeyWordID == KeyWordID && x.ProductID == ProductID));
                db.SaveChanges();
                return op.ToSuccess("ProductKeyWord Remove Successfull");
            }
            catch (Exception ex)
            {
                return op.ToFail("ProductKeyWord Remove Failed" + ex.Message);
            }
        }

        public bool ExistFeature(string FeatureName)
        {
            return db.Features.Any(x => x.FeatureName == FeatureName);
        }

        public bool ExistKeyWord(string KeyWord)
        {
            return db.KeyWords.Any(x => x.KeyWordText == KeyWord);
        }

        public bool ExistProductKey(int ProductID, int KeyWordID)
        {
            return db.ProductKeyWords.Any(x => x.KeyWordID == KeyWordID && x.ProductID == ProductID);
        }

        public bool ExistProductName(string productName)
        {
            return db.Products.Any(x => x.ProductName == productName); ;
        }

        public bool ExistProductNameForAnotherProduct(string productName, int PrductID)
        {
            return db.Products.Any(x => x.ProductID != PrductID && x.ProductName == productName);
        }

        public bool ExistSlug(string slug)
        {
            return db.Products.Any(x => x.Slup == slug);

        }

        public bool ExistSlugForAnotherProduct(string slug, int ProductID)//Slug برای یک محصول دیگر وجود دارد
        {
            return db.Products.Any(x => x.ProductID != ProductID && x.Slup == slug);
        }

        public Product Get(int id)
        {
            var p = db.Products.FirstOrDefault(x => x.ProductID == id);
            return p;
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public bool HasRelatedOrders(int ProductID)
        {
            return Get(ProductID).OrderDetails.Any();//
        }

        public OperationResult Register(Product current)
        {
            OperationResult op = new OperationResult("Product Registration");
            try
            {
                db.Products.Add(current);
                db.SaveChanges();
                return op.ToSuccess("Product Registered Successfull", current.ProductID);
            }
            catch (Exception ex)
            {
                return op.ToFail("Product Registered Failed" + ex.Message);
            }
        }

        public OperationResult RegisterFeatureAndAssignItToTheProduct(ProductFeatureAddModel pf)
        {
            OperationResult op = new OperationResult("RegisterFeatureAndAssignItToTheProduct");
            try
            {
                var f = new Feature { FeatureName = pf.FeatureName };
                db.Features.Add(f);
                db.SaveChanges();
                var prodFeature = new ProductFeature
                {
                    EffectOnUnitPrice = pf.EffectOnUnitPrice,
                    FeatureID = f.FeatureID,
                    FeatureValue = pf.FeatureValue,
                    ProductID = pf.ProductID,
                };
                db.ProductFeatures.Add(prodFeature);
                db.SaveChanges();
                return op.ToSuccess("Feature Registered And Asseigned to the product", pf.ProductID);
            }
            catch (Exception ex)
            {
                return op.ToFail("Feature Assignment Failed" + ex.Message);
            }
        }

        public OperationResult RegisterKeyWordAndassignItToTheProduct(string KeyWord, int ProductID)//این کیبورد رو ثبت میکنه کیبوردایدی رو بدست میاره و در پروداکت کیبورد ثبت میکنه و بعد تمام
        {
            OperationResult op = new OperationResult("RegisterKeyWordAndassignItToTheProduct");
            try
            {
                var kw = new KeyWord { KeyWordText = KeyWord };
                db.KeyWords.Add(kw);
                db.SaveChanges();//این جا باید کیبورد ثبت بشه که بعدش در خط پایین بشه ایدی و ایدنتیتی رو مقداردهی کرد
                db.ProductKeyWords.Add(new ProductKeyWord { KeyWordID = kw.KeyWordID, ProductID = ProductID });
                db.SaveChanges();
                return op.ToSuccess("KeyWord Successfull Assigned");
            }
            catch (Exception ex)
            {
                return op.ToFail("KeyWord Failed Assigned" + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Remove Product", id);
            try
            {
                var prod = db.Products.FirstOrDefault(x => x.ProductID == id);
                var prodFeature = prod.ProductFeatures.ToList();//از اینجا تا خط 125 عوامل که وابسته به این پروداکت بودن رو پاک میکنیم و بعد خود پدوداگت را پاک میکنیم
                foreach (ProductFeature item in prodFeature)
                {
                    db.ProductFeatures.Remove(item);
                }
                var prodKeyword = db.ProductKeyWords.ToList();
                foreach (ProductKeyWord item in prodKeyword)
                {
                    db.ProductKeyWords.Remove(item);
                }
                db.SaveChanges();//اینجا سیو میکنیم که مطمعن بشیم که عوامل وابسته بهش پاک شده
                db.Products.Remove(prod);
                db.SaveChanges();
                return op.ToSuccess("Product Remove Successfull", id);
            }
            catch (Exception ex)
            {
                return op.ToFail("Product Remove Failed" + ex.Message);
            }
        }

        public List<ProductListItem> Search(ProductSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 5;
            }
            var q = from prod in db.Products select prod;//to in query search mikonim بعد az rosh model misazim ,  این داده ها را از جدول محصولات در پایگاه داده بازیابی می کند

            if (!string.IsNullOrEmpty(sm.ProductName))
            {
                q = q.Where(x => x.ProductName.StartsWith(sm.ProductName));
            }
            if (!string.IsNullOrEmpty(sm.Slug))
            {
                q = q.Where(x => x.Slup.StartsWith(sm.Slug));
            }
            if (sm.CategoryID != null && sm.CategoryID>0)
            {
                q = q.Where(x => x.CategoryID == sm.CategoryID);
            }
            if (sm.SupplierID != null && sm.SupplierID > 0)
            {
                q = q.Where(x => x.SupplierID == sm.SupplierID);
            }
            if (sm.UintPriceFrom != null)
            {
                q = q.Where(x => x.UnitPrice >= sm.UintPriceFrom);
            }
            if (sm.UintPriceTo != null)
            {
                q = q.Where(x => x.UnitPrice <= sm.UintPriceTo);
            }
            RecordCount = q.Count();//این بخش تعداد رکوردهای موجود در مجموعه بازگشتی (کیو) را محاسبه می کند / q == کیو
            q = q.OrderByDescending(x => x.ProductID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize);
            //q.OrderByDescending(x => x.ProductID): این بخش از پرس و جو سوابق را به ترتیب نزولی بر اساس پروداکتایدی مرتب می کند. این رکوردها را از بالاترین تا پایین ترین پروداکتایدی مرتب می کند.
            // Skip(sm.PageIndex * sm.PageSize)=این معمولا برای صفحه بندی استفاده می شود، به ما اجازه می دهد داده ها را برای یک صفحه خاص بازیابی کنیم.
            // Take(sm.PageSize) =این تضمین می کند که ما مجموعه محدودی از نتایج را در هر صفحه بازیابی می کنیم.
            var q2 = from prod in q //in ja join q bala ro ^ angam midim
                     select new ProductListItem
                     {
                         CategoryName = prod.category.CategoriesName,
                         HasRelatedOrder = prod.OrderDetails.Any(),
                         SuplierName = prod.supplier.SupplierName,
                         ProductID = prod.ProductID,
                         ProductName = prod.ProductName,
                         Slug = prod.Slup,
                         UnitPrice = prod.UnitPrice,
                     };
            return q2.ToList();
        }

        public OperationResult Update(Product current)
        {
            OperationResult op = new OperationResult("Update Product", current.ProductID);

            try
            {
                db.Products.Attach(current);//این خط و خط 242 معادل سه خط سبز پایینی هستش   
                db.Entry<Product>(current).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                // var old = db.Suppliers.FirstOrDefault(x=>x.SupplierID == current.SupplierID);
                // old.SupplierName = current.SupplierName;
                //old.SupplierDescription = current.SupplierDescription;

                db.SaveChanges();

                return op.ToSuccess("Product Update Successfull");
            }
            catch (Exception ex)
            {
                return op.ToFail("Product Update Failed" + ex.Message);
            }
        }
    }
}
