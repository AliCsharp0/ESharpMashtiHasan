using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public string ProductName { get; set; }

        public long UnitPrice { get; set; }

        public string Description { get; set; }

        public string Slup { get; set; }

        public string PageTitle{ get; set; }

        public string MetaKeyWord { get; set; }

        public string MataDescription { get; set; }

        public string JSONLDInformation { get; set; }

        public string ImagUrl { get; set; }

        public Category category { get; set; }//baraie Rabete iek be N

        public ICollection<ProductKeyWord> ProductKeyWords { get; set; }

        public ICollection<ProductFeature> ProductFeatures { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

        public int SupplierID { get; set; }

        public Supplier supplier { get; set; }

        public Product()
        {
            this.ProductKeyWords = new List<ProductKeyWord>();

            this.ProductFeatures = new List<ProductFeature>();

            this.OrderDetails = new List<OrderDetails>();
        }
    }
}
