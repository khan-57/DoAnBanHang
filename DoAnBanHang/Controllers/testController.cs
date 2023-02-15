using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;

namespace DoAnBanHang.Controllers
{
    public class testController : Controller
    {
        private DB_BanHang1Entities db = new DB_BanHang1Entities();

        // GET: test
        public ActionResult Index()
        {
            var sanPham = db.SanPham.Include(s => s.Loai_SP);
            return View(sanPham.ToList());
        }

        // GET: test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: test/Create
        public ActionResult Create()
        {
            ViewBag.ID_Loai = new SelectList(db.Loai_SP, "ID_Loai", "TenLoai");
            return View();
        }

        // POST: test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SP,ID_Loai,TonKho,TenSP,DonGia,GioiTinh,NgayNhapHang,Image")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Loai = new SelectList(db.Loai_SP, "ID_Loai", "TenLoai", sanPham.ID_Loai);
            return View(sanPham);
        }

        // GET: test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Loai = new SelectList(db.Loai_SP, "ID_Loai", "TenLoai", sanPham.ID_Loai);
            return View(sanPham);
        }

        // POST: test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SP,ID_Loai,TonKho,TenSP,DonGia,GioiTinh,NgayNhapHang,Image")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Loai = new SelectList(db.Loai_SP, "ID_Loai", "TenLoai", sanPham.ID_Loai);
            return View(sanPham);
        }

        // GET: test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
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
