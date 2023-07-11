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
                            Id = new Guid("e0f35ed0-6dcf-42e4-b952-f56c8c883c18"),
                            CourseType = 1,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 7, 10, 22, 28, 44, 95, DateTimeKind.Local).AddTicks(7144),
                            Duration = 1,
                            ModifiedBy = "Admin",
                            ModifiedDate = new DateTime(2023, 7, 10, 22, 28, 44, 95, DateTimeKind.Local).AddTicks(7158),
                            Name = "Minimal API Development"
                        },
                        new
                        {
                            Id = new Guid("2f919a8b-ceb6-4123-86cc-6fb18ce10ca1"),
                            CourseType = 2,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 7, 10, 22, 28, 44, 95, DateTimeKind.Local).AddTicks(7167),
                            Duration = 4,
                            ModifiedBy = "Admin",
                            ModifiedDate = new DateTime(2023, 7, 10, 22, 28, 44, 95, DateTimeKind.Local).AddTicks(7168),
                            Name = "Ultimate API Development"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
