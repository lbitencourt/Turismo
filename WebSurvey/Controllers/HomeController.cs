using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebSurvey.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                Session.Clear();
                FormsAuthentication.SignOut();
            }
            return View();
        }

    }
}
