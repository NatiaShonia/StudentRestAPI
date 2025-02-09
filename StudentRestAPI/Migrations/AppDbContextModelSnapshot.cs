﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentRestAPI.Models;

namespace StudentRestAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentRestAPI.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            DateOfBirth = new DateTime(1990, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 4,
                            Email = "Akash@simlilearn.com",
                            FirstName = "Akash",
                            Gender = 0,
                            LastName = "Gupta",
                            PhotoPath = "Images/Akash.png"
                        },
                        new
                        {
                            StudentId = 2,
                            DateOfBirth = new DateTime(1990, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Email = "Sam@simlilearn.com",
                            FirstName = "Sam",
                            Gender = 0,
                            LastName = "Matheus",
                            PhotoPath = "Images/Sam.png"
                        },
                        new
                        {
                            StudentId = 3,
                            DateOfBirth = new DateTime(1987, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Email = "Chris@simlilearn.com",
                            FirstName = "Christina",
                            Gender = 1,
                            LastName = "Frost",
                            PhotoPath = "Images/Christina.png"
                        },
                        new
                        {
                            StudentId = 4,
                            DateOfBirth = new DateTime(1993, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            Email = "Rachel@simlilearn.com",
                            FirstName = "Rachel",
                            Gender = 1,
                            LastName = "Stone",
                            PhotoPath = "Images/Rachel.png"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
