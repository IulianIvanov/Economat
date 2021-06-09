﻿// <auto-generated />
using System;
using Economat_v2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Economat_v2.Migrations
{
    [DbContext(typeof(EconomatContext))]
    [Migration("20210303090059_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Economat_v2.Models.Angajat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CIM")
                        .HasColumnType("int");

                    b.Property<string>("CNP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume_Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Restanta_Totala")
                        .HasColumnType("int");

                    b.Property<int>("Sold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Angajati");
                });

            modelBuilder.Entity("Economat_v2.Models.Companie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Companii");
                });

            modelBuilder.Entity("Economat_v2.Models.Detali", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cantitate_Produs")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<string>("Nume_Produs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.Property<int>("ProdusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProdusId");

                    b.ToTable("Detalii");
                });

            modelBuilder.Entity("Economat_v2.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AngajatId")
                        .HasColumnType("int");

                    b.Property<int>("CIM_Angajat")
                        .HasColumnType("int");

                    b.Property<int>("CompanieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Numar_Document")
                        .HasColumnType("int");

                    b.Property<int>("Numar_FacturaId")
                        .HasColumnType("int");

                    b.Property<string>("Nume_Angajat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Restanta")
                        .HasColumnType("int");

                    b.Property<int>("Serie")
                        .HasColumnType("int");

                    b.Property<int>("Suma_Platita")
                        .HasColumnType("int");

                    b.Property<int>("Suma_Totala")
                        .HasColumnType("int");

                    b.Property<string>("Tip_Document")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AngajatId");

                    b.HasIndex("CompanieId")
                        .IsUnique();

                    b.HasIndex("Numar_FacturaId")
                        .IsUnique();

                    b.ToTable("Facturi");
                });

            modelBuilder.Entity("Economat_v2.Models.Numar_Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Numar_Curent")
                        .HasColumnType("int");

                    b.Property<int>("Numar_Inceput")
                        .HasColumnType("int");

                    b.Property<int>("Numar_Sfarsit")
                        .HasColumnType("int");

                    b.Property<int>("Serie")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Numar_Facturi");
                });

            modelBuilder.Entity("Economat_v2.Models.Produs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Categorie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pret_Unitate")
                        .HasColumnType("int");

                    b.Property<int>("Stoc")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produse");
                });

            modelBuilder.Entity("Economat_v2.Models.Detali", b =>
                {
                    b.HasOne("Economat_v2.Models.Factura", "Factura")
                        .WithMany("Detalii")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Economat_v2.Models.Produs", "Produs")
                        .WithMany("Detalii")
                        .HasForeignKey("ProdusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Produs");
                });

            modelBuilder.Entity("Economat_v2.Models.Factura", b =>
                {
                    b.HasOne("Economat_v2.Models.Angajat", "Angajat")
                        .WithMany("Facturi")
                        .HasForeignKey("AngajatId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Economat_v2.Models.Companie", "Companie")
                        .WithOne("Factura")
                        .HasForeignKey("Economat_v2.Models.Factura", "CompanieId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Economat_v2.Models.Numar_Factura", "Numar_Factura")
                        .WithOne("Factura")
                        .HasForeignKey("Economat_v2.Models.Factura", "Numar_FacturaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Angajat");

                    b.Navigation("Companie");

                    b.Navigation("Numar_Factura");
                });

            modelBuilder.Entity("Economat_v2.Models.Angajat", b =>
                {
                    b.Navigation("Facturi");
                });

            modelBuilder.Entity("Economat_v2.Models.Companie", b =>
                {
                    b.Navigation("Factura");
                });

            modelBuilder.Entity("Economat_v2.Models.Factura", b =>
                {
                    b.Navigation("Detalii");
                });

            modelBuilder.Entity("Economat_v2.Models.Numar_Factura", b =>
                {
                    b.Navigation("Factura");
                });

            modelBuilder.Entity("Economat_v2.Models.Produs", b =>
                {
                    b.Navigation("Detalii");
                });
#pragma warning restore 612, 618
        }
    }
}
