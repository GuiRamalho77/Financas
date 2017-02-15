using Financas.DAO;
using Financas.Entidade;
using Financas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financas.Controllers
{
    //para so usuario logado poder acessar movimentação
    [Authorize]
    public class MovimentacaoController : Controller
    {
        private MovimentacaoDAO movimentacaoDAO;
        private UsuarioDAO usuarioDAO;

        //usuario pois precisamos receber o usuario da movimentacao
        public MovimentacaoController(MovimentacaoDAO movimentacaoDAO, UsuarioDAO usuarioDAO)
        {
            this.movimentacaoDAO = movimentacaoDAO;
            this.usuarioDAO = usuarioDAO;
        }
        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.Lista();
            return View(); 
        }

        public ActionResult Adiciona(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                movimentacaoDAO.Adiciona(movimentacao);
                return RedirectToAction("Index");   
            }
            else
            {
                ViewBag.Usuarios = usuarioDAO.Lista();
                return View("Form", movimentacao);
            }           

        }
        public ActionResult Index()
        {
            IList<Movimentacao> movimentacoes = movimentacaoDAO.Lista();
            return View(movimentacoes);
        }

        public ActionResult MovimentacaoPorUsuario(MovimentacaoPorUsuarioModel model)
        {
            model.Usuarios = usuarioDAO.Lista();
            model.Movimentacoes = movimentacaoDAO.BuscaPorId(model.UsuarioId);
            return View(model);
        }
        
        public ActionResult Busca(BuscaMovimentacoesModel model)
        {
            model.Usuarios = usuarioDAO.Lista();
            model.Movimentacoes = movimentacaoDAO.Busca(model.ValorMaximo, model.ValorMinimo, model.DataMaxima
                                                        , model.DataMinima, model.Tipo, model.UsuarioId);
            return View(model);
        }


    }
}