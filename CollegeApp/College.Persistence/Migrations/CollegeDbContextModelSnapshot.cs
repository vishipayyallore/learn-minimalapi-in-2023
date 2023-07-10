﻿// <auto-generated />
using System;
using College.MinApi.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace College.Persistence.Migrations
{
    [DbContext(typeof(CollegeDbContext))]
    partial class CollegeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("College.Data.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseType")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d022754a-4bca-476f-a3f5-4875d25bd2cd"),
                            CourseType = 1,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 7, 10, 21, 3, 16, 787, DateTimeKind.Local).AddTicks(4996),
                            Duration = 1,
                            ModifiedBy = "Admin",
                            ModifiedDate = new DateTime(2023, 7, 10, 21, 3, 16, 787, DateTimeKind.Local).AddTicks(5010),
                            Name = "Minimal API Development"
                        },
                        new
                        {
                            Id = new Guid("8b2c08e2-a9d7-4a70-961d-4860cb843c43"),
                            CourseType = 2,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 7, 10, 21, 3, 16, 787, DateTimeKind.Local).AddTicks(5018),
                            Duration = 4,
                            ModifiedBy = "Admin",
                            ModifiedDate = new DateTime(2023, 7, 10, 21, 3, 16, 787, DateTimeKind.Local).AddTicks(5019),
                            Name = "Ultimate API Development"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
