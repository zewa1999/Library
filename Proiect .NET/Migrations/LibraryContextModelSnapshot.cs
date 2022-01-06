﻿// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="LibraryContextModelSnapshot.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Library.DataLayer.DataMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Proiect_.NET.Migrations
{
    /// <summary>
    /// Class LibraryContextModelSnapshot.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />
    [DbContext(typeof(LibraryContext))]
    internal partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        /// <summary>
        /// Builds the model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("Library.DomainLayer.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.DomainLayer.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BorrowId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("bit");

                    b.Property<bool>("LecturesOnlyBook")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BorrowId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.DomainLayer.Borrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NoOfTimeExtended")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.ToTable("Borrow");
                });

            modelBuilder.Entity("Library.DomainLayer.Domain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ParentDomainId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ParentDomainId");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("Library.DomainLayer.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("EditionNumber")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Editions");
                });

            modelBuilder.Entity("Library.DomainLayer.Person.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Library.DomainLayer.Person.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Borrowers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Borrower");
                });

            modelBuilder.Entity("Library.DomainLayer.Properties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Delta")
                        .HasColumnType("int");

                    b.Property<int>("Domenii")
                        .HasColumnType("int");

                    b.Property<int>("L")
                        .HasColumnType("int");

                    b.Property<int>("LimitaMaximaImprumut")
                        .HasColumnType("int");

                    b.Property<int>("NrMaximCartiImprumutate")
                        .HasColumnType("int");

                    b.Property<int>("NrMaximCartiImprumutateAcelasiDomeniu")
                        .HasColumnType("int");

                    b.Property<int>("NumarCartiImprumutateZilnic")
                        .HasColumnType("int");

                    b.Property<int>("NumarMaximCarti")
                        .HasColumnType("int");

                    b.Property<int>("Perioada")
                        .HasColumnType("int");

                    b.Property<int>("Persimp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Library.DomainLayer.Person.Librarian", b =>
                {
                    b.HasBaseType("Library.DomainLayer.Person.Borrower");

                    b.Property<bool>("IsReader")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Librarian");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Library.DomainLayer.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.DomainLayer.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.DomainLayer.Book", b =>
                {
                    b.HasOne("Library.DomainLayer.Borrow", null)
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("BorrowId");
                });

            modelBuilder.Entity("Library.DomainLayer.Borrow", b =>
                {
                    b.HasOne("Library.DomainLayer.Person.Borrower", "Borrower")
                        .WithMany()
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Borrower");
                });

            modelBuilder.Entity("Library.DomainLayer.Domain", b =>
                {
                    b.HasOne("Library.DomainLayer.Book", null)
                        .WithMany("Domains")
                        .HasForeignKey("BookId");

                    b.HasOne("Library.DomainLayer.Domain", "ParentDomain")
                        .WithMany("ChildrenDomains")
                        .HasForeignKey("ParentDomainId");

                    b.Navigation("ParentDomain");
                });

            modelBuilder.Entity("Library.DomainLayer.Edition", b =>
                {
                    b.HasOne("Library.DomainLayer.Book", null)
                        .WithMany("Editions")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("Library.DomainLayer.Person.Borrower", b =>
                {
                    b.HasOne("Library.DomainLayer.Person.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Library.DomainLayer.Book", b =>
                {
                    b.Navigation("Domains");

                    b.Navigation("Editions");
                });

            modelBuilder.Entity("Library.DomainLayer.Borrow", b =>
                {
                    b.Navigation("BorrowedBooks");
                });

            modelBuilder.Entity("Library.DomainLayer.Domain", b =>
                {
                    b.Navigation("ChildrenDomains");
                });
#pragma warning restore 612, 618
        }
    }
}