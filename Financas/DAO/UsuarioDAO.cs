using Financas.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class UsuarioDAO
    {
        private FinancasContext contexto;

        public UsuarioDAO(FinancasContext contexto)
        {
            this.contexto = contexto;
        }
        
        public void Adiciona (Usuario usuario)
        {
            
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
        }

        public IList<Usuario> Lista()
        {
            return contexto.Usuarios.ToList();
        }
    }
}