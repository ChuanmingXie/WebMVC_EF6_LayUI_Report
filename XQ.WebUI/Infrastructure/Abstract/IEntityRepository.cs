using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.WebUI.Models;

namespace XQ.WebUI.Infrastructure.Abstract
{
	public interface IEntityRepository
	{
		List<ProjectModel> GetProjectModels();

		List<CustomerModel> GetCustomerModels();
	}
}
