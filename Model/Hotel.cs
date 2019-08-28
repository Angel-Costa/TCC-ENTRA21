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

        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("valor_hospedaegm")]
        public decimal ValorHospedagem { get; set; }
                                 
        [Column("quantidade_quartos")]
        public int QuantidadeQuartos { get; set; }
    }
}
