using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    class TurmaProfessorMap : IEntityTypeConfiguration<TurmaProfessor>
    {
        public void Configure(EntityTypeBuilder<TurmaProfessor> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_turma_professor");

            builder.Property(r => r.Id)
                .HasColumnName("id_turma_professor");

            builder
                .Property(u => u.ProfessorId)
                .HasColumnName("id_professor");

            builder
                .Property(u => u.TurmaId)
                .HasColumnName("id_turma");

            builder.HasOne(t => t.Turma)
                .WithMany(c => c.TurmasProfessor)
                .HasForeignKey(t => t.TurmaId);

            builder.HasOne(t => t.Professor)
                .WithMany(c => c.TurmasProfessor)
                .HasForeignKey(t => t.ProfessorId);
        }
    }
}
