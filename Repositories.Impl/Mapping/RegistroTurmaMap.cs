
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class RegistroTurmaMap : IEntityTypeConfiguration<RegistroTurma>
    {
        public void Configure(EntityTypeBuilder<RegistroTurma> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_registro_turma");

            builder.Property(r => r.Id)
                .HasColumnName("id_registro_turma")
                .HasColumnType("int");

            builder
                .Property(u => u.Data)
                .HasColumnName("data")
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(u => u.Registro)
                .HasColumnName("registro")
                .HasColumnType("varchar(5000)")
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(r => r.TurmaId)
                .HasColumnName("id_turma")
                .HasColumnType("int");

            builder.HasOne(r => r.Turma)
                 .WithMany(t => t.Registros)
                 .HasForeignKey(r => r.TurmaId);
        }
    }
}