using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CollectToxicWaste.Dominio.Entidades;

namespace CollectToxicWaste.Dados.Configurações
{
    /// <summary>
    ///   Configuração da tabela e schema 
    /// </summary>
    class UsuarioConfiguracao :
     IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "CollectWasteToxic");

            builder.HasKey("IdUsuario");
            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(f => f.CPF)
                .IsRequired();
            builder.Property(f => f.CNPJ)
                .IsRequired();
            builder.Property(f => f.RG)
                .IsRequired();
            builder.Property(f => f.Email)
                .IsRequired();
            builder.Property(f => f.DataNascimento)
                .IsRequired();
            ;
        }
    }
}