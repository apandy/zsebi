﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Zsebi2.Data;

namespace Zsebi2.Migrations
{
    [DbContext(typeof(SiteContext))]
    [Migration("20180225161638_DbUpdate001")]
    partial class DbUpdate001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Zsebi2.Models.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Excerpt");

                    b.Property<string>("HtmlBody");

                    b.Property<string>("MoreInfoUrl");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("ThumbnailFileName")
                        .HasColumnName("ThumbnailfileName");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("articles");
                });

            modelBuilder.Entity("Zsebi2.Models.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("CallSign")
                        .HasColumnName("callsign");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<string>("Image")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Post")
                        .HasColumnName("post");

                    b.Property<string>("Status")
                        .HasColumnName("status");

                    b.Property<string>("SubSystem")
                        .HasColumnName("subsystem");

                    b.Property<string>("System")
                        .HasColumnName("system");

                    b.HasKey("Id");

                    b.ToTable("team");
                });
#pragma warning restore 612, 618
        }
    }
}
