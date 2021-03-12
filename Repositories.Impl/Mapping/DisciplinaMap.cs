using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_disciplina");

            builder.Property(r => r.Id)
                .HasColumnName("id_disciplina")
                .HasColumnType("int");

            builder
                .Property(u => u.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.CursoId)
                .HasColumnName("id_curso")
                .HasColumnType("int");

            builder.HasOne(r => r.Curso)
                 .WithMany(t => t.Disciplinas)
                 .HasForeignKey(r => r.CursoId);
        }
    }
}