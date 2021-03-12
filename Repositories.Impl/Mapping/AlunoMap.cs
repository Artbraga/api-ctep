
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_aluno");

            builder.Property(r => r.Id)
                .HasColumnName("id_aluno")
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
                .Property(u => u.OrgaoEmissor)
                .HasColumnName("orgao_emissor")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder
               .Property(u => u.Sexo)
               .HasColumnName("sexo")
               .HasColumnType("char(1)")
               .HasMaxLength(1);

            builder
                .Property(u => u.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.CEP)
                .HasColumnName("cep")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(u => u.Complemento)
                .HasColumnName("complemento")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder
                .Property(u => u.Bairro)
                .HasColumnName("bairro")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder
                .Property(u => u.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder
                .Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

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
                .Property(u => u.NomePai)
                .HasColumnName("nome_pai")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder
                .Property(u => u.NomeMae)
                .HasColumnName("nome_mae")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder
               .Property(u => u.DataMatricula)
               .HasColumnName("data_matricula")
               .HasColumnType("date")
               .IsRequired();

            builder
               .Property(u => u.DataNascimento)
               .HasColumnName("data_nascimento")
               .HasColumnType("date")
               .IsRequired();

            builder
               .Property(u => u.DataValidade)
               .HasColumnName("data_validade")
               .HasColumnType("date");

            builder
                .Property(u => u.CursoAnterior)
                .HasColumnName("curso_anterior")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);
        }
    }
}