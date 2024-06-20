using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModelM.ModelsM
{
    public class CategoryFeature
    {
        public int CategoryFeatureID { get; set; }

        public int CategoryID { get; set; }

        public int FeatureID { get; set; }

        public CategoryM category { get; set; }

        public Feature feature { get; set; }
    }
}
