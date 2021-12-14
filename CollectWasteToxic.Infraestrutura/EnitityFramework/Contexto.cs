using CollectToxicWaste.Dados.Configurações;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.Configurações;
using Microsoft.EntityFrameworkCore;
using System;

namespace CollectToxicWaste.Dados
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Coleta> Coleta { get; set; }
        public DbSet<Transporte> Transporte { get; set; }
        public DbSet<Rota> Rota { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder OptionsBuidler)
        {
            OptionsBuidler.UseSqlServer("server=201.62.57.93;database=BD037083;user id=RA037083;password=037083;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            modelBuilder.ApplyConfiguration(new ColetaConfiguracao());
            modelBuilder.ApplyConfiguration(new TransporteConfiguracao());
            modelBuilder.ApplyConfiguration(new RotaConfiguracao());

        }
    }
}
