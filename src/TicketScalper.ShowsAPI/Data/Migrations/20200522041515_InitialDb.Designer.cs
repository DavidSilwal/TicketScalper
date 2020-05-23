﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketScalper.ShowsAPI.Data;

namespace TicketScalper.ShowsAPI.Migrations
{
    [DbContext(typeof(ShowContext))]
    [Migration("20200522041515_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketScalper.ShowsAPI.Data.Entities.Act", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Acts");
                });

            modelBuilder.Entity("TicketScalper.ShowsAPI.Data.Entities.ActShow", b =>
                {
                    b.Property<int>("ActId")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("ActId", "ShowId");

                    b.HasIndex("ShowId");

                    b.ToTable("ActShow");
                });

            modelBuilder.Entity("TicketScalper.ShowsAPI.Data.Entities.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsGeneralAdmission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("TicketScalper.ShowsAPI.Data.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Seat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketScalper.ShowsAPI.Data.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("TicketScalper.ShowsAPI.Data.Entities.ActShow", b =>
                {
                    b.HasOne("TicketScalper.ShowsAPI.Data.Entities.Act", "Act")
                        .WithMany("ActShows")
                        .HasForeignKey("ActId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketScalper.ShowsAPI.Data.Entities.Show", "Show")
                        .WithMany("ActShows")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketScalper.ShowsAPI.Data.Entities.Show", b =>
                {
                    b.HasOne("TicketScalper.ShowsAPI.Data.Entities.Venue", "Venue")
                        .WithMany("Shows")
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("TicketScalper.ShowsAPI.Data.Entities.Ticket", b =>
                {
                    b.HasOne("TicketScalper.ShowsAPI.Data.Entities.Show", "Show")
                        .WithMany("Tickets")
                        .HasForeignKey("ShowId");
                });

            modelBuilder.Entity("TicketScalper.ShowsAPI.Data.Entities.Venue", b =>
                {
                    b.OwnsOne("TicketScalper.ShowsAPI.Data.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("VenueId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address1")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Address2")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Address3")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("CityTown")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("StateProvince")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("VenueId");

                            b1.ToTable("Venues");

                            b1.WithOwner()
                                .HasForeignKey("VenueId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}