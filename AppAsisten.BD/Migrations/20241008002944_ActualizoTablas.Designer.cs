﻿// <auto-generated />
using System;
using AppAsisten.BD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppAsisten.BD.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241008002944_ActualizoTablas")]
    partial class ActualizoTablas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppAsisten.BD.Data.Entity.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("AppAsisten.BD.Data.Entity.Asistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime2");

                    b.Property<int>("MiembroId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Salida")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MiembroId");

                    b.ToTable("Asistencias");
                });

            modelBuilder.Entity("AppAsisten.BD.Data.Entity.Cuota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("EsPagada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("MiembroId")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MiembroId");

                    b.ToTable("Cuotas");
                });

            modelBuilder.Entity("AppAsisten.BD.Data.Entity.Miembro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Miembros");
                });

            modelBuilder.Entity("AppAsisten.BD.Data.Entity.Asistencia", b =>
                {
                    b.HasOne("AppAsisten.BD.Data.Entity.Miembro", "Miembro")
                        .WithMany("Asistencias")
                        .HasForeignKey("MiembroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Miembro");
                });

            modelBuilder.Entity("AppAsisten.BD.Data.Entity.Cuota", b =>
                {
                    b.HasOne("AppAsisten.BD.Data.Entity.Miembro", "Miembro")
                        .WithMany("Cuotas")
                        .HasForeignKey("MiembroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Miembro");
                });

            modelBuilder.Entity("AppAsisten.BD.Data.Entity.Miembro", b =>
                {
                    b.Navigation("Asistencias");

                    b.Navigation("Cuotas");
                });
#pragma warning restore 612, 618
        }
    }
}
