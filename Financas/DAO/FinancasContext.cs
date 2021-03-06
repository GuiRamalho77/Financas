﻿using Financas.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class FinancasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Movimentacao> Movimentacoes { get; set; }

        //sobrecrever o metodo por causa da chaave extrangeira
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //toda movimentacao tem 1 usuario
            modelBuilder.Entity<Movimentacao>().HasRequired(m => m.Usuario);
        }



    }
}