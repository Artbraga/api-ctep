using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Impl.Mapping
{
    public class BoletoMap : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("tb_boleto");

            builder.Property(r => r.Id)
                .HasColumnName("id_boleto")
                .HasColumnType("int");

            builder
                .Property(u => u.SeuNumero)
                .HasColumnName("seu_numero")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(u => u.NossoNumero)
                .HasColumnName("nosso_numero")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(u => u.DataVencimento)
                .HasColumnName("data_vencimento")
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(u => u.DataEmissao)
                .HasColumnName("data_emissao")
                .HasColumnType("date");

            builder
                .Property(u => u.DataPagamento)
                .HasColumnName("data_pagamento")
                .HasColumnType("date");

            builder
                .Property(u => u.Valor)
                .HasColumnName("valor")
                .HasColumnType("float")
                .IsRequired();

            builder
                .Property(u => u.ValorPago)
                .HasColumnName("valor_pago")
                .HasColumnType("float");

            builder
                .Property(u => u.ValorJuros)
                .HasColumnName("valor_juros")
                .HasColumnType("float");

            builder
                .Property(u => u.PercentualMulta)
                .HasColumnName("percent_multa")
                .HasColumnType("float");


            builder.Property(r => r.TipoStatusBoletoId)
                .HasColumnName("id_tpstatus_boleto")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(r => r.AlunoId)
                .HasColumnName("id_aluno")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(t => t.TipoStatusBoleto)
                .WithMany(c => c.Boletos)
                .HasForeignKey(t => t.TipoStatusBoletoId);

            builder.HasOne(t => t.Aluno)
                .WithMany(c => c.Boletos)
                .HasForeignKey(t => t.AlunoId);
        }
    }
}
