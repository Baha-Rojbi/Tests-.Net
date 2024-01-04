﻿// <auto-generated />
using System;
using Exam.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exam.Infrastructure.Migrations
{
    [DbContext(typeof(ExamContext))]
    [Migration("20240103225847_FirstMiration")]
    partial class FirstMiration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exam.CoreApplication.Domain.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Exam.CoreApplication.Domain.Fournisseur", b =>
                {
                    b.Property<int>("Identifiant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identifiant"));

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Identifiant");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("Exam.CoreApplication.Domain.Produit", b =>
                {
                    b.Property<int>("ProduitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduitId"));

                    b.Property<int>("CategorieFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateProd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("TypeProduit")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("ProduitId");

                    b.HasIndex("CategorieFk");

                    b.ToTable("Produits");

                    b.HasDiscriminator<string>("TypeProduit").HasValue("P");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FournisseurProduit", b =>
                {
                    b.Property<int>("FournisseursIdentifiant")
                        .HasColumnType("int");

                    b.Property<int>("ProduitsProduitId")
                        .HasColumnType("int");

                    b.HasKey("FournisseursIdentifiant", "ProduitsProduitId");

                    b.HasIndex("ProduitsProduitId");

                    b.ToTable("Facture", (string)null);
                });

            modelBuilder.Entity("Exam.CoreApplication.Domain.Biologique", b =>
                {
                    b.HasBaseType("Exam.CoreApplication.Domain.Produit");

                    b.Property<string>("Composition")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("B");
                });

            modelBuilder.Entity("Exam.CoreApplication.Domain.Chimique", b =>
                {
                    b.HasBaseType("Exam.CoreApplication.Domain.Produit");

                    b.Property<string>("NomLab")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("C");
                });

            modelBuilder.Entity("Exam.CoreApplication.Domain.Produit", b =>
                {
                    b.HasOne("Exam.CoreApplication.Domain.Categorie", "Categorie")
                        .WithMany("Produits")
                        .HasForeignKey("CategorieFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("FournisseurProduit", b =>
                {
                    b.HasOne("Exam.CoreApplication.Domain.Fournisseur", null)
                        .WithMany()
                        .HasForeignKey("FournisseursIdentifiant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exam.CoreApplication.Domain.Produit", null)
                        .WithMany()
                        .HasForeignKey("ProduitsProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Exam.CoreApplication.Domain.Categorie", b =>
                {
                    b.Navigation("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}