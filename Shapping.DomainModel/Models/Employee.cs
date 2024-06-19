using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public int AddressID { get; set; }

        public int Age { get; set; }

        public string FirstName{ get; set; }

        public string LastName { get; set; }

        public string Evidence { get; set; }

        public string Position { get; set; }

        public string MobileNumber { get; set; }
    }
}
