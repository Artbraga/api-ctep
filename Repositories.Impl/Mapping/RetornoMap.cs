using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class RetornoMap : IEntityTypeConfiguration<Retorno>
    {
        public void Configure(EntityTypeBuilder<Retorno> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_retorno");

            builder.Property(r => r.Id)
                .HasColumnName("id_retorno")
                .HasColumnType("int");

            builder
               .Property(u => u.Numero)
               .HasColumnName("numero")
               .HasColumnType("varchar(6)")
               .HasMaxLength(6)
               .IsRequired();

            builder
               .Property(u => u.Tipo)
               .HasColumnName("tipo")
               .HasColumnType("varchar(10)")
               .HasMaxLength(10)
               .IsRequired();

            builder
              .Property(u => u.DataReferencia)
              .HasColumnName("data_referencia")
              .HasColumnType("date")
              .IsRequired();

            builder
             .Property(u => u.DataLeitura)
             .HasColumnName("data_leitura")
             .HasColumnType("date")
             .IsRequired();
        }
    }
}