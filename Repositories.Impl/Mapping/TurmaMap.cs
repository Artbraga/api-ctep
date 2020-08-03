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

            builder.ToTable("tb_turma");

            builder.Property(r => r.Id)
                .HasColumnName("id_turma");

            builder
                .Property(u => u.Codigo)
                .HasColumnName("codigo")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(u => u.DiasDaSemana)
                .HasColumnName("dias_semana")
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(u => u.HoraInicio)
                .HasColumnName("hora_inicio");

            builder
                .Property(u => u.HoraFim)
                .HasColumnName("hora_fim");

            builder.Property(e => e.DataInicio)
                .HasColumnName("data_inicio")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.DataFim)
                .HasColumnName("data_fim")
                .HasColumnType("datetime");

            builder.Property(r => r.CursoId)
                .HasColumnName("id_curso");

            builder.Property(r => r.TipoStatusTurmaId)
                .HasColumnName("id_tpstatus_turma");

            builder.HasOne(t => t.Curso)
                .WithMany(c => c.Turmas)
                .HasForeignKey(t => t.CursoId);


            builder.HasOne(t => t.TipoStatusTurma)
                .WithMany(c => c.Turmas)
                .HasForeignKey(t => t.TipoStatusTurmaId);
        }
    }
}