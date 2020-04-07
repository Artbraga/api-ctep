using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("USUARIO");

            builder.Property(r => r.Id)
                .HasColumnName("ID");

            builder
                .Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50);

            builder
                .Property(u => u.Login)
                .HasColumnName("LOGIN")
                .HasMaxLength(10);

            builder
                .Property(u => u.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(32);

            builder
                .Property(u => u.Telefone)
                .HasColumnName("LOGIN")
                .HasMaxLength(10);

            builder.Property(u => u.Permissao)
                .HasColumnName("PERMISSAO");

        }
    }
}