using FramWork.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.BusinessModel.Category
{
    public class CategorySearchModel:PageModel//in iani search ma bar asase in property ha in paiin neveshte shodan anjam mishe
    {
        public int? ParentID { get; set; }

        public string CategoryName { get; set; }
    }
}
