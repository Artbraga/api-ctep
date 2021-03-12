using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Repositories.Impl.Mapping
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_curso");

            builder.Property(r => r.Id)
                .HasColumnName("id_curso")
                .HasColumnType("int");

            builder
                .Property(u => u.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.Sigla)
                .HasColumnName("sigla")
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder
                .Property(u => u.SiglaTurma)
                .HasColumnName("sigla_turma")
                .HasColumnType("varchar(4)")
                .HasMaxLength(4)
                .IsRequired();

            builder
                .Property(u => u.Especializacao)
                .HasColumnName("flg_especializacao")
                .HasDefaultValue(false)
                .HasConversion(new BoolToZeroOneConverter<Int16>());

            builder.Property(u => u.CursoVinculadoId)
                .HasColumnName("id_curso_vinculado")
                .HasColumnType("int");

            builder.HasOne(r => r.CursoVinculado)
               .WithMany(a => a.CursosEspecializacao)
               .HasForeignKey(a => a.CursoVinculadoId);

        }
    }
}