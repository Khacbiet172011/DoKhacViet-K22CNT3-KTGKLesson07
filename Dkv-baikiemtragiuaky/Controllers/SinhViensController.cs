using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dkv_baikiemtragiuaky.Models;

namespace Dkv_baikiemtragiuaky.Controllers
{
    public class SinhViensController : Controller
    {
        private QLDiemEntities db = new QLDiemEntities();

        // GET: SinhViens
        public ActionResult DkvIndex()
        {
            var sinhVien = db.SinhVien.Include(s => db.Khoa);
            return View(sinhVien.ToList());
        }

        // GET: SinhViens/Details/5
        public ActionResult DkvDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public ActionResult DkvCreate()
        {
            ViewBag.MAKHOA = new SelectList(db.Khoa, "MAKHOA", "TENKHOA");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DkvCreate([Bind(Include = "MASV,HOSV,TENSV,PHAI,NS,MAKHOA")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhVien.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("DkvIndex");
            }

            ViewBag.MAKHOA = new SelectList(db.Khoa, "MAKHOA", "TENKHOA", sinhVien.MAKHOA);
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public ActionResult DkvEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKHOA = new SelectList(db.Khoa, "MAKHOA", "TENKHOA", sinhVien.MAKHOA);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DkvEdit([Bind(Include = "MASV,HOSV,TENSV,PHAI,NS,MAKHOA")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DkvIndex");
            }
            ViewBag.MAKHOA = new SelectList(db.Khoa, "MAKHOA", "TENKHOA", sinhVien.MAKHOA);
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public ActionResult DkvDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("DkvDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SinhVien sinhVien = db.SinhVien.Find(id);
            db.SinhVien.Remove(sinhVien);
            db.SaveChanges();
            return RedirectToAction("DkvIndex");
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
