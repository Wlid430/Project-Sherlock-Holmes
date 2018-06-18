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
    public class tblSubjectsController : Controller
    {
        private PGA_HROEntities1 db = new PGA_HROEntities1();

        // GET: tblSubjects
        public ActionResult Index() => View(db.tblSubjects.ToList().Take(10));

        // GET: tblSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubject tblSubject = db.tblSubjects.Find(id);
            if (tblSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblSubject);
        }

        // GET: tblSubjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sjId,sjBSN,sjGender,sjDateOfBirth,sjDateOfDeath,sjMaritalStatusId,sjIsInactive,sjAnonymisedOn,sjWoonplaatsSource,sjWoonplaatsId")] tblSubject tblSubject)
        {
            if (ModelState.IsValid)
            {
                db.tblSubjects.Add(tblSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSubject);
        }

        // GET: tblSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubject tblSubject = db.tblSubjects.Find(id);
            if (tblSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblSubject);
        }

        // POST: tblSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sjId,sjBSN,sjGender,sjDateOfBirth,sjDateOfDeath,sjMaritalStatusId,sjIsInactive,sjAnonymisedOn,sjWoonplaatsSource,sjWoonplaatsId")] tblSubject tblSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSubject);
        }

        // GET: tblSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubject tblSubject = db.tblSubjects.Find(id);
            if (tblSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblSubject);
        }

        // POST: tblSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSubject tblSubject = db.tblSubjects.Find(id);
            db.tblSubjects.Remove(tblSubject);
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
