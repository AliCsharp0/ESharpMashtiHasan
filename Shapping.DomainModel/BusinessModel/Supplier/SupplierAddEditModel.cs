using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.BusinessModel.Supplier
{
    public class SupplierAddEditModel
    {
        public int SupplierID { get; set; }
        [Required(ErrorMessage ="لطفا نام فراهم کننده را وارد کنید")]
        [StringLength(50 , ErrorMessage ="نام باید بین 3 تا 50 کارکتر باشد",MinimumLength =3)]
        public string SupplierName { get; set; }

        public string SupplierDescription { get; set; }
    }
}
