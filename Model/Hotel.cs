using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("hoteis")]
    public class Hotel : Base
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("valor_noite")]
        public decimal ValorNoite { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("cep")]
        public string CEP { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("rua")]
        public string Rua { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }
       
    }
}
