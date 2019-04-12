﻿// <auto-generated />
using System;
using Blinkblink.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Blinkblink.Migrations
{
    [DbContext(typeof(DBBlinkContext))]
    [Migration("20190408101843_aa")]
    partial class aa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Blinkblink.Models.Idol", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Idols");
                });

            modelBuilder.Entity("Blinkblink.Models.Image", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("IdolId");

                    b.Property<int>("IsVideo");

                    b.Property<string>("Name");

                    b.Property<string>("TypeIdol");

                    b.Property<string>("Url");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("IdolId");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Blinkblink.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Blinkblink.Models.Image", b =>
                {
                    b.HasOne("Blinkblink.Models.Idol", "Idol")
                        .WithMany("Images")
                        .HasForeignKey("IdolId");

                    b.HasOne("Blinkblink.Models.User", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
