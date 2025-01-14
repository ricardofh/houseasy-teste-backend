﻿// <auto-generated />
using HouseasyApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HouseasyApi.Migrations
{
    [DbContext(typeof(HouseasyContext))]
    [Migration("20230501190852_ChangeColummComplementOnTableAddress")]
    partial class ChangeColummComplementOnTableAddress
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HouseasyApi.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complement")
                        .HasColumnType("longtext");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("HouseasyApi.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("HouseasyApi.Models.Ocupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Ocupation");
                });

            modelBuilder.Entity("HouseasyApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdAdress")
                        .HasColumnType("int");

                    b.Property<int>("IdContact")
                        .HasColumnType("int");

                    b.Property<int>("IdOccupation")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdAdress");

                    b.HasIndex("IdContact");

                    b.HasIndex("IdOccupation");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HouseasyApi.Models.User", b =>
                {
                    b.HasOne("HouseasyApi.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("IdAdress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseasyApi.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("IdContact")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseasyApi.Models.Ocupation", "Ocupation")
                        .WithMany()
                        .HasForeignKey("IdOccupation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Contact");

                    b.Navigation("Ocupation");
                });
#pragma warning restore 612, 618
        }
    }
}
