﻿// <auto-generated />
using System;
using METRO.digital.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace METRO.digital.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20221003164159_InitSchema")]
    partial class InitSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7");

            modelBuilder.Entity("METRO.digital.Models.ArtIcle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Article")
                        .HasColumnType("TEXT");

                    b.Property<long?>("BasketId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.ToTable("ArtIcle");
                });

            modelBuilder.Entity("METRO.digital.Models.Basket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Customer")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PaysVAT")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalGross")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalNet")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("METRO.digital.Models.ArtIcle", b =>
                {
                    b.HasOne("METRO.digital.Models.Basket", null)
                        .WithMany("Articles")
                        .HasForeignKey("BasketId");
                });

            modelBuilder.Entity("METRO.digital.Models.Basket", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}