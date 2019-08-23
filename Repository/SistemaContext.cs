using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Repository
{
    public class SistemaContext : DbContext
    {
        public SistemaContext(DbContextOptions<SistemaContext> options) : base(options)
        {

        }

        public DbSet<Avaliacao> Avaliacaos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comodidade> Comodidades { get; set; }
        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<Login> Logins { get; set; }

        internal int SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal void Update(object clienteLogin)
        {
            throw new NotImplementedException();
        }

        public DbSet<ClienteLogin> ClientesLogins { get; set; }

    }
}
