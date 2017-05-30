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
using PagedList;

namespace QLXayDungWebMVC.Controllers
{
    public class PhongBanController : Controller
    {
        private PhongBanRepo phongbanRP = new PhongBanRepo();

        // GET: /PhongBan/
        public async Task<ActionResult> Index()
        {
            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //var phongban = phongbanRP.GetPhongBan();
            //return View(phongban.ToPagedList(pageNumber, pageSize));
            return View(phongbanRP.GetPhongBan());
        }

        // GET: /PhongBan/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PhongBan phongban = phongbanRP.GetPhongBanByID(id);
            return PartialView("Details",phongban);            
            //return View(phongban);
        }

        // GET: /PhongBan/Create
        public ActionResult Create()
        {
            PhongBan phongban = new PhongBan();
            //return PartialView("Create", phongban);
            return View();
        }

        // POST: /PhongBan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PhongBan phongban)
        {
            if (ModelState.IsValid)
            {
                phongbanRP.CreatePhongBan(phongban);
                //return Json(new { success = true });
                return RedirectToAction("Index");
            }
            //return Json(phongban, JsonRequestBehavior.AllowGet);
            return View(phongban);
        }

        // GET: /PhongBan/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PhongBan phongban = phongbanRP.GetPhongBanByID(id);
            return View(phongban);
            //return PartialView("Edit", phongban);
        }

        // POST: /PhongBan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PhongBan phongban)
        {
            if (ModelState.IsValid)
            {
                phongbanRP.UpdatePhongBan(phongban);
                //return Json(new { success = true });
                return RedirectToAction("Index");
            }
            //return PartialView("Edit", phongban);
            return View(phongban);

        }

        // GET: /PhongBan/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PhongBan phongban = phongbanRP.GetPhongBanByID(id);
            return PartialView("Delete", phongban);
            //return View(phongban);
        }

        // POST: /PhongBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bool status = phongbanRP.DeletePhongBan(id);
            return Json(new { success = true });
            //return RedirectToAction("Index");
        }


    }
}
