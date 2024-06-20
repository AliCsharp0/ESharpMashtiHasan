using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Employee;
using Shapping.DomainModel.Models;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.Shopping.EF
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ShoppingMashtiHasanContext db;

        public EmployeeRepository(ShoppingMashtiHasanContext db)
        {
            this.db = db;
        }

        public bool ExistEmployeeNameForAnotherEmployee(int EmployeeID, string FirstName, string LastName)
		{
			return db.Employees.Any(x => x.EmployeeID != EmployeeID && x.FirstName == FirstName && x.LastName == LastName);
		}

		public Employee Get(int id)
		{
			return db.Employees.FirstOrDefault(x => x.EmployeeID == id);
		}

		public List<Employee> GetAll()
		{
			return db.Employees.ToList();
		}

		public OperationResult Register(Employee current)
		{
			OperationResult op = new OperationResult("Register Employee");
			try
			{
				db.Employees.Add(current);
				db.SaveChanges();
				return op.ToSuccess("Employee Register Success Fully");
			}
			catch(Exception ex) 
			{
				return op.ToFail("Employee Register Failed" + ex.Message);
			}
		}

		public OperationResult Remove(int id)
		{
			OperationResult op = new OperationResult("Remove Employee");
			try
			{
				var emp = Get(id);
				db.Employees.Remove(emp);
				return op.ToSuccess("Employee Delete Success Fully");
			}
			catch(Exception ex)
			{
				return op.ToFail("Employee Delete Failed" + ex.Message);
			}
		}

		public List<EmployeeListItem> Search(EmployeeSearchModel sm, out int RecordCount)
		{
			if(sm.PageSize == 0)
			{
				sm.PageSize = 5;
			}
			var q = from emp in db.Employees select emp;
			if (!string.IsNullOrEmpty(sm.FirstName))
			{
				q = q.Where(x => x.FirstName.StartsWith(sm.FirstName));
			}
			if(!string.IsNullOrEmpty(sm.LastName))
			{
				q = q.Where(x=>x.LastName.StartsWith(sm.LastName));
			}
			if(sm.Age != null || sm.Age < 1)
			{
				q = q.Where(x=>x.Age == sm.Age);
			}
			RecordCount = q.Count();

			q = q.OrderByDescending(x => x.EmployeeID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize);

			var q2 = from emp in q
					 select new EmployeeListItem 
					 { 
						 EmployeeID = emp.EmployeeID,
						 FirstName = emp.FirstName,
						 LastName = emp.LastName,
						 AddressID = emp.AddressID,
						 Age = emp.Age,
						 Evidence = emp.Evidence,
						 MobileNumber = emp.MobileNumber,
						 Position = emp.Position,
					 };
			return q2.ToList();
		}

		public OperationResult Update(Employee current)
		{
			OperationResult op = new OperationResult("Update Employee");
			try
			{
				db.Employees.Attach(current);
				db.Entry<Employee>(current).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				db.SaveChanges();
				return op.ToSuccess("Update Employee Success Fully");
			}
			catch(Exception ex)
			{
				return op.ToFail("Update Employee Failed");
			}
		}
	}
}
