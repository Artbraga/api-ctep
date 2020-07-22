
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class RegistroAlunoMap : IEntityTypeConfiguration<RegistroAluno>
    {
        public void Configure(EntityTypeBuilder<RegistroAluno> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_registro_aluno");

            builder.Property(r => r.Id)
                .HasColumnName("id_registro_aluno");

            builder
                .Property(u => u.Data)
                .HasColumnName("data")
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(u => u.Registro)
                .HasColumnName("registro")
                .HasColumnType("varchar")
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(r => r.AlunoId)
                .HasColumnName("id_aluno");

            builder.HasOne(r => r.Aluno)
                 .WithMany(t => t.Registros)
                 .HasForeignKey(r => r.AlunoId);
        }
    }
}