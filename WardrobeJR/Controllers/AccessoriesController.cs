using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeJR.Models;

namespace WardrobeJR.Controllers
{
    public class AccessoriesController : Controller
    {
        private WardrobeJRContext db = new WardrobeJRContext();

        // GET: Accessories
        public ActionResult Index()
        {
            var accessories = db.Accessories.Include(a => a.Color).Include(a => a.Occasion).Include(a => a.Season);
            return View(accessories.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName");
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName");
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName");
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessoryId,AccessoryName,AccessoryPhoto,ColorId,SeasonId,OccasionId")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                db.Accessories.Add(accessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName", accessory.ColorId);
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName", accessory.OccasionId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName", accessory.SeasonId);
            return View(accessory);
        }

        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName", accessory.ColorId);
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName", accessory.OccasionId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName", accessory.SeasonId);
            return View(accessory);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessoryId,AccessoryName,AccessoryPhoto,ColorId,SeasonId,OccasionId")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName", accessory.ColorId);
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName", accessory.OccasionId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName", accessory.SeasonId);
            return View(accessory);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessory accessory = db.Accessories.Find(id);
            db.Accessories.Remove(accessory);
            db.SaveChanges();
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
