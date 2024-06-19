using Shapping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.BusinessModel.Category
{
    public class CategoryAddEditModel//in ja chiz haii ke az karbar mikhaim begirim ro mizarim
    {
        public int CategoryID { get; set; }

        public string CategoriesName { get; set; }

        public string Description { get; set; }

        public int SortOrder { get; set; }

        public int? ParentID { get; set; }
    }
}
