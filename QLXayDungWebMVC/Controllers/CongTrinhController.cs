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

namespace QLXayDungWebMVC.Controllers
{
    public class CongTrinhController : Controller
    {
        CongTrinhRepo congtrinhRP = new CongTrinhRepo();

        // GET: /CongTrinh/
        public async Task<ActionResult> Index()
        {
            return View(congtrinhRP.GetCongTrinh());
        }

        // GET: /CongTrinh/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CongTrinh congtrinh = congtrinhRP.GetCongTrinhByID(id);
            return PartialView("Details", congtrinh);
            // return View(congtrinh);
        }

        // GET: /CongTrinh/Create
        public ActionResult Create()
        {
            CongTrinh congtrinh = new CongTrinh();
            //return PartialView("Create", congtrinh);
            return View();
        }

        // POST: /CongTrinh/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CongTrinh congtrinh, HttpPostedFileBase fileImage)
        {
            if (fileImage != null)
            {
                string ext = Path.GetExtension(fileImage.FileName);
                string fileName = congtrinh.TenCT + ext;
                string path = Path.Combine(Server.MapPath("~/Content/CongTrinh"), fileName);
                congtrinh.Image = fileName;
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

                    congtrinhRP.CreateCongTrinh(congtrinh);
                    return RedirectToAction("Index");

                    //congtrinhRP.CreateCongTrinh(congtrinh);
                    //return Json(new { success = true });
                }

            }
            else
                ViewBag.ThongBao = "Vui lòng thêm ảnh công trình!";

            //return Json(congtrinh, JsonRequestBehavior.AllowGet);
            return View(congtrinh);
        }

        // GET: /CongTrinh/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CongTrinh congtrinh = congtrinhRP.GetCongTrinhByID(id);
            return View(congtrinh);

            //CongTrinh congtrinh = congtrinhRP.GetCongTrinhByID(id);
            //return PartialView("Edit", congtrinh);
        }

        // POST: /CongTrinh/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CongTrinh congtrinh, HttpPostedFileBase fileImage)
        {
            if (fileImage != null)
            {
                string ext = Path.GetExtension(fileImage.FileName);
                string fileName = congtrinh.TenCT + ext;
                string path = Path.Combine(Server.MapPath("~/Content/CongTrinh"), fileName);
                congtrinh.Image = fileName;
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

                    congtrinhRP.UpdateCongTrinh(congtrinh);
                    //return Json(new { success = true });
                    return RedirectToAction("Index");
                }

            }
            else
                ViewBag.ThongBao = "Vui lòng thêm ảnh công trình!";

            //return PartialView("Edit", congtrinh);
            return View(congtrinh);

        }

        // GET: /CongTrinh/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CongTrinh congtrinh = congtrinhRP.GetCongTrinhByID(id);
            return PartialView("Delete", congtrinh);
            //return View(congtrinh);
        }

        // POST: /CongTrinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bool status = congtrinhRP.DeleteCongTrinh(id);
            return Json(new { success = true });
            //return RedirectToAction("Index");
        }

        public PartialViewResult GetCongTrinhByTinhTrang(int id)
        {
            if (id == 0)
            {
                return PartialView(congtrinhRP.GetCongTrinh());
            }
            else if(id == 1)
                return PartialView(congtrinhRP.GetCongTrinhDangThiCong(DateTime.Now.ToString("yyyy-MM-dd")));
            else if (id == 2)
                return PartialView(congtrinhRP.GetCongTrinhChuaThiCong(DateTime.Now.ToString("yyyy-MM-dd")));
            else
               return PartialView(congtrinhRP.GetCongTrinhDaKetThuc(DateTime.Now.ToString("yyyy-MM-dd")));
        }

    }
}
