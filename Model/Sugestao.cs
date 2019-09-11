﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("sugestoes")]
    public class Sugestao : Base
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("local")]
        public string Local { get; set; }

        [Column("ponto_turistico")]
        public string Ponto_Turistico { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }

    }
}
