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
using QLXayDungWebMVC.Dapper;
using System.IO;
using System.Web.Script.Serialization;

namespace QLXayDungWebMVC.Controllers
{
    public class NhanVienController : Controller
    {
        NhanVienRepo nhanvienRP = new QLXayDungWebMVC.Dapper.NhanVienRepo();
        PhongBanRepo phongbanRP = new QLXayDungWebMVC.Dapper.PhongBanRepo();

        // GET: /NhanVien/
        public async Task<ActionResult> Index(int? id)
        {
           ViewBag.IdPB = new SelectList(phongbanRP.GetPhongBan(), "IdPB", "TenPB");
            if (id != null)
                return View(nhanvienRP.GetNhanVienByIdPB(id));
            else
                return View(nhanvienRP.GetNhanVien());
        }

        // GET: /NhanVien/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NhanVien nhanvien = nhanvienRP.GetNhanVienByID(id);
            ViewBag.PhongBan = phongbanRP.GetPhongBanByID(nhanvien.IdPB).TenPB;
            return PartialView("Details", nhanvien);
            //return View(nhanvien);
        }

        // GET: /NhanVien/Create
        public ActionResult Create()
        {
            NhanVien nhanvien = new NhanVien();
            ViewBag.IdPB = new SelectList(phongbanRP.GetPhongBan(), "IdPB", "TenPB");
            //return PartialView("Create", nhanvien);
            return View();
        }

        // POST: /NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NhanVien nhanvien, HttpPostedFileBase fileImage)
        {
            if (fileImage != null)
            {
                string ext = Path.GetExtension(fileImage.FileName);
                string fileName = nhanvien.CMT + ext;
                string path = Path.Combine(Server.MapPath("~/Content/NhanVien"), fileName);
                nhanvien.AnhNV = fileName;
                if (ModelState.IsValid)
                {
                    //kiểm tra ảnh đã tồn tại hay chưa
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại !";
                    }
                    else
                    {
                        fileImage.SaveAs(path);
                    }

                    nhanvienRP.CreateNhanVien(nhanvien);
                    //return Json(new { success = true });
                    return RedirectToAction("Index");
                }

            }
            else
                ViewBag.ThongBao = "Vui lòng thêm ảnh nhân viên!";


            ViewBag.IdPB = new SelectList(phongbanRP.GetPhongBan(), "IdPB", "TenPB", nhanvien.IdPB);
            //return Json(nhanvien, JsonRequestBehavior.AllowGet);
            return View(nhanvien);

        }

        // GET: /NhanVien/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NhanVien nhanvien = nhanvienRP.GetNhanVienByID(id);
            ViewBag.IdPB = new SelectList(phongbanRP.GetPhongBan(), "IdPB", "TenPB", nhanvien.IdPB);
            //return PartialView("Edit", nhanvien);
            return View(nhanvien);
        }

        // POST: /NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(NhanVien nhanvien, HttpPostedFileBase fileImage)
        {
            if (fileImage != null)
            {
                string ext = Path.GetExtension(fileImage.FileName);
                string fileName = nhanvien.CMT + ext;
                string path = Path.Combine(Server.MapPath("~/Content/NhanVien"), fileName);
                nhanvien.AnhNV = fileName;
                if (ModelState.IsValid)
                {
                    //kiểm tra ảnh đã tồn tại hay chưa
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại !";
                    }
                    else
                    {
                        fileImage.SaveAs(path);
                    }

                    nhanvienRP.UpdateNhanVien(nhanvien);
                   //return Json(new { success = true });
                    return RedirectToAction("Index");

                }

            }
            else
                ViewBag.ThongBao = "Vui lòng thêm ảnh nhân viên!";


            ViewBag.IdPB = new SelectList(phongbanRP.GetPhongBan(), "IdPB", "TenPB", nhanvien.IdPB);
            //return PartialView("Edit", nhanvien);
            return View(nhanvien);
        }

        // GET: /NhanVien/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NhanVien nhanvien = nhanvienRP.GetNhanVienByID(id);
            ViewBag.PhongBan = phongbanRP.GetPhongBanByID(nhanvien.IdPB).TenPB;
            return PartialView("Delete", nhanvien);
            //return View(nhanvien);
        }

        // POST: /NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bool status = nhanvienRP.DeleteNhanVien(id);
            return Json(new { success = true });
            // return RedirectToAction("Index");
        }


        public PartialViewResult GetNhanVienByIdPB(int id)
        {
            if(id == 0)
            {
                return PartialView(nhanvienRP.GetNhanVien());
            }
            else
                return PartialView(nhanvienRP.GetNhanVienByIdPB(id));
        }



    }
}
