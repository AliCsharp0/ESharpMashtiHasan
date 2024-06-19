using FramWork.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.BusinessModel.Product
{
    public class ProductSearchModel : PageModel
    {
        public int? CategoryID { get; set; }

        public int? SupplierID { get; set; }

        public int? UintPriceFrom { get; set; }

        public int? UintPriceTo { get; set; }

        public string? ProductName { get; set; }

        public string? Slug { get; set; }
    }

}
