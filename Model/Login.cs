using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("logins")]
    public class Login : Base
    {                               
        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }
    }
}
