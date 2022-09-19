﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PVWApi.Models;

#nullable disable

namespace PVWApi.Migrations.Banda
{
    [DbContext(typeof(BandaContext))]
    [Migration("20220914132905_Insert Banda table")]
    partial class InsertBandatable
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
                        .HasColumnType("decimal");

                    b.HasKey("BandaId");

                    b.ToTable("Banda");
                });
#pragma warning restore 612, 618
        }
    }
}
