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

        [Column("data_entrada")]
        public DateTime DataEntrada { get; set; } 

        [Column("data_saida")]
        public DateTime DataSaida { get; set; }

        [Column("quantidade_quartos")]
        public int QuantidadeQuartos { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }

        [ForeignKey("id_avaliacoes")]
        public Avaliacao Avaliacao { get; set; }

        [Column("IdAvaliacoes")]
        public int IdAvaliacao { get; set; }
    }
}
