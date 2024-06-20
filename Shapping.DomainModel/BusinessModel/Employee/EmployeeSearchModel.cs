using FramWork.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.BusinessModel.Employee
{
	public class EmployeeSearchModel:PageModel
	{

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Age { get; set; }
    }
}
