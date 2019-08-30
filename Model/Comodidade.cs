using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table ("comodidades")]
    public class Comodidade : Base
    {
        [Column("nome")]
        public string Nome { get; set; }

        [ForeignKey("IdHotel")]
        public Hotel Hotel { get; set; }
        
        [Column("id_hotel")]
        public int IdHotel { get; set; }
    }
}
