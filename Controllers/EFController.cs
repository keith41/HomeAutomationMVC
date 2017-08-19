using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeAutomationMVC.DAL;

namespace HomeAutomationMVC.Controllers
{
    [Authorize]
    public class EFController : Controller
    {
        private ksalomon_listEntities db = new ksalomon_listEntities();

        //
        // GET: /EF/

        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        //
        // GET: /EF/Details/5

        public ActionResult Details(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // GET: /EF/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EF/Create

        [HttpPost]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        //
        // GET: /EF/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // POST: /EF/Edit/5

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        //
        // GET: /EF/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // POST: /EF/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}