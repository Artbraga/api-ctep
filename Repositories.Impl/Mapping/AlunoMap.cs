
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

            builder.ToTable("ALUNO");

            builder.Property(r => r.Id)
                .HasColumnName("ID");

            builder
                .Property(u => u.Matricula)
                .HasColumnName("MATRICULA")
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.CPF)
                .HasColumnName("CPF")
                .HasColumnType("varchar")
                .HasMaxLength(12)
                .IsRequired();

            builder
                .Property(u => u.CPF)
                .HasColumnName("RG")
                .HasColumnType("varchar")
                .HasMaxLength(15);

            builder
                .Property(u => u.Endereco)
                .HasColumnName("ENDERECO")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.CEP)
                .HasColumnName("CEP")
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(u => u.Complemento)
                .HasColumnName("COMPLEMENTO")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder
                .Property(u => u.Bairro)
                .HasColumnName("BAIRRO")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder
                .Property(u => u.Cidade)
                .HasColumnName("CIDADE")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder
                .Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("varchar")
                .HasMaxLength(40);

            builder
                .Property(u => u.Telefone)
                .HasColumnName("TELEFONE")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            builder
                .Property(u => u.Bairro)
                .HasColumnName("CELULAR")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            builder
                .Property(u => u.AnoMatricula)
                .HasColumnName("ANO_MATRICULA")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(u => u.AnoMatricula)
                .HasColumnName("ANO_MATRICULA")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(u => u.CursoAnterior)
                .HasColumnName("CURSO_ANTERIOR")
                .HasColumnType("varchar")
                .HasMaxLength(20);
        }
    }
}
/*
CREATE TABLE ALUNO(
    MATRICULA               VARCHAR(8)      NOT NULL,
    NOME                    VARCHAR(50)     NOT NULL,
    CPF                     VARCHAR(12)     NOT NULL,
    RG                      VARCHAR(15),
    ENDERECO                VARCHAR(100)    NOT NULL,
    CEP                     VARCHAR(8)      NOT NULL,
    COMPLEMENTO             VARCHAR(20),
    BAIRRO                  VARCHAR(20),
    CIDADE                  VARCHAR(20),
    EMAIL                   VARCHAR(40),
    TELEFONE                VARCHAR(10),
    CELULAR                 VARCHAR(10),
    NOME_PAI                VARCHAR(50),
    NOME_MAE                VARCHAR(50),
    ANO_MATRICULA           INT(2)          NOT NULL,
    DATA_MATRICULA          DATE            NOT NULL,
    DATA_NASCIMENTO         DATE,
    DATA_VALIDADE           DATE,
    CURSO_ANTERIOR          VARCHAR(20),
    CURSO_ID                INT(3)          NOT NULL,
    NOTA_FISCAL             BOOLEAN,
    TRANSFERENCIA           BOOLEAN,
    STATUS                  INT(2)          NOT NULL,

  CONSTRAINT PK_ALUNO_MATRICULA PRIMARY KEY(MATRICULA),
  CONSTRAINT FK_ALUNO_TURMA_ID FOREIGN KEY(TURMA_ID) REFERENCES TURMA(CODIGO)
    ON DELETE SET NULL,
  CONSTRAINT FK_ALUNO_TURMA_ESPECIALIZACAO_ID FOREIGN KEY(TURMA_ESPECIALIZACAO_ID) REFERENCES TURMA(CODIGO)
    ON DELETE SET NULL,
  CONSTRAINT FK_ALUNO_CURSO_ID FOREIGN KEY(CURSO_ID) REFERENCES CURSO(ID)
); */