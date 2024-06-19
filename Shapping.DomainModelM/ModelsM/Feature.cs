using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModelM.ModelsM
{
    public class Feature
    {
        public int FeatureID { get; set; }

        public string FeatureName { get; set; }

        public ICollection<CategoryFeature> Cfeatures { get; set; }

        public ICollection<ProductFeature> Pfeatures { get; set; }

        public Feature()
        {
            this.Cfeatures = new List<CategoryFeature>();

            this.Pfeatures = new List<ProductFeature>();

        }
    }
}
