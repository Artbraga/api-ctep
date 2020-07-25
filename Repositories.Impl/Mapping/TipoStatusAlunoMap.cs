
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class TipoStatusAlunoMap : IEntityTypeConfiguration<TipoStatusAluno>
    {
        public void Configure(EntityTypeBuilder<TipoStatusAluno> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_tpstatus_aluno");

            builder.Property(r => r.Id)
                .HasColumnName("id_tpstatus_aluno");

            builder
                .Property(u => u.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}