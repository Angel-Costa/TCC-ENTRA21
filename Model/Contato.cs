using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("contatos")]
    public class Contato : Base
    {

        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("celular")]
        public string Celular { get; set; }

        [Column("mensagem")]
        public string Mensagem { get; set; }

    }
}
