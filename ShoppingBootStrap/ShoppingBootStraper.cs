using DataAccess.Shopping.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Application;
using Shopping.ApplicationServiceContract.Services;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BootStrap
{
	public static class ShoppingBootStraper
	{
		public static void WireUp(IServiceCollection services, string ShoppingConnectionString)
		{
			services.AddDbContext<Shapping.DomainModel.Models.ShoppingMashtiHasanContext>
				(optionsAction =>
				{
					optionsAction.UseSqlServer(ShoppingConnectionString);
				}, ServiceLifetime.Scoped);
			services.AddScoped<ICategoryRepositrory, CategoryRepository>();
			services.AddScoped<ISupplierRepository, SupplierRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();

			services.AddScoped<ICategoryApplication, CategoryApplication>();
			services.AddScoped<ISupplierApplication, SupplierApplication>();
			services.AddScoped<IProductApplication, ProductApplication>();

            services.AddScoped<IEmployeeApplication, EmployeeApplication>();
		}
	}
}
