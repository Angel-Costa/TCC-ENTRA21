using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("clientes_logins")]
    public class ClienteLogin : Base
    {
        [ForeignKey("IdLogin")]
        public Login Login { get; set; }

        [Column("id_login")]
        public int IdLogin { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }
    }
}
