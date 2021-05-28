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
                .HasColumnName("id_usuario")
                .HasColumnType("int");

            builder
                .Property(u => u.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder
                .Property(u => u.Login)
                .HasColumnName("login")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder
                .Property(u => u.Senha)
                .HasColumnName("senha")
                .HasColumnType("varchar(32)")
                .HasMaxLength(32);

            builder
                .Property(u => u.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder
                .Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(r => r.AlunoId)
                .HasColumnName("id_aluno")
                .HasColumnType("int");

            builder.Property(r => r.ProfessorId)
                .HasColumnName("id_professor")
                .HasColumnType("int");

            builder.Property(r => r.PerfilId)
                .HasColumnName("id_perfil")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(r => r.Perfil)
                 .WithMany(t => t.Usuarios)
                 .HasForeignKey(r => r.PerfilId);

            builder.HasOne(r => r.Aluno)
                 .WithOne(t => t.Usuario)
                 .HasForeignKey<Usuario>(r => r.AlunoId);

            builder.HasOne(r => r.Professor)
                 .WithOne(t => t.Usuario)
                 .HasForeignKey<Usuario>(r => r.ProfessorId);
        }
    }
}