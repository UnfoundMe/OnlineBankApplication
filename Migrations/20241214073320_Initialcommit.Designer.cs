﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineBankApplication.Data;

#nullable disable

namespace OnlineBankApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241214073320_Initialcommit")]
    partial class Initialcommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineBankApplication.Models.Account", b =>
                {
                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AccountName");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("OnlineBankApplication.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FromAccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("FromAccounttBal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ToAccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ToAccounttBal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.HasIndex("FromAccountName");

                    b.HasIndex("ToAccountName");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("OnlineBankApplication.Models.Transaction", b =>
                {
                    b.HasOne("OnlineBankApplication.Models.Account", "FromAccount")
                        .WithMany()
                        .HasForeignKey("FromAccountName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBankApplication.Models.Account", "ToAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
