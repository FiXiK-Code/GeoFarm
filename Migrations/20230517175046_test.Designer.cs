﻿// <auto-generated />
using MVP.Date;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVP.Migrations
{
    [DbContext(typeof(AppDB))]
    [Migration("20230517175046_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVP.Date.Models.Title", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("DBTitle");
                });
#pragma warning restore 612, 618
        }
    }
}
