using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.BusinessModel.Product
{
    public class ProductAddEditModel 
    {

        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public string ProductName { get; set; }

        public long UnitPrice { get; set; }

        public string Description { get; set; }

        public string Slup { get; set; }

        public string PageTitle { get; set; } 

        public string MetaKeyWord { get; set; }

        public string MataDescription { get; set; }

        public string JSONLDInformation { get; set; }

        public string ImagUrl { get; set; }

        public int SupplierID { get; set; }
    }
}
