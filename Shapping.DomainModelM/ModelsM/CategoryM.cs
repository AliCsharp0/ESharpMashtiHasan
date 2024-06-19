using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModelM.ModelsM
{
    public class CategoryM
    {
        public int CategoryID { get; set; }

        public string CategoriesName { get; set; }

        public string Description { get; set; }

        public int SortOrder { get; set; }

        public ICollection<ProductM> productMs { get; set; }

        public ICollection<CategoryFeature> categories { get; set; }

        public CategoryM()
        {
          this.productMs = new List<ProductM>();
          this.categories = new List<CategoryFeature>();
        }

    }
}
