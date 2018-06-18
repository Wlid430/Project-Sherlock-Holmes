using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class tblImagesController : Controller
    {
        private PGA_HROEntities db = new PGA_HROEntities();

        // GET: tblImages
        public ActionResult Index() => View(db.tblImages.ToList().Take(10));

        // GET: tblImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblImage tblImage = db.tblImages.Find(id);
            if (tblImage == null)
            {
                return HttpNotFound();
            }
            return View(tblImage);
        }

        // GET: tblImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imgId,imgLabel,imgDescription,imgFileName,imgContentType,imgWidth,imgHeight,imgCreationDate,imgIsInActive")] tblImage tblImage)
        {
            if (ModelState.IsValid)
            {
                db.tblImages.Add(tblImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblImage);
        }

        // GET: tblImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblImage tblImage = db.tblImages.Find(id);
            if (tblImage == null)
            {
                return HttpNotFound();
            }
            return View(tblImage);
        }

        // POST: tblImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imgId,imgLabel,imgDescription,imgFileName,imgContentType,imgWidth,imgHeight,imgCreationDate,imgIsInActive")] tblImage tblImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblImage);
        }

        // GET: tblImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblImage tblImage = db.tblImages.Find(id);
            if (tblImage == null)
            {
                return HttpNotFound();
            }
            return View(tblImage);
        }

        // POST: tblImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblImage tblImage = db.tblImages.Find(id);
            db.tblImages.Remove(tblImage);
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
