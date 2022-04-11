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
    class TransporteConfiguracao :
         IEntityTypeConfiguration<Transporte>
    {
        public void Configure(EntityTypeBuilder<Transporte> builder)
        {
            builder.ToTable("Transporte", "CollectWasteToxic");

            builder.HasKey("Id");
            builder.Property(f => f.Motorista)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(f => f.Placa)
                .IsRequired();
            builder.Property(f => f.Empresa);

        }
    }
}