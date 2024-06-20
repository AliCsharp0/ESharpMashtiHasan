using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Employee;
using Shapping.DomainModel.BusinessModel.Product;
using Shapping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Services;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application
{
	public class EmployeeApplication : IEmployeeApplication
	{
		private readonly IEmployeeRepository repo;
        public EmployeeApplication(IEmployeeRepository repo)
        {
            this.repo = repo;	
        }

		private Employee ToModel(EmployeeAddEditModel model)
		{
			Employee employee = new Employee
			{
				EmployeeID = model.EmployeeID,
				AddressID = model.AddressID,
				Age = model.Age,
				Evidence = model.Evidence,
				FirstName = model.FirstName,
				LastName = model.LastName,
				MobileNumber = model.MobileNumber,
				Position = model.Position,
			};
			return employee;
		}

		private EmployeeAddEditModel ToAddEditModel(Employee emp)
		{
			EmployeeAddEditModel employeeAddEditModel = new EmployeeAddEditModel
			{
				EmployeeID = emp.EmployeeID,
				FirstName = emp.FirstName,
				AddressID = emp.AddressID,
				Age = emp.Age,
				Evidence = emp.Evidence,
				LastName = emp.LastName,
				MobileNumber = emp.MobileNumber,
				Position = emp.Position,
			};
			return employeeAddEditModel;
		}

		public EmployeeAddEditModel Get(int id)
		{
			return ToAddEditModel(repo.Get(id));
		}

		public OperationResult Register(EmployeeAddEditModel current)
		{
			if(repo.ExistEmployeeNameForAnotherEmployee(current.EmployeeID , current.FirstName, current.LastName))
			{
				return new OperationResult("Register Employee").ToFail("Duplicate Employee Name");
			}
			Employee emp = ToModel(current);
			return repo.Register(emp);
		}

		public OperationResult Remove(int id)
		{
			return repo.Remove(id);
		}

		public List<EmployeeListItem> Search(EmployeeSearchModel sm, out int RecordCount)
		{
            return repo.Search(sm, out RecordCount);
		}

		public OperationResult Update(EmployeeAddEditModel current)
		{
			if (repo.ExistEmployeeNameForAnotherEmployee(current.EmployeeID, current.FirstName, current.LastName))
			{
				return new OperationResult("Update Employee").ToFail("Duplicate Employee Name");
			}
			var emp = ToModel(current);
			return repo.Update(emp);
		}
	}
}
