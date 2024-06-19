using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models
{
    public class Category
    {
        public int CategoryID {  get; set; }

        public string CategoriesName { get; set; }

        public string Description {  get; set; }

        public int SortOrder {  get; set; }//baraie bala ia paiin gharar gereftan iek onsor nesbat be iek orser dige be kar mire

        public ICollection<Product> Products { get; set; }

        public ICollection<CategoryFeature> CategoryFeatures { get; set; }

        public int? ParentID { get; set; }

        public Category Parent { get; set; }//والدین

        public string LineAge { get; set; }//در درخت به ای دی خودش به همراه پدرش میگن لاین ایج 12 و25,,,,ba lineage mishe hame pedar haro dasht

        public int DirectChildCount { get; set; }//تعداد مستقیم فرزندان

        public int ProductCount { get; set; }// تعداد محصولات که در این کتگوری وجود دارن

        public ICollection<Category> children { get; set; }//فرزندان

        public Category()
        {
            this.Products = new List<Product>();
            this.CategoryFeatures = new List<CategoryFeature>();
            this.children = new List<Category>();
        }
    }
}
