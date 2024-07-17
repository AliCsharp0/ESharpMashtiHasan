using Shapping.DomainModel.BusinessModel.Employee;
using Shapping.DomainModel.BusinessModel.Product;

namespace ESharpMashtiHasan.Models
{
	public class EmployeeListAndSearchModel
	{
		public EmployeeSearchModel sm { get; set; }

		public List<EmployeeListItem> employeeListItems { get; set; }
	}
}
