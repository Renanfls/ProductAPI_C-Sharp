﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsApi.Data;

#nullable disable

namespace productapi.Migrations;

[DbContext(typeof(ProductContext))]
partial class ProductContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.12")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        modelBuilder.Entity("ProductsApi.Models.Product", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Mark")
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnType("varchar(15)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("varchar(30)");

                b.Property<int>("Quantity")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Products");
            });
#pragma warning restore 612, 618
    }
}

