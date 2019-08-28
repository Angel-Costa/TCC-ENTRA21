using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("avaliacoes")]
    public class Avaliacao : Base
    {
        [ForeignKey ("IdCliente")]
        public Cliente Cliente { get; set; }

        [Column ("id_cliente")]
        public int IdCliente { get; set; }

        [ForeignKey("IdHotel")]
        public Hotel Hotel { get; set; }

        [Column("id_hotel")]
        public int IdHotel { get; set; }

        [Column ("nota")]
        public decimal Nota { get; set; }

        [Column("comentario")]
        public string Comentario { get; set; }

        [Column ("feedback")]
        public string FeedBack { get; set; }
    }
}
