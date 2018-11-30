using Bootcamp20.API.DataAccess.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp20.Client.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(SupplierParam supplierparam)
        //{
        //    return View(supplierparam);
        //}
        public ActionResult Get(int? id)
        {
            return View();
        }
        //public ActionResult Delete(int? id)
        //{

        //}
    }
}