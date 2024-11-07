using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BanHoaQua.Models
{
    public class HoaQuasController : Controller
    {
        private BanHoaQuaEntities db = new BanHoaQuaEntities();

        // GET: HoaQuas
        public ActionResult Index()
        {
            var hoaQua = db.HoaQua.Include(h => h.ThuongHieu);
            return View(hoaQua.ToList());
        }

        // GET: HoaQuas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaQua hoaQua = db.HoaQua.Find(id);
            if (hoaQua == null)
            {
                return HttpNotFound();
            }
            return View(hoaQua);
        }

        // GET: HoaQuas/Create
        public ActionResult Create()
        {
            ViewBag.MaTH = new SelectList(db.ThuongHieu, "MaTH", "TenTH");
            return View();
        }

        // POST: HoaQuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masp,MaTH,Tensp,Tinhtrang,Gia,Soluong")] HoaQua hoaQua)
        {
            if (ModelState.IsValid)
            {
                db.HoaQua.Add(hoaQua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTH = new SelectList(db.ThuongHieu, "MaTH", "TenTH", hoaQua.MaTH);
            return View(hoaQua);
        }

        // GET: HoaQuas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaQua hoaQua = db.HoaQua.Find(id);
            if (hoaQua == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTH = new SelectList(db.ThuongHieu, "MaTH", "TenTH", hoaQua.MaTH);
            return View(hoaQua);
        }

        // POST: HoaQuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masp,MaTH,Tensp,Tinhtrang,Gia,Soluong")] HoaQua hoaQua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaQua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTH = new SelectList(db.ThuongHieu, "MaTH", "TenTH", hoaQua.MaTH);
            return View(hoaQua);
        }

        // GET: HoaQuas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaQua hoaQua = db.HoaQua.Find(id);
            if (hoaQua == null)
            {
                return HttpNotFound();
            }
            return View(hoaQua);
        }

        // POST: HoaQuas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaQua hoaQua = db.HoaQua.Find(id);
            db.HoaQua.Remove(hoaQua);
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
