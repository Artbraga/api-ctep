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

            builder.ToTable("tb_usuario");

            builder.Property(r => r.Id)
                .HasColumnName("id_usuario");

            builder
                .Property(u => u.Nome)
                .HasColumnName("nome")
                .HasMaxLength(50);

            builder
                .Property(u => u.Login)
                .HasColumnName("login")
                .HasMaxLength(20);

            builder
                .Property(u => u.Senha)
                .HasColumnName("senha")
                .HasMaxLength(32);

            builder
                .Property(u => u.Telefone)
                .HasColumnName("telefone")
                .HasMaxLength(10);

            builder.Property(r => r.AlunoId)
                .HasColumnName("id_aluno");

            builder.Property(r => r.ProfessorId)
                .HasColumnName("id_professor");

        }
    }
}