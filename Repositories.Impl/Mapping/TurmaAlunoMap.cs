﻿using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    class TurmaAlunoMap : IEntityTypeConfiguration<TurmaAluno>
    {
        public void Configure(EntityTypeBuilder<TurmaAluno> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_turma_aluno");

            builder.Property(r => r.Id)
                .HasColumnName("id_turma_aluno")
                .HasColumnType("int");

            builder
                .Property(u => u.Matricula)
                .HasColumnName("matricula_aluno")
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(u => u.DataConclusao)
                .HasColumnName("data_conclusao")
                .HasColumnType("date");

            builder
                .Property(u => u.CodigoConlusaoSistec)
                .HasColumnName("codigo_conclusaosistec")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder
                .Property(u => u.AlunoId)
                .HasColumnName("id_aluno")
                .HasColumnType("int");

            builder
                .Property(u => u.TurmaId)
                .HasColumnName("id_turma")
                .HasColumnType("int");
           
            builder.Property(r => r.TipoStatusAlunoId)
                .HasColumnName("id_tpstatus_aluno")
                .HasColumnType("int");

            builder.HasOne(t => t.Turma)
                .WithMany(c => c.TurmasAluno)
                .HasForeignKey(t => t.TurmaId);

            builder.HasOne(t => t.Aluno)
                .WithMany(c => c.TurmasAluno)
                .HasForeignKey(t => t.AlunoId);
            
            builder.HasOne(r => r.TipoStatusAluno)
                 .WithMany(t => t.TurmasAluno)
                 .HasForeignKey(r => r.TipoStatusAlunoId);
        }
    }
}
