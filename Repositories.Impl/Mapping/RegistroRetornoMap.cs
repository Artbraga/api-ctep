
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class RegistroRetornoMap : IEntityTypeConfiguration<RegistroRetorno>
    {
        public void Configure(EntityTypeBuilder<RegistroRetorno> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_registro_retorno");

            builder.Property(r => r.Id)
                .HasColumnName("id_registro_retorno")
                .HasColumnType("int");

            builder
                .Property(u => u.Registro)
                .HasColumnName("registro")
                .HasColumnType("varchar(5000)")
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(r => r.RetornoId)
                .HasColumnName("id_retorno")
                .HasColumnType("int");

            builder.HasOne(r => r.Retorno)
                 .WithMany(t => t.Registros)
                 .HasForeignKey(r => r.RetornoId);
        }
    }
}