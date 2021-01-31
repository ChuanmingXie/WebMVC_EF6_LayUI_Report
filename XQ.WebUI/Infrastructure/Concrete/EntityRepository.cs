using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XQ.Domain.Concrete;
using XQ.WebUI.Infrastructure.Abstract;
using XQ.WebUI.Models;

namespace XQ.WebUI.Infrastructure.Concrete
{
	public class EntityRepository : IEntityRepository
	{
		private EFDbcontext EntityContext = new EFDbcontext();

		public List<CustomerModel> GetCustomerModels()
		{
			var customerModel = from Customer in EntityContext.Customers
								select new CustomerModel
								{
									CustomerId = Customer.CustomerId,
									ProjectId = Customer.ProjectId,
									CustomerCode = Customer.CustomerCode,
									CustomerName = Customer.CustomerName
								};
			return customerModel.ToList();
		}

		public List<ProjectModel> GetProjectModels()
		{
			var projectModel = from Projects in EntityContext.Projects
							   select new ProjectModel
							   {
								   ProjectId = Projects.ProjectId,
								   ProjectCode = Projects.ProjectCode,
								   ProjectDesc = Projects.ProjectDesc
							   };
			return projectModel.ToList();
		}
	}
}