using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.BusinessModel.Category
{
    public class CategoryListItem//in property haii hast ke ma mighaim  dar grid namaiesh midim
    {
        public int CategoryID { get; set; }

        public string CategoriesName { get; set; }

        public int SortOrder { get; set; }

        public int ProductCount { get; set; }
    }
}
