﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySpot.Modules.Availability.Infrastructure.DAL;

#nullable disable

namespace MySpot.Modules.Availability.Infrastructure.DAL.Migrations
{
    [DbContext(typeof(AvailabilityDbContext))]
    partial class AvailabilityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("availability")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MySpot.Modules.Availability.Core.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("Reservations", "availability");
                });

            modelBuilder.Entity("MySpot.Modules.Availability.Core.Entities.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Resources", "availability");
                });

            modelBuilder.Entity("MySpot.Modules.Availability.Core.Entities.Reservation", b =>
                {
                    b.HasOne("MySpot.Modules.Availability.Core.Entities.Resource", null)
                        .WithMany("Reservations")
                        .HasForeignKey("ResourceId");
                });

            modelBuilder.Entity("MySpot.Modules.Availability.Core.Entities.Resource", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
