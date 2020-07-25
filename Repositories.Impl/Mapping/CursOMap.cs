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
                .HasColumnName("id_curso");

            builder
                .Property(u => u.Nome)
                .HasColumnName("nome")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.Sigla)
                .HasColumnName("sigla")
                .HasMaxLength(3)
                .IsRequired();

            builder
                .Property(u => u.SiglaTurma)
                .HasColumnName("sigla_turma")
                .HasMaxLength(4)
                .IsRequired();

            builder
                .Property(u => u.Especializacao)
                .HasColumnName("flg_especializacao")
                .HasDefaultValue(false)
                .HasConversion(new BoolToZeroOneConverter<Int16>());

            builder.Property(u => u.CursoVinculadoId)
                .HasColumnName("id_curso_vinculado");

            builder.HasOne(r => r.CursoVinculado)
               .WithMany(a => a.CursosEspecializacao)
               .HasForeignKey(a => a.CursoVinculadoId);

        }
    }
}