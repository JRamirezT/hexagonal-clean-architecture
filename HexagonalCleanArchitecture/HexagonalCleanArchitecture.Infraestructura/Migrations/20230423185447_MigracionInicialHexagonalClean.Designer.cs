﻿// <auto-generated />
using System;
using HexagonalCleanArchitecture.Infraestructura.RepositorioGenerico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HexagonalCleanArchitecture.Infraestructura.Migrations
{
    [DbContext(typeof(HexagonalContext))]
    [Migration("20230423185447_MigracionInicialHexagonalClean")]
    partial class MigracionInicialHexagonalClean
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("HexagonalCleanArchitecture")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HexagonalCleanArchitecture.Dominio.Entidades.Vehiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Modelo")
                        .HasColumnType("integer");

                    b.Property<int>("TipoVehiculo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Vehiculo", "HexagonalCleanArchitecture");
                });
#pragma warning restore 612, 618
        }
    }
}
