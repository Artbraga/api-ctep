
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class TipoStatusTurmaMap : IEntityTypeConfiguration<TipoStatusTurma>
    {
        public void Configure(EntityTypeBuilder<TipoStatusTurma> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_tpstatus_turma");

            builder.Property(r => r.Id)
                .HasColumnName("id_tpstatus_turma");

            builder
                .Property(u => u.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}