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
    class ColetaConfiguracao :
     IEntityTypeConfiguration<Coleta>
    {
        public void Configure(EntityTypeBuilder<Coleta> builder)
        {
            builder.ToTable("Coleta", "CollectWasteToxic");

            builder.HasKey("IdColeta");
            builder.Property(f => f.Localizacao)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(f => f.Endereco)
                .IsRequired();
            builder.Property(f => f.Referencia)
                .IsRequired();
            builder.Property(f => f.Imagem)
                .IsRequired();
            ;
        }
    }
}