﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ni_Soft.InscriptionApi.Data.Databases;

namespace Ni_Soft.InscriptionApi.Data.Migrations
{
    [DbContext(typeof(InscriptionDbContext))]
    partial class InscriptionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Ni_Soft.InscriptionApi.Data.Entities.CustomerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedOn = new DateTime(2022, 4, 9, 21, 27, 57, 367, DateTimeKind.Local).AddTicks(2326),
                            Firstname = "Frank",
                            Lastname = "Lacroix"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedOn = new DateTime(2022, 4, 9, 21, 27, 57, 367, DateTimeKind.Local).AddTicks(2326),
                            Firstname = "Marie",
                            Lastname = "Kapinga"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedOn = new DateTime(2022, 4, 9, 21, 27, 57, 367, DateTimeKind.Local).AddTicks(2326),
                            Firstname = "Lea",
                            Lastname = "Agnes"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
