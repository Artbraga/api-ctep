using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("CURSO");

            builder.Property(r => r.Id)
                .HasColumnName("ID");

            builder
                .Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.Sigla)
                .HasColumnName("SIGLA")
                .HasMaxLength(3)
                .IsRequired();

            builder
                .Property(u => u.SiglaTurma)
                .HasColumnName("SIGLA_TURMA")
                .HasMaxLength(4)
                .IsRequired();

            builder
                .Property(u => u.Especializacao)
                .HasColumnName("ESPECIALIZACAO")
                .HasDefaultValue(false);

            builder.Property(u => u.CursoVinculadoId)
                .HasColumnName("CURSO_VINCULADO");

            builder.HasOne(r => r.CursoVinculado)
               .WithMany(a => a.CursosEspecializacao)
               .HasForeignKey(a => a.CursoVinculadoId)
               .HasConstraintName("FK_CURSO_VINCULADO");

        }
    }
}