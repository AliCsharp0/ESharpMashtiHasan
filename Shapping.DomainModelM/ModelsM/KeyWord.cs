using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModelM.ModelsM
{
    public class KeyWord
    {
        public int keyWordID { get; set; }

        public string keyWordText { get; set; }

        public ICollection<ProductKeyWord> productKeyWords { get; set; }

        public KeyWord()
        {
            this.productKeyWords = new List<ProductKeyWord>();
        }
    }
}
