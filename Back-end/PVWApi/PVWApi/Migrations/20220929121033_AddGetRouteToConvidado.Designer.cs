﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PVWApi.Models;

#nullable disable

namespace PVWApi.Migrations
{
    [DbContext(typeof(CasamentoContext))]
    [Migration("20220929121033_AddGetRouteToConvidado")]
    partial class AddGetRouteToConvidado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PVWApi.Models.Banda", b =>
                {
                    b.Property<int>("BandaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BandaId"), 1L, 1);

                    b.Property<TimeSpan>("HorasContratadas")
                        .HasColumnType("time");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<int>("NumeroIntegrantes")
                        .HasColumnType("int");

                    b.Property<int>("NumeroMusicas")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BandaId");

                    b.ToTable("Banda");
                });

            modelBuilder.Entity("PVWApi.Models.Buffet", b =>
                {
                    b.Property<int>("BuffetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuffetId"), 1L, 1);

                    b.Property<string>("Comidas")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<TimeSpan>("HorasContratadas")
                        .HasColumnType("time");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BuffetId");

                    b.ToTable("Buffet");
                });

            modelBuilder.Entity("PVWApi.Models.Casamento", b =>
                {
                    b.Property<int>("CasamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CasamentoId"), 1L, 1);

                    b.Property<int?>("CerimoniaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("date");

                    b.Property<int?>("DecoracaoId")
                        .HasColumnType("int");

                    b.Property<int?>("FestaId")
                        .HasColumnType("int");

                    b.Property<int?>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("NomeParceiroA")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("NomeParceiroB")
                        .HasColumnType("varchar(70)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CasamentoId");

                    b.HasIndex("CerimoniaId");

                    b.HasIndex("DecoracaoId");

                    b.HasIndex("FestaId");

                    b.HasIndex("LoginId");

                    b.ToTable("Casamento");
                });

            modelBuilder.Entity("PVWApi.Models.Celebrante", b =>
                {
                    b.Property<int>("CelebranteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CelebranteId"), 1L, 1);

                    b.Property<TimeSpan>("HorasContratadas")
                        .HasColumnType("time");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CelebranteId");

                    b.ToTable("Celebrante");
                });

            modelBuilder.Entity("PVWApi.Models.Cerimonia", b =>
                {
                    b.Property<int>("CerimoniaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CerimoniaId"), 1L, 1);

                    b.Property<int?>("CelebranteId")
                        .HasColumnType("int");

                    b.Property<bool>("Civil")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Religiosa")
                        .HasColumnType("bit");

                    b.HasKey("CerimoniaId");

                    b.HasIndex("CelebranteId");

                    b.ToTable("Cerimonia");
                });

            modelBuilder.Entity("PVWApi.Models.Convidado", b =>
                {
                    b.Property<int>("ConvidadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConvidadoId"), 1L, 1);

                    b.Property<int>("CasamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<int>("QuantidadeConvidado")
                        .HasColumnType("int");

                    b.HasKey("ConvidadoId");

                    b.HasIndex("CasamentoId");

                    b.ToTable("Convidado");
                });

            modelBuilder.Entity("PVWApi.Models.Decoracao", b =>
                {
                    b.Property<int>("DecoracaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DecoracaoId"), 1L, 1);

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DecoracaoId");

                    b.ToTable("Decoracao");
                });

            modelBuilder.Entity("PVWApi.Models.Festa", b =>
                {
                    b.Property<int>("FestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FestaId"), 1L, 1);

                    b.Property<int?>("BandaId")
                        .HasColumnType("int");

                    b.Property<int?>("BuffetId")
                        .HasColumnType("int");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HorasContratadas")
                        .HasColumnType("time");

                    b.Property<string>("NomeLocal")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FestaId");

                    b.HasIndex("BandaId");

                    b.HasIndex("BuffetId");

                    b.ToTable("Festa");
                });

            modelBuilder.Entity("PVWApi.Models.Usuario", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"), 1L, 1);

                    b.Property<int>("CasamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("TemCasamento")
                        .HasColumnType("int");

                    b.HasKey("LoginId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("PVWApi.Models.Casamento", b =>
                {
                    b.HasOne("PVWApi.Models.Cerimonia", "Cerimonia")
                        .WithMany("Casamento")
                        .HasForeignKey("CerimoniaId");

                    b.HasOne("PVWApi.Models.Decoracao", "Decoracao")
                        .WithMany("Casamento")
                        .HasForeignKey("DecoracaoId");

                    b.HasOne("PVWApi.Models.Festa", "Festa")
                        .WithMany("Casamento")
                        .HasForeignKey("FestaId");

                    b.HasOne("PVWApi.Models.Usuario", "Usuario")
                        .WithMany("Casamento")
                        .HasForeignKey("LoginId");

                    b.Navigation("Cerimonia");

                    b.Navigation("Decoracao");

                    b.Navigation("Festa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PVWApi.Models.Cerimonia", b =>
                {
                    b.HasOne("PVWApi.Models.Celebrante", "Celebrante")
                        .WithMany("Cerimonia")
                        .HasForeignKey("CelebranteId");

                    b.Navigation("Celebrante");
                });

            modelBuilder.Entity("PVWApi.Models.Convidado", b =>
                {
                    b.HasOne("PVWApi.Models.Casamento", "Casamento")
                        .WithMany("Convidado")
                        .HasForeignKey("CasamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Casamento");
                });

            modelBuilder.Entity("PVWApi.Models.Festa", b =>
                {
                    b.HasOne("PVWApi.Models.Banda", "Banda")
                        .WithMany("Festa")
                        .HasForeignKey("BandaId");

                    b.HasOne("PVWApi.Models.Buffet", "Buffet")
                        .WithMany("Festa")
                        .HasForeignKey("BuffetId");

                    b.Navigation("Banda");

                    b.Navigation("Buffet");
                });

            modelBuilder.Entity("PVWApi.Models.Banda", b =>
                {
                    b.Navigation("Festa");
                });

            modelBuilder.Entity("PVWApi.Models.Buffet", b =>
                {
                    b.Navigation("Festa");
                });

            modelBuilder.Entity("PVWApi.Models.Casamento", b =>
                {
                    b.Navigation("Convidado");
                });

            modelBuilder.Entity("PVWApi.Models.Celebrante", b =>
                {
                    b.Navigation("Cerimonia");
                });

            modelBuilder.Entity("PVWApi.Models.Cerimonia", b =>
                {
                    b.Navigation("Casamento");
                });

            modelBuilder.Entity("PVWApi.Models.Decoracao", b =>
                {
                    b.Navigation("Casamento");
                });

            modelBuilder.Entity("PVWApi.Models.Festa", b =>
                {
                    b.Navigation("Casamento");
                });

            modelBuilder.Entity("PVWApi.Models.Usuario", b =>
                {
                    b.Navigation("Casamento");
                });
#pragma warning restore 612, 618
        }
    }
}
