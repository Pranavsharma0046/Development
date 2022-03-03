﻿// <auto-generated />
using System;
using ManageAmericaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManageAmericaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManageAmericaAPI.Models.AvailablityModel", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("DeletedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DeletedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOccurence")
                        .HasColumnType("bit");

                    b.Property<long>("ModifiedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeTo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Availablities");
                });

            modelBuilder.Entity("ManageAmericaAPI.Models.OccurenceModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<long>("DeletedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DeletedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("ModifiedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedDatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Occurences");
                });

            modelBuilder.Entity("ManageAmericaAPI.Models.PropertyModel", b =>
                {
                    b.Property<long>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<long>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DeletedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PropertyId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("ManageAmericaAPI.Models.ScheduledMeetingModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CancelledBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CancelledDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<string>("ManagerCancelRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerMeetingNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MeetingDuration")
                        .HasColumnType("datetime2");

                    b.Property<long>("PropertyId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProspectCancelRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProspectEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProspectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProspectPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProspectRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RescheduledMeetingBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RescheduledMeetingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("ScheduledMeetings");
                });

            modelBuilder.Entity("ManageAmericaAPI.Models.WeekDayModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("ModifiedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("weekdays");
                });

            modelBuilder.Entity("ManageAmericaAPI.Models.AvailablityModel", b =>
                {
                    b.HasOne("ManageAmericaAPI.Models.OccurenceModel", "Occurences")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManageAmericaAPI.Models.ScheduledMeetingModel", b =>
                {
                    b.HasOne("ManageAmericaAPI.Models.PropertyModel", "Properties")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}