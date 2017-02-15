using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.Entidade
{
    public class Movimentacao
    {
        public int Id { get; set; }

        public decimal Valor { get; set; 
}
        public DateTime Data { get; set; }

        public Tipo Tipo { get; set; }

        //usuario que realizou a movimentação 
        public int UsuarioId { get; set; }
        //virtual pois vamos usar ela em outras classe
        public virtual Usuario Usuario { get; set; }
    }
}