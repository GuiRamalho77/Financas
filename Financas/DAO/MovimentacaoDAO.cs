using Financas.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class MovimentacaoDAO
    {
        private FinancasContext contexto;

        public MovimentacaoDAO(FinancasContext contexto)
        {
            this.contexto = contexto;
        }

        public void Adiciona (Movimentacao movimentacao)
        {
            contexto.Movimentacoes.Add(movimentacao);
            contexto.SaveChanges();
        }

        public IList<Movimentacao> Lista()
        {
            return contexto.Movimentacoes.ToList();
        }

        public IList<Movimentacao> BuscaPorId(int? usuarioId)
        {
            return contexto.Movimentacoes.Where(m => m.UsuarioId == usuarioId).ToList();
        }

        public IList<Movimentacao> Busca(decimal? valorMaximo, decimal? valorMinimo, DateTime? dataMaxima,
            DateTime? dataMinima, Tipo? tipo, int? usuarioId)
        {
            //guardando oque vem do contexto em uma variavel do tipo IQueryable
            IQueryable<Movimentacao> resultado = contexto.Movimentacoes;

            if (valorMaximo.HasValue)
            {
                resultado = resultado.Where(m=>m.Valor <= valorMaximo);
            }

            if (valorMinimo.HasValue)
            {
                resultado = resultado.Where(m => m.Valor >= valorMinimo);
            }

            if (dataMaxima.HasValue)
            {
                resultado = resultado.Where(m => m.Data <= dataMaxima);
            }

            if (dataMinima.HasValue)
            {
                resultado = resultado.Where(m => m.Data >= dataMinima);
            }

            if (tipo.HasValue)
            {
                resultado = resultado.Where(m => m.Tipo == tipo);
            }

            if (usuarioId.HasValue)
            {
                resultado = resultado.Where(m => m.UsuarioId == usuarioId);
            }
            return resultado.ToList();
        }

        public Movimentacao BuscaTeste(int id)
        {
            return contexto.Movimentacoes.Where(m => m.UsuarioId == id).FirstOrDefault();
        }
    }
}