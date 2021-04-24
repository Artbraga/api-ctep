
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class PerfilPermissaoMap : IEntityTypeConfiguration<PerfilPermissao>
    {
        public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_perfil_permissao");

            builder.Property(r => r.Id)
                .HasColumnName("id_perfil_permissao")
                .HasColumnType("int");

            builder
                .Property(u => u.PerfilId)
                .HasColumnName("id_perfil")
                .HasColumnType("int");

            builder
                .Property(u => u.PermissaoId)
                .HasColumnName("id_permissao")
                .HasColumnType("int");

            builder.HasOne(t => t.Perfil)
                .WithMany(c => c.PerfisPermissao)
                .HasForeignKey(t => t.PerfilId);

            builder.HasOne(t => t.Permissao)
                .WithMany(c => c.PerfisPermissao)
                .HasForeignKey(t => t.PermissaoId);
        }
    }
}