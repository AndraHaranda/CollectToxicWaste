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
    class UsuarioConfiguracao :
          IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "CollectWasteToxic");

            builder.HasKey("Id");
            builder.Property(f => f.NomeLogin)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(f => f.Avatar)
                .IsRequired();
            builder.Property(f => f.Email)
                .IsRequired();
            builder.Property(f => f.CPF)
                .IsRequired();
            builder.Property(f => f.Telefone)
                .IsRequired();
            builder.Property(f => f.Profissao)
                .IsRequired();
        }
    }
}
