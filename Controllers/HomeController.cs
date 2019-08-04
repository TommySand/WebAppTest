using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTest.Models;

namespace WebAppTest.Controllers
{
    public class HomeController : Controller
    {

        InventoryEntities entities = new InventoryEntities();
        public ActionResult Index()
        {
            var query = from i in entities.Inventories select new Medal { Inventory = i };

            var model = query.ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult InventoryTest()
        {
            ViewBag.Message = "Inventory.";

            return View();
    }

}
}