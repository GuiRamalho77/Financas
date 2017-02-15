using Financas.DAO;
using Financas.Entidade;
using Financas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;

        }
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult Adiciona (UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
               try
                {
                    //classe substitui metodo dao.salva, ele cria usuario nas tabelas usuario e usuariosMembership
                    WebSecurity.CreateUserAndAccount(model.Nome, model.Senha, new { Email = model.Email });
                    return RedirectToAction("Index");
                }catch(MembershipCreateUserException e)
                {
                    //menssagem de erro
                    ModelState.AddModelError("usuario.Ivalido", e.Message);
                    return RedirectToAction("Form", model);
                }               
            }
            else
            {
                //mandar para o form se nao for valido com os dados do usuario
                return View("Form", model);
            }
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.Lista();
            return View(usuarios);
        }
    }
}