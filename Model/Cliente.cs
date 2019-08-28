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
        [Column ("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("rg")]
        public string Rg { get; set; }

        [Column("celular")]
        public string Celular { get; set; }

        
    }
}
