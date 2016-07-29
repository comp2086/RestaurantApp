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
    public class DessertsController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Desserts
        public async Task<ActionResult> Index()
        {
			ViewBag.Title = "Desserts";
			ViewBag.Data = await db.Desserts.ToListAsync();
			return View("MenuItems/Index");
        }

        // GET: Desserts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dessert dessert = await db.Desserts.FindAsync(id);
            if (dessert == null)
            {
                return HttpNotFound();
            }
            return View("MenuItems/Details", dessert);
        }

        // GET: Desserts/Create
        public ActionResult Create()
        {
            return View("MenuItems/Create");
        }

        // POST: Desserts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DessertId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                db.Desserts.Add(dessert);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("MenuItems/Create", dessert);
        }

        // GET: Desserts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dessert dessert = await db.Desserts.FindAsync(id);
            if (dessert == null)
            {
                return HttpNotFound();
            }
            return View("MenuItems/Edit", dessert);
        }

        // POST: Desserts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DessertId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dessert).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("MenuItems/Index");
            }
            return View("MenuItems/Edit", dessert);
        }

        // GET: Desserts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dessert dessert = await db.Desserts.FindAsync(id);
            if (dessert == null)
            {
                return HttpNotFound();
            }
            return View("MenuItems/Delete", dessert);
        }

        // POST: Desserts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dessert dessert = await db.Desserts.FindAsync(id);
            db.Desserts.Remove(dessert);
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
