﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeTrackingApi.Models;

#nullable disable

namespace TimeTrackingApi.Migrations
{
    [DbContext(typeof(trackingcontext))]
    [Migration("20220625123636_CityID")]
    partial class CityID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SubActivity", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<string>("Dificulty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Parentid")
                        .HasColumnType("bigint");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("numberOfHours")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("Parentid");

                    b.ToTable("SubActivity");
                });

            modelBuilder.Entity("TimeTrackingApi.City", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("TimeTrackingApi.Country", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("TimeTrackingApi.State", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("TimeTrackingApi.tracking", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<long?>("Cityid")
                        .HasColumnType("bigint");

                    b.Property<long?>("Countryid")
                        .HasColumnType("bigint");

                    b.Property<long?>("Parentid")
                        .HasColumnType("bigint");

                    b.Property<long?>("Stateid")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("numberOfHours")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("Cityid");

                    b.HasIndex("Countryid");

                    b.HasIndex("Parentid");

                    b.HasIndex("Stateid");

                    b.ToTable("Tracking");
                });

            modelBuilder.Entity("TimeTrackingApi.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsConfirmed")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SubActivity", b =>
                {
                    b.HasOne("TimeTrackingApi.tracking", "Parent")
                        .WithMany("SubActivities")
                        .HasForeignKey("Parentid");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TimeTrackingApi.tracking", b =>
                {
                    b.HasOne("TimeTrackingApi.City", "City")
                        .WithMany()
                        .HasForeignKey("Cityid");

                    b.HasOne("TimeTrackingApi.Country", "Country")
                        .WithMany()
                        .HasForeignKey("Countryid");

                    b.HasOne("TimeTrackingApi.User", "Parent")
                        .WithMany("Trackings")
                        .HasForeignKey("Parentid");

                    b.HasOne("TimeTrackingApi.State", "State")
                        .WithMany()
                        .HasForeignKey("Stateid");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Parent");

                    b.Navigation("State");
                });

            modelBuilder.Entity("TimeTrackingApi.tracking", b =>
                {
                    b.Navigation("SubActivities");
                });

            modelBuilder.Entity("TimeTrackingApi.User", b =>
                {
                    b.Navigation("Trackings");
                });
#pragma warning restore 612, 618
        }
    }
}
