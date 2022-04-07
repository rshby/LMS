﻿// <auto-generated />
using System;
using LMS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LMS.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LMS.Models.Account", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpiredToken")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<int>("OTP")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role_Id")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.HasIndex("Role_Id");

                    b.ToTable("tb_tr_account");
                });

            modelBuilder.Entity("LMS.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subdistrict_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Subdistrict_Id");

                    b.ToTable("tb_tr_address");
                });

            modelBuilder.Entity("LMS.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_category");
                });

            modelBuilder.Entity("LMS.Models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TakenClass_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TakenClass_Id")
                        .IsUnique();

                    b.ToTable("tb_tr_certificate");
                });

            modelBuilder.Entity("LMS.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Province_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Province_Id");

                    b.ToTable("tb_m_city");
                });

            modelBuilder.Entity("LMS.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("TotalChapter")
                        .HasColumnType("int");

                    b.Property<string>("UrlPic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.HasIndex("Level_Id");

                    b.ToTable("tb_m_class");
                });

            modelBuilder.Entity("LMS.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("City_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("City_Id");

                    b.ToTable("tb_m_district");
                });

            modelBuilder.Entity("LMS.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("University_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("University_Id");

                    b.ToTable("tb_tr_education");
                });

            modelBuilder.Entity("LMS.Models.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TakenClass_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TakenClass_Id")
                        .IsUnique();

                    b.ToTable("tb_tr_feedback");
                });

            modelBuilder.Entity("LMS.Models.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_level");
                });

            modelBuilder.Entity("LMS.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_province");
                });

            modelBuilder.Entity("LMS.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_role");
                });

            modelBuilder.Entity("LMS.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Chapter")
                        .HasColumnType("int");

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Class_Id");

                    b.ToTable("tb_m_section");
                });

            modelBuilder.Entity("LMS.Models.SubDistrict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("District_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("District_Id");

                    b.ToTable("tb_m_subdistrict");
                });

            modelBuilder.Entity("LMS.Models.TakenClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Expired")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgressChapter")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Class_Id");

                    b.HasIndex("Email");

                    b.ToTable("tb_tr_takenclass");
                });

            modelBuilder.Entity("LMS.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_university");
                });

            modelBuilder.Entity("LMS.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Address_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Education_Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.HasIndex("Address_Id")
                        .IsUnique();

                    b.HasIndex("Education_Id")
                        .IsUnique();

                    b.ToTable("tb_m_user");
                });

            modelBuilder.Entity("LMS.Models.Account", b =>
                {
                    b.HasOne("LMS.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("LMS.Models.Account", "Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LMS.Models.Address", b =>
                {
                    b.HasOne("LMS.Models.SubDistrict", "SubDistrict")
                        .WithMany("Addresses")
                        .HasForeignKey("Subdistrict_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubDistrict");
                });

            modelBuilder.Entity("LMS.Models.Certificate", b =>
                {
                    b.HasOne("LMS.Models.TakenClass", "TakenClass")
                        .WithOne("Certificate")
                        .HasForeignKey("LMS.Models.Certificate", "TakenClass_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TakenClass");
                });

            modelBuilder.Entity("LMS.Models.City", b =>
                {
                    b.HasOne("LMS.Models.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("Province_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("LMS.Models.Class", b =>
                {
                    b.HasOne("LMS.Models.Category", "Category")
                        .WithMany("Classes")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS.Models.Level", "Level")
                        .WithMany("Classes")
                        .HasForeignKey("Level_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("LMS.Models.District", b =>
                {
                    b.HasOne("LMS.Models.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("City_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LMS.Models.Education", b =>
                {
                    b.HasOne("LMS.Models.University", "University")
                        .WithMany("Educations")
                        .HasForeignKey("University_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("LMS.Models.FeedBack", b =>
                {
                    b.HasOne("LMS.Models.TakenClass", "TakenClass")
                        .WithOne("FeedBack")
                        .HasForeignKey("LMS.Models.FeedBack", "TakenClass_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TakenClass");
                });

            modelBuilder.Entity("LMS.Models.Section", b =>
                {
                    b.HasOne("LMS.Models.Class", "Class")
                        .WithMany("Sections")
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("LMS.Models.SubDistrict", b =>
                {
                    b.HasOne("LMS.Models.District", "District")
                        .WithMany("SubDistricts")
                        .HasForeignKey("District_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("LMS.Models.TakenClass", b =>
                {
                    b.HasOne("LMS.Models.Class", "Class")
                        .WithMany("TakenClasses")
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS.Models.User", "User")
                        .WithMany("TakenClasses")
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LMS.Models.User", b =>
                {
                    b.HasOne("LMS.Models.Address", "Address")
                        .WithOne("User")
                        .HasForeignKey("LMS.Models.User", "Address_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS.Models.Education", "Education")
                        .WithOne("User")
                        .HasForeignKey("LMS.Models.User", "Education_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Education");
                });

            modelBuilder.Entity("LMS.Models.Address", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("LMS.Models.Category", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("LMS.Models.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("LMS.Models.Class", b =>
                {
                    b.Navigation("Sections");

                    b.Navigation("TakenClasses");
                });

            modelBuilder.Entity("LMS.Models.District", b =>
                {
                    b.Navigation("SubDistricts");
                });

            modelBuilder.Entity("LMS.Models.Education", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("LMS.Models.Level", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("LMS.Models.Province", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("LMS.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("LMS.Models.SubDistrict", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("LMS.Models.TakenClass", b =>
                {
                    b.Navigation("Certificate");

                    b.Navigation("FeedBack");
                });

            modelBuilder.Entity("LMS.Models.University", b =>
                {
                    b.Navigation("Educations");
                });

            modelBuilder.Entity("LMS.Models.User", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("TakenClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
