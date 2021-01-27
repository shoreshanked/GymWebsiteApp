﻿// <auto-generated />
using System;
using GymWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymWebsite.Migrations
{
    [DbContext(typeof(GymWebsiteContext))]
    [Migration("20210127113757_Update")]
    partial class Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("GymWebsite.Model.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<int?>("WorkoutID")
                        .HasColumnType("int");

                    b.HasKey("ExerciseID");

                    b.HasIndex("WorkoutID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("GymWebsite.Model.TrainingBlock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BlockName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingBlock");
                });

            modelBuilder.Entity("GymWebsite.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GymWebsite.Model.UserProfile", b =>
                {
                    b.Property<int>("UserProfileId")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("UserProfileId");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("GymWebsite.Model.Workout", b =>
                {
                    b.Property<int>("WorkoutID")
                        .HasColumnType("int");

                    b.Property<string>("WorkoutName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkoutID");

                    b.ToTable("Workout");
                });

            modelBuilder.Entity("GymWebsite.Model.Exercise", b =>
                {
                    b.HasOne("GymWebsite.Model.Workout", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutID");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("GymWebsite.Model.TrainingBlock", b =>
                {
                    b.HasOne("GymWebsite.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GymWebsite.Model.UserProfile", b =>
                {
                    b.HasOne("GymWebsite.Model.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("GymWebsite.Model.UserProfile", "UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GymWebsite.Model.Workout", b =>
                {
                    b.HasOne("GymWebsite.Model.TrainingBlock", "TrainingBlock")
                        .WithMany()
                        .HasForeignKey("WorkoutID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingBlock");
                });

            modelBuilder.Entity("GymWebsite.Model.User", b =>
                {
                    b.Navigation("Profile");
                });

            modelBuilder.Entity("GymWebsite.Model.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
