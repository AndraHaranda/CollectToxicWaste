using CollectToxicWaste.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Infraestrutura.Configurações
{
    class RotaConfiguracao :
       IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable("Rota", "CollectWasteToxic");

            builder.HasKey("Id");
            builder.Property(f => f.NomeRota)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(f => f.Cidade)
                .IsRequired();
            builder.Property(f => f.CEP)
                .IsRequired();
            builder.Property(f => f.Trajeto)
                .IsRequired();
            builder.Property(f => f.Turno)
                .IsRequired();
            builder.Property(f => f.Horario)
                .IsRequired();
        }
    }
}
