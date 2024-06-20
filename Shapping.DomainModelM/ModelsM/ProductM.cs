using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModelM.ModelsM
{
    public class ProductM
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

        public CategoryM CategoryM { get; set; }

        public ICollection<ProductFeature> products { get; set; }

        public ICollection<ProductKeyWord> productKeyWords { get; set; }

        public ProductM()
        {
            this.products = new List<ProductFeature>();

            this.productKeyWords = new List<ProductKeyWord>();
        }
    }
}
