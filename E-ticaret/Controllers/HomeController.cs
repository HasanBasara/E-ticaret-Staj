using E_ticaret.Controllers.Base;
using E_ticaret.Core.Model;
using E_ticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace E_ticaret.Controllers
{
    public class HomeController :  AControllerBase

    {
        DB db = new DB();
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.OrderByDescending(x => x.CreateDate).Take(5).ToList();
            return View(data);
        }

        public PartialViewResult GetMenu()
        {
            var menus = db.Categories.Where(x => x.ParentID == 0).ToList();
            return PartialView(menus);
        }
        [Route("uye-giris")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("uye-giris")]
        public ActionResult Login(string Email, string PassWord)
        {
            var users = db.Users.Where(x => x.Email == Email && x.PassWord == PassWord && x.IsActive == true && x.IsAdmin == false).ToList();
            if (users.Count == 1)
            {
                Session["LoginUserID"] = users.FirstOrDefault().ID;
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "Hatalı E-posta Adresi veya Şifre";
                return View();
            }
        }
        [Route("uye-kayit")]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [Route("uye-kayit")]
        public ActionResult CreateUser(User entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserID = 1;
                entity.IsActive = true;
                entity.IsAdmin = false;

                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");

            }
            catch (Exception ex)
            {

                return View();
            }
        }
    }
}