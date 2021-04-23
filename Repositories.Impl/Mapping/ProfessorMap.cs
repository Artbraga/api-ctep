using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Repositories.Impl.Mapping
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_professor");

            builder.Property(r => r.Id)
                .HasColumnName("id_professor")
                .HasColumnType("int");

            builder
               .Property(u => u.Nome)
               .HasColumnName("nome")
               .HasColumnType("varchar(50)")
               .HasMaxLength(50)
               .IsRequired();

            builder
                .Property(u => u.CPF)
                .HasColumnName("cpf")
                .HasColumnType("varchar(14)")
                .HasMaxLength(14)
                .IsRequired();

            builder
                .Property(u => u.RG)
                .HasColumnName("rg")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder
                .Property(u => u.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.CEP)
                .HasColumnName("cep")
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(u => u.Complemento)
                .HasColumnName("complemento")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder
                .Property(u => u.Bairro)
                .HasColumnName("bairro")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder
                .Property(u => u.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder
                .Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(40)")
                .HasMaxLength(40);

            builder
                .Property(u => u.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("varchar(12)")
                .HasMaxLength(12);

            builder
                .Property(u => u.Celular)
                .HasColumnName("celular")
                .HasColumnType("varchar(12)")
                .HasMaxLength(12);

            builder
               .Property(u => u.Formacao)
               .HasColumnName("formacao")
               .HasColumnType("varchar(30)")
               .HasMaxLength(30);

            builder
                .Property(u => u.FlagExclusao)
                .HasColumnName("flg_exclusao")
                .HasDefaultValue(false)
                .HasConversion(new BoolToZeroOneConverter<Int16>());

        }
    }
}