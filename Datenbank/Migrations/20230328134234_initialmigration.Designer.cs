﻿// <auto-generated />
using Datenbank.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datenbank.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230328134234_initialmigration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Datenbank.Model.Ansprechpartner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Ansprechpartner");
                });

            modelBuilder.Entity("Datenbank.Model.Kunde", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnsprechId")
                        .HasColumnType("int");

                    b.Property<string>("Betrieb")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ort")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PLZ")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Straße")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("AnsprechId")
                        .IsUnique();

                    b.ToTable("Kunde");
                });

            modelBuilder.Entity("Datenbank.Model.Kunde", b =>
                {
                    b.HasOne("Datenbank.Model.Ansprechpartner", "Ansprechpartner")
                        .WithOne("Kunde")
                        .HasForeignKey("Datenbank.Model.Kunde", "AnsprechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ansprechpartner");
                });

            modelBuilder.Entity("Datenbank.Model.Ansprechpartner", b =>
                {
                    b.Navigation("Kunde")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
