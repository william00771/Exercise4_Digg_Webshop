﻿// <auto-generated />
using System;
using Exercise4_Digg_Webshop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exercise4DiggWebshop.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230204012627_ManyAddedandSections")]
    partial class ManyAddedandSections
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.BlogArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Style")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogArticles");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Style")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.ImageModule_Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("SectionImageModuleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("SectionImageModuleId");

                    b.ToTable("ImageModules_Images");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PromotionPrice")
                        .HasColumnType("float");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlogArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionImageModuleId")
                        .HasColumnType("int");

                    b.Property<int>("Style")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogArticleId");

                    b.HasIndex("SectionImageModuleId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.SectionImageModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Style")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SectionImageModules");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.ImageModule_Image", b =>
                {
                    b.HasOne("Exercise4_Digg_Webshop.Models.Image", "Image")
                        .WithMany("ImageModules_Images")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exercise4_Digg_Webshop.Models.SectionImageModule", "SectionImageModule")
                        .WithMany("ImageModules_Images")
                        .HasForeignKey("SectionImageModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("SectionImageModule");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.Section", b =>
                {
                    b.HasOne("Exercise4_Digg_Webshop.Models.BlogArticle", "BlogArticle")
                        .WithMany("Sections")
                        .HasForeignKey("BlogArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exercise4_Digg_Webshop.Models.SectionImageModule", "SectionImageModule")
                        .WithMany()
                        .HasForeignKey("SectionImageModuleId");

                    b.Navigation("BlogArticle");

                    b.Navigation("SectionImageModule");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.BlogArticle", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.Image", b =>
                {
                    b.Navigation("ImageModules_Images");
                });

            modelBuilder.Entity("Exercise4_Digg_Webshop.Models.SectionImageModule", b =>
                {
                    b.Navigation("ImageModules_Images");
                });
#pragma warning restore 612, 618
        }
    }
}
