using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("TURMA");

            builder.Property(r => r.Id)
                .HasColumnName("ID");

            builder
                .Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.Codigo)
                .HasColumnName("CODIGO")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(u => u.DiasDaSemana)
                .HasColumnName("DIAS_DA_SEMANA")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(u => u.HoraInicio)
                .HasColumnName("HORA_INICIO")
                .HasMaxLength(5)
                .IsRequired();

            builder
                .Property(u => u.HoraFim)
                .HasColumnName("HORA_FIM")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(e => e.DataInicio)
                .HasColumnName("DATA_INICIO")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.DataFim)
                .HasColumnName("DATA_FIM")
                .HasColumnType("datetime");

            builder.Property(r => r.AnoInicio)
                .HasColumnName("ANO_INICIO");

            builder.Property(r => r.CursoId)
                .HasColumnName("CURSO_ID");

            builder.HasOne(t => t.Curso)
                .WithMany(c => c.Turmas)
                .HasForeignKey(t => t.CursoId)
                .HasConstraintName("FK_TURMA_CURSO_ID");
        }
    }
}