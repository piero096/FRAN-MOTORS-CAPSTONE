using FranMotors.DB.Mapping;
using FranMotors.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.DB
{
    public class FranMotorsContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Motocicleta> Motocicletas { get; set; }
        public DbSet<Historial> Historials { get; set; }
        public FranMotorsContext(DbContextOptions<FranMotorsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new MotoMap());
            modelBuilder.ApplyConfiguration(new HistorialMap());
        }

    }
}
