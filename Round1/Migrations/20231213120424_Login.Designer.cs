﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Round1.Models;

#nullable disable

namespace Round1.Migrations
{
    [DbContext(typeof(HastaneContext))]
    [Migration("20231213120424_Login")]
    partial class Login
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Round1.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Round1.Models.AnaBilimDali", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HastaneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AnaBilimDalis");
                });

            modelBuilder.Entity("Round1.Models.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoliklinikId")
                        .HasColumnType("int");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doktors");
                });

            modelBuilder.Entity("Round1.Models.DoktorIzinGunu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("BaslangıcSaat")
                        .HasColumnType("time");

                    b.Property<DateTime>("BaslangıcTarih")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("BitisSaat")
                        .HasColumnType("time");

                    b.Property<DateTime>("BitisTarih")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DoktorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.ToTable("DoktorIzinGunus");
                });

            modelBuilder.Entity("Round1.Models.Hasta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DogumYılı")
                        .HasColumnType("int");

                    b.Property<string>("HastaPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TCKimlikNumarası")
                        .HasColumnType("bigint");

                    b.Property<string>("TelefonNumarası")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hastas");
                });

            modelBuilder.Entity("Round1.Models.Hastane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNumarası")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hastanes");
                });

            modelBuilder.Entity("Round1.Models.Poliklinik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnaBilimDaliId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnaBilimDaliId");

                    b.ToTable("Polikliniks");
                });

            modelBuilder.Entity("Round1.Models.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("HastaId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Saat")
                        .HasColumnType("time");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("HastaId");

                    b.ToTable("Randevus");
                });

            modelBuilder.Entity("Round1.Models.DoktorIzinGunu", b =>
                {
                    b.HasOne("Round1.Models.Doktor", null)
                        .WithMany("DoktorIzinGunu")
                        .HasForeignKey("DoktorId");
                });

            modelBuilder.Entity("Round1.Models.Poliklinik", b =>
                {
                    b.HasOne("Round1.Models.AnaBilimDali", null)
                        .WithMany("Poliklinik")
                        .HasForeignKey("AnaBilimDaliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Round1.Models.Randevu", b =>
                {
                    b.HasOne("Round1.Models.Doktor", null)
                        .WithMany("Randevu")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Round1.Models.Hasta", null)
                        .WithMany("Randevu")
                        .HasForeignKey("HastaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Round1.Models.AnaBilimDali", b =>
                {
                    b.Navigation("Poliklinik");
                });

            modelBuilder.Entity("Round1.Models.Doktor", b =>
                {
                    b.Navigation("DoktorIzinGunu");

                    b.Navigation("Randevu");
                });

            modelBuilder.Entity("Round1.Models.Hasta", b =>
                {
                    b.Navigation("Randevu");
                });
#pragma warning restore 612, 618
        }
    }
}
