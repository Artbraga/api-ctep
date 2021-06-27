
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class TipoStatusBoletoMap : IEntityTypeConfiguration<TipoStatusBoleto>
    {
        public void Configure(EntityTypeBuilder<TipoStatusBoleto> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_tpstatus_boleto");

            builder.Property(r => r.Id)
                .HasColumnName("id_tpstatus_boleto")
                .HasColumnType("int");

            builder
                .Property(u => u.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}