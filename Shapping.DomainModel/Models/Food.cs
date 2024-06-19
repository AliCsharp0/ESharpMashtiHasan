using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models
{
    public class Food
    {
        public int FoodID { get; set; }

        public string FoodName { get; set; }

        public string FoodIngredients{ get; set; }

        public int UnitPrice { get; set; }
    }
}
