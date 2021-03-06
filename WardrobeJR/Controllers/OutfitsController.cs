﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeJR.Models;
using WardrobeJR.ViewModels;

namespace WardrobeJR.Controllers
{
    public class OutfitsController : Controller
    {
        private WardrobeJRContext db = new WardrobeJRContext();

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.Bottom).Include(o => o.Shoe).Include(o => o.Top);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create()
        {
            ViewBag.BottomId = new SelectList(db.Bottoms, "BottomId", "BottomName");
            ViewBag.ShoeId = new SelectList(db.Shoes, "ShoeId", "ShoeName");
            ViewBag.TopId = new SelectList(db.Tops, "TopId", "TopName");
            return View();
        }

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitId,TopId,BottomId,ShoeId")] Outfit outfit)
        {
            if (ModelState.IsValid)
            {
                db.Outfits.Add(outfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BottomId = new SelectList(db.Bottoms, "BottomId", "BottomName", outfit.BottomId);
            ViewBag.ShoeId = new SelectList(db.Shoes, "ShoeId", "ShoeName", outfit.ShoeId);
            ViewBag.TopId = new SelectList(db.Tops, "TopId", "TopName", outfit.TopId);
            return View(outfit);
        }

        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottomId = new SelectList(db.Bottoms, "BottomId", "BottomName", outfit.BottomId);
            ViewBag.ShoeId = new SelectList(db.Shoes, "ShoeId", "ShoeName", outfit.ShoeId);
            ViewBag.TopId = new SelectList(db.Tops, "TopId", "TopName", outfit.TopId);

            OutfitViewModel outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,
                // Look up all accessories, then converts them into
                // SelectListItem objects
                AllAccessories = (from a in db.Accessories
                                  select new SelectListItem
                                  {
                                      Value = a.AccessoryId.ToString(),
                                      Text = a.AccessoryName
                                  })
            };

            return View(outfitViewModel);
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitId,TopId,BottomId,ShoeId")] Outfit outfit, List<int> SelectedAccessories)
        {
            if (ModelState.IsValid)
            {
                // create a variable to access the data in the database
                var existingOutfit = db.Outfits.Find(outfit.OutfitId);

                // change the existing properties to the new properties
                existingOutfit.TopId = outfit.TopId;
                existingOutfit.BottomId = outfit.BottomId;
                existingOutfit.ShoeId = outfit.ShoeId;

                existingOutfit.Accessories.Clear();

                foreach (int accessoryId in SelectedAccessories)
                {
                    // find the accessory by its id and add it to the existing outfit
                    existingOutfit.Accessories.Add(db.Accessories.Find(accessoryId));
                }
                    
                //the below line takes the outfit that came from the user
                //and saves it directly to the database
                //we don't want to do this because we need to attach accessories to it!
                //db.Entry(outfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottomId = new SelectList(db.Bottoms, "BottomId", "BottomName", outfit.BottomId);
            ViewBag.ShoeId = new SelectList(db.Shoes, "ShoeId", "ShoeName", outfit.ShoeId);
            ViewBag.TopId = new SelectList(db.Tops, "TopId", "TopName", outfit.TopId);
            return View(outfit);
        }

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            db.Outfits.Remove(outfit);
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
