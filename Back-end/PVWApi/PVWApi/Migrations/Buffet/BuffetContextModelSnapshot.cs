﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PVWApi.Models;

#nullable disable

namespace PVWApi.Migrations.Buffet
{
    [DbContext(typeof(BuffetContext))]
    partial class BuffetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.ToTable("Buffet", (string)null);
                });

            modelBuilder.Entity("PVWApi.Models.Festa", b =>
                {
                    b.Property<int>("FestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FestaId"), 1L, 1);

                    b.Property<int?>("BuffetId")
                        .HasColumnType("int");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<int>("FkBandaId")
                        .HasColumnType("int");

                    b.Property<int>("FkBuffetId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HorasContratadas")
                        .HasColumnType("time");

                    b.Property<string>("NomeLocal")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FestaId");

                    b.HasIndex("BuffetId");

                    b.ToTable("Festa", (string)null);
                });

            modelBuilder.Entity("PVWApi.Models.Festa", b =>
                {
                    b.HasOne("PVWApi.Models.Buffet", null)
                        .WithMany("Festa")
                        .HasForeignKey("BuffetId");
                });

            modelBuilder.Entity("PVWApi.Models.Buffet", b =>
                {
                    b.Navigation("Festa");
                });
#pragma warning restore 612, 618
        }
    }
}
