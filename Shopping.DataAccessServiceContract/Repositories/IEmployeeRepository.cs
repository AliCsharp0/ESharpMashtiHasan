using FramWork.BaseRepository;
using Shapping.DomainModel.BusinessModel.Employee;
using Shapping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccessServiceContract.Repositories
{
	public interface IEmployeeRepository:IBaseRepositorySearchable<Employee , int , EmployeeSearchModel , EmployeeListItem>
	{
		bool ExistEmployeeNameForAnotherEmployee( int EmployeeID , string FirstName , string LastName);

	}
}
