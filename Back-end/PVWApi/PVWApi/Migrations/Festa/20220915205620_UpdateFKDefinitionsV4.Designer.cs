﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PVWApi.Models;

#nullable disable

namespace PVWApi.Migrations.Festa
{
    [DbContext(typeof(FestaContext))]
    [Migration("20220915205620_UpdateFKDefinitionsV4")]
    partial class UpdateFKDefinitionsV4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
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

            modelBuilder.Entity("PVWApi.Models.Festa", b =>
                {
                    b.Property<int>("FestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FestaId"), 1L, 1);

                    b.Property<int>("BandaId")
                        .HasColumnType("int");

                    b.Property<int>("BuffetId")
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

            modelBuilder.Entity("PVWApi.Models.Festa", b =>
                {
                    b.HasOne("PVWApi.Models.Banda", "Banda")
                        .WithMany("Festa")
                        .HasForeignKey("BandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PVWApi.Models.Buffet", "Buffet")
                        .WithMany("Festa")
                        .HasForeignKey("BuffetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
#pragma warning restore 612, 618
        }
    }
}
