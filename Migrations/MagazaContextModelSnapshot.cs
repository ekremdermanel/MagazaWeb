﻿// <auto-generated />
using System;
using MagazaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagazaWeb.Migrations
{
    [DbContext(typeof(MagazaContext))]
    partial class MagazaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MagazaWeb.Models.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Aciklama")
                        .HasColumnType("longtext")
                        .HasColumnName("Bilgi");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal?>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Stok")
                        .HasColumnType("int");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("tblUrunler");
                });
#pragma warning restore 612, 618
        }
    }
}
