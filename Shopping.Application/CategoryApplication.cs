using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Category;
//using Shapping.DomainModel.BusinessModel.Category02;
using Shapping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Services;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepositrory repo; //BE  in migan inject kardan

        public CategoryApplication(ICategoryRepositrory repo)
        {
            this.repo = repo;
        }

        public CategoryAddEditModel Get(int CategoryID)
        {
            var cat = repo.Get(CategoryID);
            CategoryAddEditModel c = new CategoryAddEditModel
            {
                CategoryID = CategoryID,
                CategoriesName = cat.CategoriesName,
                Description = cat.Description,
                ParentID = cat.ParentID,
                SortOrder = cat.SortOrder,
            };
            return c;
        }

        public List<FastCatList> GetDrp()
        {
            return repo.GetDrp();
        }

        public OperationResult Register(CategoryAddEditModel model)
        {
            Category category = new Category
            {
                CategoriesName = model.CategoriesName,
                Description = model.Description,
                DirectChildCount = 0,
                ParentID = model.ParentID,
                ProductCount = 0,
                SortOrder = model.SortOrder,
            };
            var op = repo.Register(category);
            //وقتی کتگوری ثبت میشه این اتفاق های پایین باید انجام شوند 
            //DirectChildCountParent
            //saghte shodane LinAge va Update Shodane LinAge
            repo.IncrementParentDirectChildCount(op.RecordID.Value);
            var lineage = repo.GenerateLinage(op.RecordID.Value);
            repo.SetLinage(lineage, op.RecordID.Value);
            return op;
        }

        public OperationResult Remove(int categoryID)
        {
            if (repo.HasChildCategory(categoryID))//in mige agar child category dasht Delete nakon
            {
                return new OperationResult("Remove Category").ToFail("Category Has Related Child Category" + categoryID);
            }
            if (repo.HasRelatedProduct(categoryID))//in mige agar product dasht Delete nakon
            {
                return new OperationResult("Remove Category").ToFail("Category Has Related Child Product" + categoryID);
            }
            repo.DeccrementParentDirectChildCount(categoryID);
            repo.RemoveCategoryFeatures(categoryID);//in ja CategoryFeatures delete mikone
            var op = repo.Remove(categoryID);
            return op;
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount)
        {
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult Update(CategoryAddEditModel newCat)
        {
            if (repo.ExistCategoryName(newCat.CategoriesName , newCat.CategoryID))
            {
                return new OperationResult("Update Category").ToFail("" + newCat.CategoryID);
            }
            var c = new Category
            {
                CategoryID = newCat.CategoryID,
                CategoriesName = newCat.CategoriesName,
                Description = newCat.Description,
                SortOrder = newCat.SortOrder,
            };
            var oldCat = repo.Get(newCat.CategoryID);
            if(oldCat.ParentID == newCat.ParentID)// on ja mige age parentID ro update ia taghir nadadeh bod.
            {
                return repo.Update(c);
            }
            else
            {
                var op = repo.Update(c);
                bool s = false;
                if(op.Success)
                {
                    s = repo.GenerateAndSetLineageOnUpdateParentIDForNodeAndItsChildren(newCat.CategoryID, newCat.ParentID);
                }
                if(s && op.Success)
                {
                    return op;
                }
                else
                {
                  return op.ToFail("Update Failed" + newCat.CategoryID);
                }
            }
        }
    }
}
