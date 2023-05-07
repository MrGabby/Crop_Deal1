﻿// <auto-generated />
using System;
using Crop_Deal1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crop_Deal1.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Crop_Deal1.Models.Bank_detail", b =>
                {
                    b.Property<int>("Bank_detailid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Bank_detailid"));

                    b.Property<string>("Account_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IFSC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Bank_detailid");

                    b.HasIndex("Userid");

                    b.ToTable("Bank_details");
                });

            modelBuilder.Entity("Crop_Deal1.Models.Crop", b =>
                {
                    b.Property<int>("Cropid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cropid"));

                    b.Property<int>("Crop_detailid")
                        .HasColumnType("int");

                    b.Property<string>("Crop_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crop_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Cropid");

                    b.HasIndex("Crop_detailid");

                    b.HasIndex("Userid");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("Crop_Deal1.Models.Crop_detail", b =>
                {
                    b.Property<int>("Crop_detailid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Crop_detailid"));

                    b.Property<string>("CropDetail_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crop_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crop_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Crop_detailid");

                    b.ToTable("Crop_details");
                });

            modelBuilder.Entity("Crop_Deal1.Models.Invoice", b =>
                {
                    b.Property<int>("Invoiceid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Invoiceid"));

                    b.Property<int>("Crop_detailid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_Mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Invoiceid");

                    b.HasIndex("Crop_detailid");

                    b.HasIndex("Userid");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Crop_Deal1.Models.User", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Userid"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_subscribe")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Userid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Crop_Deal1.Models.Bank_detail", b =>
                {
                    b.HasOne("Crop_Deal1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Crop_Deal1.Models.Crop", b =>
                {
                    b.HasOne("Crop_Deal1.Models.Crop_detail", "Crop_Detail")
                        .WithMany()
                        .HasForeignKey("Crop_detailid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crop_Deal1.Models.User", "User")
                        .WithMany("Crops")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crop_Detail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Crop_Deal1.Models.Invoice", b =>
                {
                    b.HasOne("Crop_Deal1.Models.Crop_detail", "Crop_Detail")
                        .WithMany()
                        .HasForeignKey("Crop_detailid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crop_Deal1.Models.User", "User")
                        .WithMany("Invoices")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crop_Detail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Crop_Deal1.Models.User", b =>
                {
                    b.Navigation("Crops");

                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
