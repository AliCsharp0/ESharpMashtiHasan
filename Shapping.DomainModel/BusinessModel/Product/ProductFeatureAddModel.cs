using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.BusinessModel.Product
{
    public class ProductFeatureAddModel
    {
        public string FeatureName { get; set; }

        public int ProductID { get; set; }

        public string FeatureValue { get; set; }

        public int EffectOnUnitPrice { get; set; }
    }
}
