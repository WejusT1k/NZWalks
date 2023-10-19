﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    partial class NZWalksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae7585ee-52e5-4593-8d63-a09be9336e69"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("a0e7c01c-1f61-4a41-a905-041062a890d7"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("f2160189-3a1f-4dfc-b990-1ba76b940e90"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0e2ed24-2aad-4c5f-9501-207e29bd3671"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0"
                        },
                        new
                        {
                            Id = new Guid("ebd7664d-b99d-4361-93f6-a9feba3f7b93"),
                            Code = "NTL",
                            Name = "Northland",
                            RegionImageUrl = "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0"
                        },
                        new
                        {
                            Id = new Guid("4efa3513-a446-482e-ba64-9d64f7042f11"),
                            Code = "BOP",
                            Name = "Bay Of Plenty",
                            RegionImageUrl = "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0"
                        },
                        new
                        {
                            Id = new Guid("a52e7e5d-4352-4c9f-a012-c261b06563a1"),
                            Code = "STL",
                            Name = "Southland",
                            RegionImageUrl = "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
