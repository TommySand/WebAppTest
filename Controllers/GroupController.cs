using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppTest;
using WebAppTest.Models;
using System.IO;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Forms;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace WebAppTest.Controllers
{
    public class GroupController : Controller
    {
        InventoryEntities db = new InventoryEntities();

        public ActionResult Index()
        {
            var data = db.Medals.OrderByDescending(z => z.MedalFamily).Select(s => s).ToList();
            return View(data);
        }

        // GET: Medals/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Medal obj)
        {
            if (ModelState.IsValid)
            {
                var isMedalFamilyExists = db.Medals.Any(x => x.MedalFamily == obj.MedalFamily);
                if (isMedalFamilyExists)
                {
                    ModelState.AddModelError("Medal", "MedalFamily already exists");
                    return View(obj);
                }
                

                //User newobj = new User();
                //newobj.UserName = obj.UserName;
                //newobj.Email = obj.Email;
                //newobj.Password = obj.Password;
                //newobj.Address = obj.Address;
                //db.User.Add(newobj);
                //db.SaveChanges();
                //return RedirectToAction("Index");

            }

            return View(obj);
        }
    }
}