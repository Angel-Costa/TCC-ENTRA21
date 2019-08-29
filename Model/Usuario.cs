﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("usuarios")]
    public class Usuario : Base
    {
        [Column ("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("senha")]
        public int Senha { get; set; }

    }
}
