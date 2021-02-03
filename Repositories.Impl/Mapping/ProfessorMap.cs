using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_professor");

            builder.Property(r => r.Id)
                .HasColumnName("id_professor");

            builder
               .Property(u => u.Nome)
               .HasColumnName("nome")
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

            builder
                .Property(u => u.CPF)
                .HasColumnName("cpf")
                .HasColumnType("varchar")
                .HasMaxLength(12)
                .IsRequired();

            builder
                .Property(u => u.RG)
                .HasColumnName("rg")
                .HasColumnType("varchar")
                .HasMaxLength(15);

            builder
                .Property(u => u.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.CEP)
                .HasColumnName("cep")
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(u => u.Complemento)
                .HasColumnName("complemento")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder
                .Property(u => u.Bairro)
                .HasColumnName("bairro")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder
                .Property(u => u.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder
                .Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder
                .Property(u => u.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("varchar")
                .HasMaxLength(12);

            builder
                .Property(u => u.Celular)
                .HasColumnName("celular")
                .HasColumnType("varchar")
                .HasMaxLength(12);

        }
    }
}