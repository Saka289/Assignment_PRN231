﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryAPI.Data;

#nullable disable

namespace RepositoryAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240122153904_AddTableToDB")]
    partial class AddTableToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RepositoryAPI.Models.MedicalFacility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityId"), 1L, 1);

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("NoDoctor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateFacility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacilityId");

                    b.ToTable("MedicalFacilities");
                });

            modelBuilder.Entity("RepositoryAPI.Models.ServicePriceList", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ServicePrice")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("ServiceId");

                    b.HasIndex("FacilityId");

                    b.ToTable("ServicePriceLists");
                });

            modelBuilder.Entity("RepositoryAPI.Models.ServicePriceList", b =>
                {
                    b.HasOne("RepositoryAPI.Models.MedicalFacility", "MedicalFacility")
                        .WithMany("ServicePriceLists")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalFacility");
                });

            modelBuilder.Entity("RepositoryAPI.Models.MedicalFacility", b =>
                {
                    b.Navigation("ServicePriceLists");
                });
#pragma warning restore 612, 618
        }
    }
}
