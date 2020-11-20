﻿// <auto-generated />
using System;
using DonarService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DonarService.Migrations
{
    [DbContext(typeof(DonarsServiceContext))]
    partial class DonarsServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DonarService.Models.Donar", b =>
                {
                    b.Property<int>("DonorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateOfDonation")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("organization_Id")
                        .HasColumnType("int");

                    b.HasKey("DonorId");

                    b.ToTable("Donardetails");
                });
#pragma warning restore 612, 618
        }
    }
}
