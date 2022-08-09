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
    [Migration("20220613103945_TrackingToUsers")]
    partial class TrackingToUsers
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

            modelBuilder.Entity("TimeTrackingApi.tracking", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<long?>("Parentid")
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

                    b.HasIndex("Parentid");

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
                        .IsRequired()
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
                    b.HasOne("TimeTrackingApi.User", "Parent")
                        .WithMany("Trackings")
                        .HasForeignKey("Parentid");

                    b.Navigation("Parent");
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
