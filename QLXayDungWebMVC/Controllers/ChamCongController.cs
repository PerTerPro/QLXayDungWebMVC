using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLXayDungWebMVC.Models;

namespace QLXayDungWebMVC.Controllers
{
    public class ChamCongController : Controller
    {
        private QLCTXayDungContext db = new QLCTXayDungContext();
        Dapper.CongTrinhRepo congtrinhRP = new Dapper.CongTrinhRepo();
        Dapper.ChamCongRepo chamcongRP = new Dapper.ChamCongRepo();
        Dapper.PhongBanRepo phongbanRP = new Dapper.PhongBanRepo();
        Dapper.ChiTietNgayCongRepo chitietRP = new Dapper.ChiTietNgayCongRepo();
        Dapper.NhanVienRepo nhanvienRP = new Dapper.NhanVienRepo();

        // GET: ChamCong
        public async Task<ActionResult> Index()
        {
            //var chamCongs = db.ChamCongs.Include(c => c.CongTrinh).Include(c => c.NhanVien);
            return View(chamcongRP.GetChamCong());

        }

        // GET: ChamCong/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = await db.ChamCongs.FindAsync(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // GET: ChamCong/Create
        public ActionResult Create()
        {
            ViewBag.IdCT = new SelectList(db.CongTrinhs, "IdCT", "TenCT");
            ViewBag.IdNV = new SelectList(db.NhanViens, "IdNV", "HoTen");
            return View();
        }

        // POST: ChamCong/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdChamCong,IdCT,IdNV,NgayCong,NgayBatDau,NgayKetThuc")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.ChamCongs.Add(chamCong);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCT = new SelectList(db.CongTrinhs, "IdCT", "TenCT", chamCong.IdCT);
            ViewBag.IdNV = new SelectList(db.NhanViens, "IdNV", "HoTen", chamCong.IdNV);
            return View(chamCong);
        }

        // GET: ChamCong/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = await db.ChamCongs.FindAsync(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCT = new SelectList(db.CongTrinhs, "IdCT", "TenCT", chamCong.IdCT);
            ViewBag.IdNV = new SelectList(db.NhanViens, "IdNV", "HoTen", chamCong.IdNV);
            return View(chamCong);
        }

        // POST: ChamCong/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdChamCong,IdCT,IdNV,NgayCong,NgayBatDau,NgayKetThuc")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamCong).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCT = new SelectList(db.CongTrinhs, "IdCT", "TenCT", chamCong.IdCT);
            ViewBag.IdNV = new SelectList(db.NhanViens, "IdNV", "HoTen", chamCong.IdNV);
            return View(chamCong);
        }

        // GET: ChamCong/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = await db.ChamCongs.FindAsync(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // POST: ChamCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = await db.ChamCongs.FindAsync(id);
            db.ChamCongs.Remove(chamCong);
            await db.SaveChangesAsync();
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

        //    public async Task<ActionResult> DanhSachNhanSu(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }

        //        ChamCong chamCong = db.ChamCongs.Find(id);
        //        ViewBag.NhanVien = new List<NhanVien>();

        //        //Bảng NhanVien Include ChamCong. Đưa ra ICollection NhanVien với Điều kiện NhanVien đó tham gia công trình có IdCT tương ứng
        //        ViewBag.NhanVien = db.NhanViens.Include(u => u.ChamCongs).Where(u => u.ChamCongs.Any(x => x.IdCT == chamCong.IdCT));
        //        if (chamCong == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(chamCong);
        //    }


        public async Task<ActionResult> DanhSachChamCong()
        {
            return View(congtrinhRP.GetCongTrinh());
        }


        //GET
        public async Task<ActionResult> PhanCongNhanSu(int? id)
        {
            ViewBag.IdCT = id;
            ViewBag.ListPB = phongbanRP.GetPhongBan();
            return View();
        }

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> PhanCongNhanSu(int IdCT, string listPhanCong)
        //{
           
        //    return View();
        //}

        //POST
       [HttpPost]
        public async Task<ActionResult> PhanCong(int IdCT, string listPhanCong)
        {
            ViewBag.IdCT = IdCT;
            if (IdCT == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                string[] array = listPhanCong.Split('¶');
                for (int i = 0; i < array.Count(); i++)
                {
                    if(chamcongRP.GetChamCongBy2Id(IdCT, int.Parse(array[i])).Count() == 0)
                    {
                        ChamCong chamcong = new ChamCong();
                        chamcong.IdCT = IdCT;
                        chamcong.IdNV = int.Parse(array[i]);
                        chamcong.NgayBatDau = congtrinhRP.GetCongTrinhByID(IdCT).NgayBatDau;
                        chamcong.NgayCong = 0;
                        chamcong.NgayKetThuc = congtrinhRP.GetCongTrinhByID(IdCT).NgayKetThuc;
                        chamcong.TinhTrang = 0;
                        chamcongRP.CreateChamCong(chamcong);
      
                    }
                }
                return RedirectToAction("DanhSachNhanSu", "ChamCong");

            }
            return View();
        }

        //GET
        public async Task<ActionResult> DanhSachNhanSu(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<ChamCong> chamcong = chamcongRP.GetChamCongByIdCT(id);
            ViewBag.IdCT = id;
            ViewBag.NgayConLai = (congtrinhRP.GetCongTrinhByID(id).NgayKetThuc - DateTime.Now).TotalDays;            
            return View(chamcong);
        }


        //POST Change Tình trạng tham gia của Nhân sự trong công Trình 0 - Đang làm , 1 - Đã xóa
        public async Task<ActionResult> ChangeTinhTrang(string listId)
        {
            if (ModelState.IsValid)
            {
                string[] list = listId.Split('¶');
                for (int i = 0; i < list.Count(); i++)
                {
                    try
                    {
                        chamcongRP.ChangeTinhTrang(int.Parse(list[i].ToString()),1,DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
                return RedirectToAction("DanhSachNhanSu", "ChamCong");
            }
            return View();

        }
    }
}
