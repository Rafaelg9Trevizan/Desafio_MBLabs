﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using g9events.Api.Brokers;

namespace backend.Migrations
{
    [DbContext(typeof(DataBroker))]
    [Migration("20210329222849_Events")]
    partial class Events
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("g9events.Models.Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("categories")
                        .HasColumnType("integer");

                    b.Property<string>("cellphone")
                        .HasColumnType("text");

                    b.Property<string>("cpf")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("g9events.Models.CreditCard", b =>
                {
                    b.Property<int>("card_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("card_number")
                        .HasColumnType("text");

                    b.Property<DateTime>("card_validity")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("cvv")
                        .HasColumnType("text");

                    b.Property<string>("owner_cpf")
                        .HasColumnType("text");

                    b.Property<string>("owner_name")
                        .HasColumnType("text");

                    b.HasKey("card_id");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("g9events.Models.Event", b =>
                {
                    b.Property<int>("id_event")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("categories")
                        .HasColumnType("integer");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<DateTime>("event_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("event_name")
                        .HasColumnType("text");

                    b.Property<int>("institution_id")
                        .HasColumnType("integer");

                    b.Property<string>("local")
                        .HasColumnType("text");

                    b.HasKey("id_event");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("g9events.Models.Institution", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("cnpj")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("tipo")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Institutions");
                });
#pragma warning restore 612, 618
        }
    }
}