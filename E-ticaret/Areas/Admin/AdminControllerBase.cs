using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_ticaret.Areas.Admin
{
    public class AdminControllerBase : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            var isLogin = false;
            if (requestContext.HttpContext.Session["AdminLoginUser"] ==  null)
            {
                requestContext.HttpContext.Response.Redirect("/Admin/AdminLogin");
            }
            else
            {
                base.Initialize(requestContext);
            }
        }
    }
}