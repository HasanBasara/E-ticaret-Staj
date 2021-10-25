using E_ticaret.Controllers.Base;
using E_ticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class ProductController : AControllerBase
    {
        DB db = new DB();
        // GET: Admin/Product
        [Route("urun/{title}/{id}")]
        public ActionResult Details(string title,int id)
        {
            var prod = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(prod);
        }
    }
}