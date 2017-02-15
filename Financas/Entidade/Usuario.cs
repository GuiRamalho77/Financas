using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financas.Entidade
{
    public class Usuario
    {
        public int Id { get; set; }

        //nome obrigatorio
        [Required]
        public string Nome { get; set; }

        //email obrigado e valido
        [Required,EmailAddress]
        public string Email { get; set; }
    }
}