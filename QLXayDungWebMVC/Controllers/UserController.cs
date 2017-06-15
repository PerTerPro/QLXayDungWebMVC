using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLXayDungWebMVC.Models;
using System.IO;
using System.Threading.Tasks;
using QLXayDungWebMVC.Dapper;

namespace QLXayDungWebMVC.Controllers
{
    public class UserController : Controller
    {
        UserRepo userRP = new QLXayDungWebMVC.Dapper.UserRepo();

        // GET: /User/
        public ActionResult Index()
        {
            return View(userRP.GetUser());

        }

        // GET: /User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRP.GetUserByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
           // ViewBag.ChucVu = Check(user.Active);
            return PartialView("Details", user);
            //return View(user);

        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user, HttpPostedFileBase fileImage)
        {
            if (fileImage != null)
            {
                string ext = Path.GetExtension(fileImage.FileName);
                string fileName = user.Username + ext;
                string path = Path.Combine(Server.MapPath("~/Content/Users"), fileName);
                user.Image = fileName;
                user.NgayTao = DateTime.Now;
                user.Active = 1;
                if (ModelState.IsValid)
                {
                    //kiểm tra ảnh đã tồn tại hay chưa
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Tài khoản đã tồn tại !";
                    }
                    else
                    {
                        fileImage.SaveAs(path);
                    }
                    userRP.CreateUser(user);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.ThongBao = "Vui lòng thêm ảnh!";
            }
            return View(user);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRP.GetUserByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userRP.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRP.GetUserByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            //return View(user);
            return PartialView("Delete", user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userRP.DeleteUser(id);
            return Json(new { success = true });           
           // return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var usr = userRP.Login(userName, password);
            {
                if (usr != null && usr.Active == 0)
                {
                    Session["ID"] = usr.ID;
                    Session["Username"] = usr.Username;
                    Session["Pass"] = usr.Password;
                    Session["Active"] = usr.Active;
                    Session["Name"] = usr.Name;
                    Session["Image"] = usr.Image;

                    ViewBag.Data = userRP.GetUserByActive(1).Count();
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền truy cập !";
                ModelState.Clear();
                return View();
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user, string RetypePassword)
        {
            if (ModelState.IsValid)
            {
                if(userRP.GetUserByUsername(user.Username).Count() == 0)
                {
                    if (user.Password == RetypePassword)
                    {
                        user.Image = "";
                        user.NgayTao = DateTime.Now;
                        user.Active = 1;
                        try
                        {
                            userRP.CreateUser(user);
                            TempData["Success"] = "Register success account: " + user.Username;
                            return RedirectToAction("Login");
                        }
                        catch (Exception ex)
                        {
                            ViewBag.error = ex.Message;
                        }
                    }
                    else
                    {
                        ViewBag.error = "Mật khẩu chưa trùng khớp!";
                    }
                }
                else
                {
                    ViewBag.error = "Username " + user.Username + " đã tồn tại!";
                }

            }

            ModelState.Clear();
            return View(user);
        }

        public ActionResult Logout()
        {
            Session["ID"] = null;
            Session["Username"] = null;
            Session["Password"] = null;
            Session["Name"] = null;
            Session["Image"] = null;
            Session["Active"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult XetDuyetUsers()
        {
            return View(userRP.GetUserByActive(1));
        }

        public async Task<ActionResult> XetDuyet(string listId)
        {
            if (ModelState.IsValid)
            {
                string[] list = listId.Split('¶');
                for (int i = 0; i < list.Count(); i++)
                {
                    try
                    {
                        userRP.XetDuyetUser(int.Parse(list[i].ToString()));
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
                return RedirectToAction("XetDuyetUsers", "User");
            }
            return RedirectToAction("XetDuyetUsers", "User");
        }

        public string Check(int i)
        {
            string str = "";
            if (i == 0)
                str = "ADMIN";
            else if (i == 1)
                str = "Quản lý Nhân sự";
            else
                str = "Người dùng";
            return str;               
        }
    }
}
