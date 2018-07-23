﻿// <auto-generated />
using System;
using Angular.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Angular.Migrations
{
    [DbContext(typeof(ContasContext))]
    partial class ContasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Angular.Models.Transacao", b =>
                {
                    b.Property<int?>("TransacaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tra_transacao_id");

                    b.Property<string>("Descricao")
                        .HasColumnName("tra_descricao")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Sigla")
                        .HasColumnName("tra_sigla")
                        .HasColumnType("VARCHAR(2)");

                    b.HasKey("TransacaoID");

                    b.ToTable("TRA_TRANSACOES");
                });

            modelBuilder.Entity("Angular.Models.TransacaoDetalhamento", b =>
                {
                    b.Property<int?>("TransacaoDetalhamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("trd_transacao_detalhamento_id");

                    b.Property<int?>("Ordem")
                        .HasColumnName("trd_ordem");

                    b.Property<int?>("TransacaoID")
                        .HasColumnName("tra_transacao_id");

                    b.Property<decimal?>("ValorEntrada")
                        .HasColumnName("trd_valor_entrada")
                        .HasColumnType("NUMERIC(11, 2)");

                    b.Property<decimal?>("ValorSaida")
                        .HasColumnName("trd_valor_saida")
                        .HasColumnType("NUMERIC(11, 2)");

                    b.HasKey("TransacaoDetalhamentoID");

                    b.HasIndex("TransacaoID");

                    b.ToTable("TRD_TRANSACOES_DETALHAMENTO");
                });

            modelBuilder.Entity("Angular.Models.TransacaoDetalhamento", b =>
                {
                    b.HasOne("Angular.Models.Transacao", "Transacao")
                        .WithMany("TransacoesDetalhamento")
                        .HasForeignKey("TransacaoID");
                });
#pragma warning restore 612, 618
        }
    }
}
