using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XQ.WebUI.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int WorkEdit(int workId)
        {
            return workId;
        }
    }
}