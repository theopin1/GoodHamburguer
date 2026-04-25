using GoodHamburger.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Sanduiche> Sanduiches { get; set; }
        public DbSet<Acompanhamento> Acompanhamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Acompanhamentos)
                .WithMany();
        }

        protected DataContext() { }
    }
}
