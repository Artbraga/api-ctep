
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
                .HasColumnName("id_aluno");

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
                .HasMaxLength(11)
                .IsRequired();

            builder
                .Property(u => u.RG)
                .HasColumnName("rg")
                .HasColumnType("varchar")
                .HasMaxLength(20);

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

            builder
                .Property(u => u.NomePai)
                .HasColumnName("nome_pai")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
                .Property(u => u.NomeMae)
                .HasColumnName("nome_mae")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
                .Property(u => u.AnoMatricula)
                .HasColumnName("ANO_MATRICULA")
                .HasColumnType("int");

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
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder.Property(r => r.TipoStatusAlunoId)
                .HasColumnName("id_tpstatus_aluno");

            builder.HasOne(r => r.TipoStatusAluno)
                 .WithMany(t => t.Alunos)
                 .HasForeignKey(r => r.TipoStatusAlunoId);
        }
    }
}