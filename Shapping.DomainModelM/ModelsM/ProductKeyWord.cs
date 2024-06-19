using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModelM.ModelsM
{
    public class ProductKeyWord
    {
        public int ProductID { get; set; }

        public int KeyWordID { get; set; }

        public KeyWord key { get; set; }

        public ProductM product { get; set; }
    }
}
