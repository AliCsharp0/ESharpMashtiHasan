using FramWork.BaseRepository;
using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Category;
using Shapping.DomainModel.Models;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.Shopping.EF
{
    public class CategoryRepository : ICategoryRepositrory
    {
        private readonly ShoppingMashtiHasanContext db;//be in migan Context

        public CategoryRepository(ShoppingMashtiHasanContext db)
        {
            this.db = db;
        }

        public void DeccrementParentDirectChildCount(int categoryID)
        {
            var cat = Get(categoryID);
            if (cat.ParentID != null)
            {
                var parent = Get(cat.ParentID.Value);//in babash ro be dast miareh
                parent.DirectChildCount = parent.DirectChildCount - 1;
                db.SaveChanges();
            }
        }

        public bool ExistCategoryName(string categoriesName, int categoryID)
        {
            return db.Categories.Any(x => x.CategoriesName == categoriesName && x.CategoryID != categoryID);
        }

        public bool ExistCategoryName(string categoriesName)
        {
            return db.Categories.Any(x => x.CategoriesName == categoriesName);
        }

        public bool GenerateAndSetLineageOnUpdateParentIDForNodeAndItsChildren(int categoryID, int? newParentID)
        {
            try
            {
                var node = db.Categories.FirstOrDefault(x=>x.CategoryID == categoryID);//in ja node ro peida mikone 
                string newParentLineage = "";// in ja farz mikone ke pdaresh rot
                if(newParentID != null)// in ja mige agar pedaresh null nabod iani kodesh rot nabod  
                {
                    newParentLineage = db.Categories.FirstOrDefault(x => x.CategoryID == newParentID).LineAge;//in ja lineage ro bedast miare
                }
                var nl = node.LineAge;
                var allChildren = db.Categories.Where(x=>x.LineAge.StartsWith(nl)).ToList();// in ja list bache haie node ro mikeshe biron va tamam bache haie in node lineage shon shoro mishe ba lineage node jary
                foreach(Category item in allChildren)
                {
                    item.LineAge = item.LineAge.Replace(nl, newParentLineage + categoryID + ",");// in ja mige lineage new ro ba lineage old bro replace kon
                }
                var newParent = db.Categories.FirstOrDefault(x => x.CategoryID == newParentID);// in ja pedar jadid ro be dast miare
                if(newParentID != null && newParent != null)
                {
                    newParent.DirectChildCount = newParent.DirectChildCount + 1;
                }
                node.ParentID = newParentID;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GenerateLinage(int categoryID)
        {
            var cat = Get(categoryID);
            string lineage = "";
            if (cat.ParentID != null)//mige agar pedar dasht 
            {
                var parent = Get(cat.ParentID.Value);//in ja pedaresh ro be dast miarim
                lineage = parent.LineAge + categoryID + ",";
            }
            else
            {
                lineage = lineage + ",";
            }
            return lineage;
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryID == id);
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public List<Category> GetChildren(int categoryID)//in child ha ro be dast miare,,,,kol bache haro mikeshe biron
        {
            var category = Get(categoryID);
            return db.Categories.Where(x => x.LineAge.StartsWith(category.LineAge)).ToList();// این همه بچه های درخت رو از بالا تا پایین به دست میاره
        }

        public List<FastCatList> GetDrp()
        {
            return db.Categories.Select(x => new FastCatList { CategoryID = x.CategoryID, CategoryName = x.CategoriesName }).ToList();
        }

        public bool HasChildCategory(int categoryID)
        {
            return db.Categories.Any(x=>x.CategoryID == categoryID);
        }

        public bool HasRelatedProduct(int categoryID)
        {
            return db.Products.Any(x => x.CategoryID == categoryID);
        }

        public void IncrementParentDirectChildCount(int categoryID)
        {
            var cat = Get(categoryID);
            if(cat.ParentID != null)
            {
                var parent = Get(cat.ParentID.Value);//in babash ro be dast miareh
                parent.DirectChildCount = parent.DirectChildCount + 1;//in be tedade bache haie babash ezafe mikone
                db.SaveChanges();
            }
        }

        public OperationResult Register(Category current)
        {
            OperationResult op = new OperationResult("Register Category");
            try
            {
                db.Categories.Add(current);
                db.SaveChanges();
                return op.ToSuccess("Category Registered Successfull");
            }
            catch (Exception ex)
            {
                return op.ToFail("Category Insertion Failed");
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Remove Category");
            try
            {
                var cat = db.Categories.FirstOrDefault(x => x.CategoryID == id);
                db.Categories.Remove(cat); 
                db.SaveChanges();
                return op.ToSuccess("Category Remove Successfull");
            }
            catch (Exception ex)
            {
                return op.ToFail("Category Removement failed");
            }
        }

        public void RemoveCategoryFeatures(int categoryID)
        {
            var Category = Get(categoryID);
            var CategoryFeatures = Category.CategoryFeatures.ToList();
            foreach(CategoryFeature item in CategoryFeatures)
            {
                db.CategoryFeatures.Remove(item);
            }
            db.SaveChanges();
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount)
        {
            if(sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            var q = from cat in db.Categories select cat;
            if(!string.IsNullOrEmpty(sm.CategoryName))
            {
                q = q.Where(x => x.CategoriesName.StartsWith(sm.CategoryName));
            }
            if (sm.ParentID != null)//این جا میگیم اگه پرنت ای دی رو سرچ کرده بود 
            {
                q = q.Where(x => x.ParentID == sm.ParentID);
            }
            RecordCount = q.Count();
            return q.Select(x => new CategoryListItem //in ja migim ke baraie vorodi category begir va categorylistItem bargardon
            {
                CategoryID = x.CategoryID,
                CategoriesName = x.CategoriesName,
                ProductCount = x.ProductCount,
                SortOrder = x.SortOrder,
            }).OrderByDescending(x=>x.SortOrder).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult SetLinage(string Linage, int categoryID)
        {
            OperationResult op = new OperationResult("Set Lineage Category");
            try
            {
                var cat = Get(categoryID);// dar in ja category ro esteghraj mikonim va az database mikeshim biron
                cat.LineAge = Linage;
                db.SaveChanges();
                return op.ToSuccess("Lineage Set Successfully");
            }
            catch(Exception ex)
            {
                return op.ToFail("Lineage Set Failed" + ex.Message);
            }
        }

        public OperationResult Update(Category current)
        {
            OperationResult op = new OperationResult("Update Category");
            try
            {
                var cat = Get(current.CategoryID);
                cat.CategoriesName = current.CategoriesName;
                cat.ParentID =  current.ParentID;
                cat.SortOrder = current.SortOrder;
                cat.Description = current.Description;
                db.SaveChanges();
                return op.ToSuccess("Category Update Successfull");
            }
            catch(Exception ex)
            {
                return op.ToFail("Category Update Failed" + ex.Message);
            }
        }
    }
}
