using CollectToxicWaste.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollectToxicWaste.Infraestrutura.Configurações
{
    class MotoristaConfiguracao :
          IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {
            builder.ToTable("Motorista", "CollectWasteToxic");

            builder.HasKey("Id");
            builder.Property(f => f.NomeMotorista)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(f => f.Email)
                .IsRequired();
            builder.Property(f => f.Idade)
                .IsRequired();
            builder.Property(f => f.CPF)
                .IsRequired();
            builder.Property(f => f.Telefone)
                .IsRequired();
            builder.Property(f => f.DataNascimento)
                .IsRequired();
            //builder.Property(f => f.TipoCNH)
        }
    }
}
