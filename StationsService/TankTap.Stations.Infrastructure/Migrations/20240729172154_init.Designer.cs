﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TankTap.Stations.Infrastructure.Persistence;

#nullable disable

namespace TankTap.Stations.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240729172154_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("TankTap")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TankTap.Stations.Domain.CityAggregate.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Cities", "TankTap");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.PointOfSaleTypeAggregate.PointOfSaleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("PointOfSaleTypes", "TankTap");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ERPCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Products", "TankTap");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.RegionAggregate.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Regions", "TankTap");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.Pump", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ERPCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StationId")
                        .HasColumnType("int");

                    b.Property<int>("TankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.HasIndex("TankId");

                    b.ToTable("Pumps", "TankTap");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ERPCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stations", "TankTap");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.StationProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Price")
                        .HasPrecision(5)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StationId");

                    b.ToTable("StationProducts", "TankTap");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.Tank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Capacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StationId");

                    b.ToTable("Tanks", "TankTap");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.CityAggregate.City", b =>
                {
                    b.HasOne("TankTap.Stations.Domain.RegionAggregate.Region", null)
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TankTap.Stations.Domain.LocalizedName", "Name", b1 =>
                        {
                            b1.Property<int>("CityId")
                                .HasColumnType("int");

                            b1.Property<string>("ArName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ArName");

                            b1.Property<string>("BnName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BnName");

                            b1.Property<string>("EnName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EnName");

                            b1.Property<string>("UrName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UrName");

                            b1.HasKey("CityId");

                            b1.ToTable("Cities", "TankTap");

                            b1.WithOwner()
                                .HasForeignKey("CityId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("TankTap.Stations.Domain.PointOfSaleTypeAggregate.PointOfSaleType", b =>
                {
                    b.OwnsOne("TankTap.Stations.Domain.LocalizedName", "Name", b1 =>
                        {
                            b1.Property<int>("PointOfSaleTypeId")
                                .HasColumnType("int");

                            b1.Property<string>("ArName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ArName");

                            b1.Property<string>("BnName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BnName");

                            b1.Property<string>("EnName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EnName");

                            b1.Property<string>("UrName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UrName");

                            b1.HasKey("PointOfSaleTypeId");

                            b1.ToTable("PointOfSaleTypes", "TankTap");

                            b1.WithOwner()
                                .HasForeignKey("PointOfSaleTypeId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("TankTap.Stations.Domain.ProductAggregate.Product", b =>
                {
                    b.HasOne("TankTap.Stations.Domain.StationAggregate.Station", null)
                        .WithMany("Products")
                        .HasForeignKey("StationId");

                    b.OwnsOne("TankTap.Stations.Domain.LocalizedName", "Name", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<string>("ArName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ArName");

                            b1.Property<string>("BnName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BnName");

                            b1.Property<string>("EnName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EnName");

                            b1.Property<string>("UrName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UrName");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products", "TankTap");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("TankTap.Stations.Domain.RegionAggregate.Region", b =>
                {
                    b.OwnsOne("TankTap.Stations.Domain.LocalizedName", "Name", b1 =>
                        {
                            b1.Property<int>("RegionId")
                                .HasColumnType("int");

                            b1.Property<string>("ArName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ArName");

                            b1.Property<string>("BnName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BnName");

                            b1.Property<string>("EnName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EnName");

                            b1.Property<string>("UrName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UrName");

                            b1.HasKey("RegionId");

                            b1.ToTable("Regions", "TankTap");

                            b1.WithOwner()
                                .HasForeignKey("RegionId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.Pump", b =>
                {
                    b.HasOne("TankTap.Stations.Domain.StationAggregate.Station", null)
                        .WithMany("Pumps")
                        .HasForeignKey("StationId");

                    b.HasOne("TankTap.Stations.Domain.StationAggregate.Tank", null)
                        .WithMany("Pumps")
                        .HasForeignKey("TankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.Station", b =>
                {
                    b.OwnsOne("TankTap.Stations.Domain.Distination", "Distination", b1 =>
                        {
                            b1.Property<int>("StationId")
                                .HasColumnType("int");

                            b1.Property<string>("Latitude")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Latitude");

                            b1.Property<string>("Longitude")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Longitude");

                            b1.HasKey("StationId");

                            b1.ToTable("Stations", "TankTap");

                            b1.WithOwner()
                                .HasForeignKey("StationId");
                        });

                    b.OwnsMany("TankTap.Stations.Domain.StationAggregate.POSDevice", "PointOfSales", b1 =>
                        {
                            b1.Property<int>("StationId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("AndroidId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Ip")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("PointOfSaleTypeId")
                                .HasColumnType("int");

                            b1.HasKey("StationId", "Id");

                            b1.HasIndex("PointOfSaleTypeId");

                            b1.ToTable("StationPointOfSales", "TankTap");

                            b1.HasOne("TankTap.Stations.Domain.PointOfSaleTypeAggregate.PointOfSaleType", "Type")
                                .WithMany()
                                .HasForeignKey("PointOfSaleTypeId")
                                .OnDelete(DeleteBehavior.NoAction)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("StationId");

                            b1.Navigation("Type");
                        });

                    b.OwnsOne("TankTap.Stations.Domain.StationAggregate.StationAddress", "Address", b1 =>
                        {
                            b1.Property<int>("StationId")
                                .HasColumnType("int");

                            b1.Property<int>("CityId")
                                .HasColumnType("int");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("StationId");

                            b1.HasIndex("CityId");

                            b1.ToTable("Stations", "TankTap");

                            b1.HasOne("TankTap.Stations.Domain.CityAggregate.City", "City")
                                .WithMany()
                                .HasForeignKey("CityId")
                                .OnDelete(DeleteBehavior.NoAction)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("StationId");

                            b1.Navigation("City");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Distination")
                        .IsRequired();

                    b.Navigation("PointOfSales");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.StationProduct", b =>
                {
                    b.HasOne("TankTap.Stations.Domain.ProductAggregate.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TankTap.Stations.Domain.StationAggregate.Station", null)
                        .WithMany("StationProducts")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.Tank", b =>
                {
                    b.HasOne("TankTap.Stations.Domain.ProductAggregate.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TankTap.Stations.Domain.StationAggregate.Station", null)
                        .WithMany("Tanks")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.RegionAggregate.Region", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.Station", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Pumps");

                    b.Navigation("StationProducts");

                    b.Navigation("Tanks");
                });

            modelBuilder.Entity("TankTap.Stations.Domain.StationAggregate.Tank", b =>
                {
                    b.Navigation("Pumps");
                });
#pragma warning restore 612, 618
        }
    }
}
