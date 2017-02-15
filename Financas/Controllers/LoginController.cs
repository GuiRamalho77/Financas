using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string Nome, string Senha)
        {
            if (WebSecurity.Login(Nome, Senha))
            {
                return RedirectToAction("Index", "Movimentacao");
            }else
            {
                return View("Index");
            }
        }
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}