﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using URL_Shortener.Data;

namespace URL_Shortener.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210918160100_AddURLTableToDB")]
    partial class AddURLTableToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("URL_Shortener.Models.URLs", b =>
                {
                    b.Property<string>("sourceUrl")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("shortUrl")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("sourceUrl");

                    b.ToTable("URLs");
                });
#pragma warning restore 612, 618
        }
    }
}