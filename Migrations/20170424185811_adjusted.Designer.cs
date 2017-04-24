using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bright_Ideas.Models;

namespace Bright_Ideas.Migrations
{
    [DbContext(typeof(Bright_IdeasPlannerContext))]
    [Migration("20170424185811_adjusted")]
    partial class adjusted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Bright_Ideas.Models.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PostId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("created_at");

                    b.HasKey("LikeId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("Bright_Ideas.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Idea");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("created_at");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Bright_Ideas.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<DateTime>("created_at");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Bright_Ideas.Models.Like", b =>
                {
                    b.HasOne("Bright_Ideas.Models.Post", "Post")
                        .WithMany("LikeList")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bright_Ideas.Models.User", "User")
                        .WithMany("LikeList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bright_Ideas.Models.Post", b =>
                {
                    b.HasOne("Bright_Ideas.Models.User", "User")
                        .WithMany("ListPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
