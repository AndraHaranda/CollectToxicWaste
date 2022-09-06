using CollectToxicWaste.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollectToxicWaste.Infraestrutura.Configurações
{
    public class TransporteConfiguracao :
         IEntityTypeConfiguration<Transporte>
    {
        public void Configure(EntityTypeBuilder<Transporte> builder)
        {
            builder.ToTable("Transporte", "CollectWasteToxic");

            builder.HasKey("Id");
            builder.Property(f => f.Motorista)
                .IsRequired(true)
                .HasMaxLength(150);
            builder.Property(f => f.Placa)
                .IsRequired(true);
            builder.Property(f => f.Empresa)
                .IsRequired(true);
            builder.Property(f => f.CNPJ)
                .IsRequired(true);

        }
    }
}