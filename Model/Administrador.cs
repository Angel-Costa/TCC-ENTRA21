using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("administradores")]
    public class Administrador : Base
    {
        [Column ("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("logim")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

		[Column("privilegio")]
		public string Privilegio { get; set; }
    }
}
