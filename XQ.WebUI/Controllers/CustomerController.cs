using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XQ.Domain.Abstract;
using XQ.WebUI.Infrastructure.Abstract;
using XQ.WebUI.Models;

namespace XQ.WebUI.Controllers
{
    public class CustomerController : Controller
    {
		private readonly ICustomersRepository ICustomers;
		private IEntityRepository IEntityCustomer;
		public CustomerController(ICustomersRepository iCustomers, IEntityRepository iEntityCustomer)
		{
			ICustomers = iCustomers;
			IEntityCustomer = iEntityCustomer;
		}
        // GET: Customer
        public ActionResult CustomerIndex()
        {
            return View();
        }

		public JsonResult GetCustomerInfo(int page,int limit)
		{
			List<CustomerModel> customerModel = IEntityCustomer.GetCustomerModels();
			return Json(new
			{
				code = 0,
				msg = "",
				count = customerModel.Count(),
				data = customerModel.Skip((page - 1) * limit).Take(limit).ToArray(),
				page = page,
				limit = limit,
			}, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
        public int CustomerEdit(int customerId)
        {
            return customerId;
        }
    }
}