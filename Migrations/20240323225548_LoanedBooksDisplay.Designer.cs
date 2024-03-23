﻿// <auto-generated />
using System;
using Collection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Collection.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240323225548_LoanedBooksDisplay")]
    partial class LoanedBooksDisplay
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Collection.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Biography")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nationality")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Collection.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AuthorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Collection.Models.LoanedBooks", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LoanDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReturnDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.HasIndex("UserID");

                    b.ToTable("LoanedBooks");
                });

            modelBuilder.Entity("Collection.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TelephoneNr")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Collection.Models.Book", b =>
                {
                    b.HasOne("Collection.Models.Author", "Author")
                        .WithMany("Book")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Collection.Models.LoanedBooks", b =>
                {
                    b.HasOne("Collection.Models.Book", "Book")
                        .WithMany("LoanedBooks")
                        .HasForeignKey("BookID");

                    b.HasOne("Collection.Models.User", "User")
                        .WithMany("LoanedBooks")
                        .HasForeignKey("UserID");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Collection.Models.Author", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("Collection.Models.Book", b =>
                {
                    b.Navigation("LoanedBooks");
                });

            modelBuilder.Entity("Collection.Models.User", b =>
                {
                    b.Navigation("LoanedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
