﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models
{
    public class ProductFeature
    {
        public int ProductFeatureID { get; set; }

        public int ProductID { get; set; }

        public int FeatureID { get; set; }

        public int EffectOnUnitPrice { get; set; }//in baraie +unitprice ia -unitPric  Hast mesal rang blak phone unitprice bishtar az rang red hast

        public string FeatureValue { get; set; }

        public Product product { get; set; }

        public Feature feature { get; set; }
    }
}
