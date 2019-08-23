using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table ("comodidades")]
    public class Comodidade : Base
    {
        [ForeignKey ("IdHotel")]
        public Hotel Hotel { get; set; }

        [Column ("id_hotel")]
        public int IdHotel { get; set; }

        [Column("wifi")]
        public bool Wifi { get; set; }

        [Column("ar_condicionado")]
        public bool ArCondicionado { get; set; }

        [Column("tv")]
        public bool Tv { get; set; }

        [Column ("basico")]
        public bool Basico { get; set; }

        [Column ("microondas")]
        public bool Microondas { get; set; }

        [Column("refrigerador")]
        public bool Regrigerador { get; set; }

        [Column("forno")]
        public bool Forno { get; set; }

        [Column("lareira_interna")]
        public bool LareiraInterna { get; set; }
    }
}
