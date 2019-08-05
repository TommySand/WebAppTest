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

namespace WebAppTest.Controllers
{
    public class MedalsController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Medals
        public async Task<ActionResult> Index()
        {
            return View(await db.Medals.ToListAsync());
        }

        // GET: Medals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medal medal = await db.Medals.FindAsync(id);
            if (medal == null)
            {
                return HttpNotFound();
            }
            return View(medal);
        }

        // GET: Medals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MedalID,MedalName,MedalGroup,MedalQuantity,MedalPrice,MedalFamily,MedalSize")] Medal medal)
        {
            if (ModelState.IsValid)
            {
                db.Medals.Add(medal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(medal);
        }

        // GET: Medals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medal medal = await db.Medals.FindAsync(id);
            if (medal == null)
            {
                return HttpNotFound();
            }
            return View(medal);
        }

        // POST: Medals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MedalID,MedalName,MedalGroup,MedalQuantity,MedalPrice,MedalFamily,MedalSize")] Medal medal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(medal);
        }

        // GET: Medals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medal medal = await db.Medals.FindAsync(id);
            if (medal == null)
            {
                return HttpNotFound();
            }
            return View(medal);
        }

        // POST: Medals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Medal medal = await db.Medals.FindAsync(id);
            db.Medals.Remove(medal);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
