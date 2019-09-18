using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("clientes")]
    public class Cliente : Base
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("celular")]
        public string Celular { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("rua")]
        public string Rua { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }

        [Column("logim")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

    }
}
