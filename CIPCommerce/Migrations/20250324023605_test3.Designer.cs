﻿// <auto-generated />
using System;
using CIPCommerce.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CIPCommerce.Migrations
{
    [DbContext(typeof(BdContexteCommerce))]
    [Migration("20250324023605_test3")]
    partial class test3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CIPCommerce.Modeles.Facture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAchat")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAcheteur")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAcheteur");

                    b.ToTable("TableFacture");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.FactureProduits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdFacture")
                        .HasColumnType("int");

                    b.Property<int>("IdProduit")
                        .HasColumnType("int");

                    b.Property<int>("Qte")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdFacture");

                    b.HasIndex("IdProduit");

                    b.ToTable("TableFactureProduits");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.Panier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdAcheteur")
                        .HasColumnType("int");

                    b.Property<int>("IdProduit")
                        .HasColumnType("int");

                    b.Property<int>("Qte")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAcheteur");

                    b.HasIndex("IdProduit");

                    b.ToTable("TablePanier");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EnVente")
                        .HasColumnType("bit");

                    b.Property<int>("IdVendeur")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdVendeur");

                    b.ToTable("TableProduit");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Actif")
                        .HasColumnType("bit");

                    b.Property<string>("Identifiant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mdp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TableUtilisateur");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.Facture", b =>
                {
                    b.HasOne("CIPCommerce.Modeles.Utilisateur", "Acheteur")
                        .WithMany("Factures")
                        .HasForeignKey("IdAcheteur")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Acheteur");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.FactureProduits", b =>
                {
                    b.HasOne("CIPCommerce.Modeles.Facture", "LaFacture")
                        .WithMany("ListeProduits")
                        .HasForeignKey("IdFacture")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CIPCommerce.Modeles.Produit", "LeProduit")
                        .WithMany("FactureProduits")
                        .HasForeignKey("IdProduit")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LaFacture");

                    b.Navigation("LeProduit");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.Panier", b =>
                {
                    b.HasOne("CIPCommerce.Modeles.Utilisateur", "Acheteur")
                        .WithMany("Paniers")
                        .HasForeignKey("IdAcheteur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CIPCommerce.Modeles.Produit", "LeProduit")
                        .WithMany("Paniers")
                        .HasForeignKey("IdProduit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acheteur");

                    b.Navigation("LeProduit");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.Produit", b =>
                {
                    b.HasOne("CIPCommerce.Modeles.Utilisateur", "Vendeur")
                        .WithMany("Produits")
                        .HasForeignKey("IdVendeur")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Vendeur");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.Facture", b =>
                {
                    b.Navigation("ListeProduits");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.Produit", b =>
                {
                    b.Navigation("FactureProduits");

                    b.Navigation("Paniers");
                });

            modelBuilder.Entity("CIPCommerce.Modeles.Utilisateur", b =>
                {
                    b.Navigation("Factures");

                    b.Navigation("Paniers");

                    b.Navigation("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}
