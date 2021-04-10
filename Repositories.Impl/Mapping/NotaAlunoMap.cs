using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    class NotaAlunoMap : IEntityTypeConfiguration<NotaAluno>
    {
        public void Configure(EntityTypeBuilder<NotaAluno> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_nota_aluno");

            builder.Property(r => r.Id)
                .HasColumnName("id_nota_aluno")
                .HasColumnType("int");

            builder
                .Property(u => u.ValorNota)
                .HasColumnName("valor_nota")
                .HasColumnType("float")
                .IsRequired();

            builder
                .Property(u => u.AlunoId)
                .HasColumnName("id_aluno")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(u => u.DisciplinaId)
                .HasColumnName("id_disciplina")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(r => r.ProfessorId)
                .HasColumnName("id_professor")
                .HasColumnType("int");

            builder.HasOne(t => t.Aluno)
                .WithMany(c => c.NotasAluno)
                .HasForeignKey(t => t.AlunoId);

            builder.HasOne(t => t.Disciplina)
                .WithMany(c => c.NotasAluno)
                .HasForeignKey(t => t.DisciplinaId);

            builder.HasOne(r => r.Professor)
                 .WithMany(t => t.NotasAluno)
                 .HasForeignKey(r => r.ProfessorId);
        }
    }
}
