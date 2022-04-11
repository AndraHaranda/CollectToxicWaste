using CollectToxicWaste.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollectToxicWaste.Infraestrutura.Configurações
{
    class ColetaConfiguracao :
       IEntityTypeConfiguration<Coleta>
    {
        public void Configure(EntityTypeBuilder<Coleta> builder)
        {
            builder.ToTable("Coleta", "CollectWasteToxic");

            builder.HasKey("Id");
            builder.Property(f => f.MaterialColetado)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(f => f.IdentificaoColeta)
                .IsRequired();
            builder.Property(f => f.ResponsavelColeta)
                .IsRequired();
            //builder.Property(f => f.HorarioDaColeta)
            //    .IsRequired();
               
        }
    }
}
