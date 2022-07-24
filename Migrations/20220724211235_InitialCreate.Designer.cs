﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankingApp_PK.Migrations
{
    [DbContext(typeof(BankingContext))]
    [Migration("20220724211235_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("BankingApp_PK.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BankingApp_PK.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("DestinationBalance")
                        .HasColumnType("REAL");

                    b.Property<int>("DestinationId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("SourceBalance")
                        .HasColumnType("REAL");

                    b.Property<int>("SourceId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TransferAmount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TransferTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Transaction");
                });
#pragma warning restore 612, 618
        }
    }
}
