﻿// <auto-generated />
using System;
using AddressBookAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AddressBookAPI.Migrations
{
    [DbContext(typeof(AddressBookDbContext))]
    [Migration("20221002215053_namesConventionConvert")]
    partial class namesConventionConvert
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressBookId")
                        .HasColumnName("address_book_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressTypeId")
                        .HasColumnName("address_type_id")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<Guid>("CountryTypeId")
                        .HasColumnName("country_type_id")
                        .HasColumnType("uuid");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnName("line_1")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Line2")
                        .IsRequired()
                        .HasColumnName("line_2")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnName("state_name")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnName("zip_code")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressBookId");

                    b.HasIndex("UserId");

                    b.ToTable("address");
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.AddressBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("address_book");
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressBookId")
                        .HasColumnName("address_book_id")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnName("content")
                        .HasColumnType("text");

                    b.Property<string>("DownloadUrl")
                        .IsRequired()
                        .HasColumnName("download_url")
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnName("file_name")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnName("file_type")
                        .HasColumnType("text");

                    b.Property<decimal>("Size")
                        .HasColumnName("size")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AddressBookId");

                    b.HasIndex("UserId");

                    b.ToTable("asset");
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressBookId")
                        .HasColumnName("address_book_id")
                        .HasColumnType("uuid");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnName("email_address")
                        .HasColumnType("text");

                    b.Property<Guid>("EmailTypeId")
                        .HasColumnName("email_type_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AddressBookId");

                    b.HasIndex("UserId");

                    b.ToTable("email");
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressBookId")
                        .HasColumnName("address_book_id")
                        .HasColumnType("uuid");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("phone_number")
                        .HasColumnType("character varying(13)")
                        .HasMaxLength(13);

                    b.Property<Guid>("PhoneTypeId")
                        .HasColumnName("phone_type_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AddressBookId");

                    b.HasIndex("UserId");

                    b.ToTable("phone");
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.RefSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Set")
                        .IsRequired()
                        .HasColumnName("set")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("ref_set");
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.RefSetMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RefSetId")
                        .HasColumnName("ref_set_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RefTermId")
                        .HasColumnName("ref_term_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RefSetId");

                    b.HasIndex("RefTermId");

                    b.ToTable("set_term_mapping");
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.RefTerm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnName("key")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("ref_term");
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnName("hash")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("user_name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserName");

                    b.ToTable("user");
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.Address", b =>
                {
                    b.HasOne("AddressBookAPI.Entities.DataSets.AddressBook", "AddressBook")
                        .WithMany()
                        .HasForeignKey("AddressBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AddressBookAPI.Entities.DataSets.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.AddressBook", b =>
                {
                    b.HasOne("AddressBookAPI.Entities.DataSets.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.Asset", b =>
                {
                    b.HasOne("AddressBookAPI.Entities.DataSets.AddressBook", "AddressBook")
                        .WithMany()
                        .HasForeignKey("AddressBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AddressBookAPI.Entities.DataSets.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.Email", b =>
                {
                    b.HasOne("AddressBookAPI.Entities.DataSets.AddressBook", "AddressBook")
                        .WithMany()
                        .HasForeignKey("AddressBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AddressBookAPI.Entities.DataSets.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.Phone", b =>
                {
                    b.HasOne("AddressBookAPI.Entities.DataSets.AddressBook", "AddressBook")
                        .WithMany()
                        .HasForeignKey("AddressBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AddressBookAPI.Entities.DataSets.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AddressBookAPI.Entities.DataSets.RefSetMapping", b =>
                {
                    b.HasOne("AddressBookAPI.Entities.DataSets.RefSet", "RefSet")
                        .WithMany()
                        .HasForeignKey("RefSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AddressBookAPI.Entities.DataSets.RefTerm", "RefTerm")
                        .WithMany()
                        .HasForeignKey("RefTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
