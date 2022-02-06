﻿// <auto-generated />
using System;
using AgenciaCronosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgenciaCronosAPI.Migrations
{
    [DbContext(typeof(AgenciaCronosAPIContext))]
    partial class AgenciaCronosAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AgenciaCronosAPI.Models.IntegrantesEquipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int?>("ServicosId")
                        .HasColumnType("int")
                        .HasColumnName("ServicosId");

                    b.Property<string>("TituloEquipe")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TituloEquipe");

                    b.HasKey("Id");

                    b.ToTable("IntegrantesEquipe");
                });

            modelBuilder.Entity("AgenciaCronosAPI.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("CriadorId")
                        .HasColumnType("int")
                        .HasColumnName("CriadorId");

                    b.Property<DateTime?>("DataPublicacao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataPublicacao");

                    b.Property<string>("Publicacao")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("Publicacao");

                    b.Property<string>("TituloPost")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TituloPost");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("AgenciaCronosAPI.Models.Servicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("DataFimServico")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataFimServico");

                    b.Property<DateTime?>("DataInicioServico")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataInicioServico");

                    b.Property<string>("Descricao")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Descricao");

                    b.Property<string>("TituloServico")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TituloServico");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("AgenciaCronosAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Contato")
                        .HasColumnType("longtext")
                        .HasColumnName("Contato");

                    b.Property<int?>("EquipeId")
                        .HasColumnType("int")
                        .HasColumnName("EquipeId");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext")
                        .HasColumnName("Nome");

                    b.Property<string>("Papel")
                        .HasColumnType("longtext")
                        .HasColumnName("Papel");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
