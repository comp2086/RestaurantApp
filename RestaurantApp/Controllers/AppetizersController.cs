using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class AppetizersController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Appetizers
        public async Task<ActionResult> Index()
        {
			ViewBag.Title = "Appetizers";
			ViewBag.Data = await db.Appetizers.ToListAsync();
            return View("MenuItems/Index");
		}

        // GET: Appetizers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appetizer appetizer = await db.Appetizers.FindAsync(id);
            if (appetizer == null)
            {
                return HttpNotFound();
            }
            return View("MenuItems/Details", appetizer);
        }

        // GET: Appetizers/Create
        public ActionResult Create()
        {
            return View("MenuItems/Create");
        }

        // POST: Appetizers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AppetizerId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] Appetizer appetizer)
        {
            if (ModelState.IsValid)
            {
                db.Appetizers.Add(appetizer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("MenuItems/Create", appetizer);
        }

        // GET: Appetizers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appetizer appetizer = await db.Appetizers.FindAsync(id);
            if (appetizer == null)
            {
                return HttpNotFound();
            }
            return View("MenuItems/Edit", appetizer);
        }

        // POST: Appetizers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AppetizerId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] Appetizer appetizer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appetizer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("MenuItems/Index");
            }
            return View("MenuItems/Edit", appetizer);
        }

        // GET: Appetizers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appetizer appetizer = await db.Appetizers.FindAsync(id);
            if (appetizer == null)
            {
                return HttpNotFound();
            }
            return View("MenuItems/Delete", appetizer);
        }

        // POST: Appetizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Appetizer appetizer = await db.Appetizers.FindAsync(id);
            db.Appetizers.Remove(appetizer);
            await db.SaveChangesAsync();
            return RedirectToAction("MenuItems/Index");
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
