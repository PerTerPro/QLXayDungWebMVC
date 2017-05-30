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
using Dapper;

namespace QLXayDungWebMVC.Controllers
{
    public class ChiTietNgayCongsController : Controller
    {
        private QLCTXayDungContext db = new QLCTXayDungContext();
        Dapper.ChiTietNgayCongRepo chitietRP = new Dapper.ChiTietNgayCongRepo();
        Dapper.ChamCongRepo chamcongRP = new Dapper.ChamCongRepo();

        public async Task<ActionResult> Index()
        {
            var chiTietNgayCongs = db.ChiTietNgayCongs.Include(c => c.ChamCong);
            return View(await chiTietNgayCongs.ToListAsync());
        }

        // GET: ChiTietNgayCongs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietNgayCong chiTietNgayCong = await db.ChiTietNgayCongs.FindAsync(id);
            if (chiTietNgayCong == null)
            {
                return HttpNotFound();
            }
            return View(chiTietNgayCong);
        }

        // GET: ChiTietNgayCongs/Create
        public ActionResult Create()
        {
            ViewBag.IdChamCong = new SelectList(db.ChamCongs, "IdChamCong", "IdChamCong");
            return View();
        }

        // POST: ChiTietNgayCongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ChiTietNgayCong chiTietNgayCong)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietNgayCongs.Add(chiTietNgayCong);
                await db.SaveChangesAsync();
                return RedirectToAction("NhanVien");
            }

            ViewBag.IdChamCong = new SelectList(db.ChamCongs, "IdChamCong", "IdChamCong", chiTietNgayCong.IdChamCong);
            return View(chiTietNgayCong);
        }

        // GET: ChiTietNgayCongs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietNgayCong chiTietNgayCong = await db.ChiTietNgayCongs.FindAsync(id);
            if (chiTietNgayCong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdChamCong = new SelectList(db.ChamCongs, "IdChamCong", "IdChamCong", chiTietNgayCong.IdChamCong);
            return View(chiTietNgayCong);
        }

        // POST: ChiTietNgayCongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdChamCong,NgayLam,DiLam,LyDo")] ChiTietNgayCong chiTietNgayCong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietNgayCong).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdChamCong = new SelectList(db.ChamCongs, "IdChamCong", "IdChamCong", chiTietNgayCong.IdChamCong);
            return View(chiTietNgayCong);
        }

        // GET: ChiTietNgayCongs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietNgayCong chiTietNgayCong = await db.ChiTietNgayCongs.FindAsync(id);
            if (chiTietNgayCong == null)
            {
                return HttpNotFound();
            }
            return View(chiTietNgayCong);
        }

        // POST: ChiTietNgayCongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ChiTietNgayCong chiTietNgayCong = await db.ChiTietNgayCongs.FindAsync(id);
            db.ChiTietNgayCongs.Remove(chiTietNgayCong);
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

        public async Task<ActionResult> NhanVien(int id)
        {
            Dapper.CongTrinhRepo congtrinhRP = new Dapper.CongTrinhRepo();
            ////GET IdChamCong
            //var chitiet = chitietRP.GetChiTietNgayCongBy2Id(IdCT, IdNV);
            //if(chitiet.Count() != 0)
            //    ViewBag.IdChamCong = chitiet.First().IdChamCong;

            ViewBag.IdChamCong = id;
            //ViewBag.IdChamCong = new SelectList(chitietRP.GetChiTietNgayCong(), "IdChamCong", "IdChamCong", chamcongRP.GetChamCongBy2Id(IdCT, IdNV).IdChamCong);
            ViewBag.IdCT = chamcongRP.GetChamCongByID(id).IdCT;
            ViewBag.NgayConLai = (congtrinhRP.GetCongTrinhByID(ViewBag.IdCT).NgayKetThuc - DateTime.Now).TotalDays;
            ViewBag.CheckChamCong = chitietRP.GetChiTietNgayCongByID_Date(id, DateTime.Now.ToString("yyyy-MM-dd")).Count();
            ViewBag.IdNV = chamcongRP.GetChamCongByID(id).IdNV;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Chấm công cho nhân viên
        public async Task<ActionResult> NhanVien(ChiTietNgayCong chiTietNgayCong, int id)
        {
            //GET IdChamCong
            chiTietNgayCong.IdChamCong = id;
            chiTietNgayCong.NgayLam = DateTime.Now;

            if (ModelState.IsValid)
            {
                chitietRP.CreateChiTietNgayCong(chiTietNgayCong);
                return RedirectToAction("NhanVien");
            }

            ViewBag.IdChamCong = id;
            return View(chiTietNgayCong);
        }


        //POST
        public async Task<ActionResult> InsertList(string listChamCong)
        {            
            if(ModelState.IsValid)
            {
                string[] list = listChamCong.Split('¶');
                for (int i = 0; i < list.Count(); i++)
                {
                    ChiTietNgayCong chitiet = new ChiTietNgayCong();
                    string[] record = list[i].Split('_');
                    if (chitietRP.GetChiTietNgayCongByID_Date(int.Parse(record[0].ToString()), DateTime.Now.ToString("yyyy-MM-dd")).Count() == 0)
                    {
                        chitiet.IdChamCong = int.Parse(record[0].ToString());
                        chitiet.NgayLam = DateTime.Now;
                        chitiet.DiLam = int.Parse(record[1].ToString());
                        if (chitiet.DiLam == 1)
                            chitiet.LyDo = record[2].ToString();
                        else
                            chitiet.LyDo = "";

                        try
                        {
                            chitietRP.CreateChiTietNgayCong(chitiet);
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }
                    }
                }
                return RedirectToAction("DanhSachNhanSu", "ChamCong");
            }
            return View();

        }

    }
}
