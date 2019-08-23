using 
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class SistemaContext : DbContext
    {
        public SistemaContext() : base("")
        {

        }

        public DbSet<Avaliacao> Avaliacaos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Comodidade> Comodidades { get; set; }

        public DbSet<Hotel> Hoteis { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<ClienteLogin> ClienteLogins { get; set; }
                
    }
    
}
