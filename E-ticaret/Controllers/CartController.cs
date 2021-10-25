using E_ticaret.Controllers.Base;
using E_ticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class CartController : AControllerBase
    {
        // GET: Cart
        [HttpPost]
        public JsonResult AddProduct(int productID, int quantity)
        {
            var db = new DB();
            db.Carts.Add(new Core.Model.Entity.Cart
            {
                CreateDate = DateTime.Now,
                CreateUserID = LoginUserID,
                ProductID = productID,
                Quantity = quantity,
                UserID = LoginUserID
            });
            var ct = db.SaveChanges();
            return Json(ct, JsonRequestBehavior.AllowGet);
        }
        [Route("Sepetim")]
        public ActionResult Index()
        {
            var db = new DB();
            var data = db.Carts.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var db = new DB();
            var deleteItem = db.Carts.Where(x => x.ID == id).FirstOrDefault();
            db.Carts.Remove(deleteItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}