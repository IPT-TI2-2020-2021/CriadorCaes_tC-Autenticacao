﻿// <auto-generated />
using System;
using CriadorCaes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CriadorCaes.Data.Migrations
{
    [DbContext(typeof(CriadorCaesBD))]
    [Migration("20210521203219_MigracaoDados")]
    partial class MigracaoDados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CriadorCaes.Models.Caes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("LOP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RacaFK")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VeterinariosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RacaFK");

                    b.HasIndex("VeterinariosId");

                    b.ToTable("Caes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNasc = new DateTime(2019, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446793",
                            Nome = "Aguia da Quinta do Conde",
                            RacaFK = 1,
                            Sexo = "F"
                        },
                        new
                        {
                            Id = 2,
                            DataNasc = new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446795",
                            Nome = "Aileen da Quinta do Lordy",
                            RacaFK = 1,
                            Sexo = "F"
                        },
                        new
                        {
                            Id = 3,
                            DataNasc = new DateTime(2011, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446801",
                            Nome = "Aladim do Canto do Bairro Pimenta",
                            RacaFK = 5,
                            Sexo = "F"
                        },
                        new
                        {
                            Id = 4,
                            DataNasc = new DateTime(2008, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446804",
                            Nome = "Albert do Canto do Bairro Pimenta",
                            RacaFK = 5,
                            Sexo = "F"
                        },
                        new
                        {
                            Id = 5,
                            DataNasc = new DateTime(2012, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446807",
                            Nome = "Alabaster da Casa do Sobreiral",
                            RacaFK = 2,
                            Sexo = "F"
                        },
                        new
                        {
                            Id = 6,
                            DataNasc = new DateTime(2010, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446809",
                            Nome = "Gannett do Quintal de Cima",
                            RacaFK = 6,
                            Sexo = "F"
                        },
                        new
                        {
                            Id = 7,
                            DataNasc = new DateTime(2010, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446811",
                            Nome = "Gardenia da Tapada de Cima",
                            RacaFK = 3,
                            Sexo = "F"
                        },
                        new
                        {
                            Id = 8,
                            DataNasc = new DateTime(2013, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446799",
                            Nome = "Forte da Flecha do Indio",
                            RacaFK = 7,
                            Sexo = "F"
                        },
                        new
                        {
                            Id = 9,
                            DataNasc = new DateTime(2011, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446812",
                            Nome = "Garbo da Flecha do Indio",
                            RacaFK = 7,
                            Sexo = "M"
                        },
                        new
                        {
                            Id = 10,
                            DataNasc = new DateTime(2017, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446814",
                            Nome = "Garfunkle da Quinta do Lordy",
                            RacaFK = 4,
                            Sexo = "F"
                        },
                        new
                        {
                            Id = 11,
                            DataNasc = new DateTime(2018, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LOP = "LOP446816",
                            Nome = "Garnet do Quintal de Cima",
                            RacaFK = 8,
                            Sexo = "M"
                        });
                });

            modelBuilder.Entity("CriadorCaes.Models.Criadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("NomeComercial")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telemovel")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Criadores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodPostal = "2305 - 515 PAIALVO",
                            Email = "Marisa.Freitas@iol.pt",
                            Morada = "Largo do Pelourinho",
                            Nome = "Marisa Vieira",
                            NomeComercial = "da Quinta do Conde",
                            Telemovel = "967197885"
                        },
                        new
                        {
                            Id = 2,
                            CodPostal = "2300 - 551 TOMAR",
                            Email = "Fátima.Machado@gmail.com",
                            Morada = "Praça Infante Dom Henrique",
                            Nome = "Fátima Ribeiro",
                            NomeComercial = "da Quinta do Lordy",
                            Telemovel = "963737476"
                        },
                        new
                        {
                            Id = 4,
                            CodPostal = "2300 - 324 TOMAR",
                            Email = "Paula.Lopes@iol.pt",
                            Morada = "Bairro Pimenta",
                            Nome = "Paula Silva",
                            NomeComercial = "do Canto do Pimenta",
                            Telemovel = "967517256"
                        },
                        new
                        {
                            Id = 5,
                            CodPostal = "2305 - 127 ASSEICEIRA TMR",
                            Email = "Mariline.Martins@sapo.pt",
                            Morada = "Zona Industrial",
                            Nome = "Mariline Marques",
                            NomeComercial = "da Casa do Sobreiral",
                            Telemovel = "967212144"
                        },
                        new
                        {
                            Id = 6,
                            CodPostal = "2475 - 013 BENEDITA",
                            Email = "Marcos.Rocha@sapo.pt",
                            Morada = "Rua de Bacelos",
                            Nome = "Marcos Rocha",
                            NomeComercial = "da Casa do Sol",
                            Telemovel = "962125638"
                        },
                        new
                        {
                            Id = 7,
                            CodPostal = "7630 - 782 ZAMBUJEIRA DO MAR",
                            Email = "Alexandre.Dias@hotmail.com",
                            Morada = "Rua João Pedro Costa",
                            Nome = "Alexandre Vieira",
                            NomeComercial = "do Quintal de Cima",
                            Telemovel = "961493756"
                        },
                        new
                        {
                            Id = 8,
                            CodPostal = "2300 - 551 TOMAR",
                            Email = "Paula.Vieira@clix.pt",
                            Morada = "Praça Infante Dom Henrique",
                            Nome = "Paula Soares",
                            NomeComercial = "da Tapada de Cima",
                            Telemovel = "961937768"
                        },
                        new
                        {
                            Id = 9,
                            CodPostal = "2300 - 390 TOMAR",
                            Email = "Mariline.Ribeiro@iol.pt",
                            Morada = "Rua Corredora do Mestre (Palhavã de Cima)",
                            Nome = "Mariline Santos",
                            NomeComercial = "da Quinta do Bacelo",
                            Telemovel = "964106478"
                        },
                        new
                        {
                            Id = 10,
                            CodPostal = "2300 - 635 TOMAR",
                            Email = "Roberto.Vieira@sapo.pt",
                            Morada = "Largo do Flecheiro",
                            Nome = "Roberto Pinto",
                            NomeComercial = "da Flecha do Indio",
                            Telemovel = "964685937"
                        });
                });

            modelBuilder.Entity("CriadorCaes.Models.CriadoresCaes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaoFK")
                        .HasColumnType("int");

                    b.Property<int>("CriadorFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CaoFK");

                    b.HasIndex("CriadorFK");

                    b.ToTable("CriadoresCaes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CaoFK = 1,
                            CriadorFK = 1,
                            DataCompra = new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CaoFK = 2,
                            CriadorFK = 2,
                            DataCompra = new DateTime(2019, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CaoFK = 3,
                            CriadorFK = 4,
                            DataCompra = new DateTime(2011, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CaoFK = 4,
                            CriadorFK = 5,
                            DataCompra = new DateTime(2008, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CaoFK = 5,
                            CriadorFK = 6,
                            DataCompra = new DateTime(2012, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CaoFK = 6,
                            CriadorFK = 7,
                            DataCompra = new DateTime(2010, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            CaoFK = 7,
                            CriadorFK = 8,
                            DataCompra = new DateTime(2011, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            CaoFK = 8,
                            CriadorFK = 9,
                            DataCompra = new DateTime(2013, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            CaoFK = 9,
                            CriadorFK = 10,
                            DataCompra = new DateTime(2011, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            CaoFK = 10,
                            CriadorFK = 5,
                            DataCompra = new DateTime(2017, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            CaoFK = 11,
                            CriadorFK = 8,
                            DataCompra = new DateTime(2018, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CriadorCaes.Models.Fotografias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaoFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFoto")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fotografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaoFK");

                    b.ToTable("Fotografias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CaoFK = 1,
                            DataFoto = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "Retriever_do_labrador.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 2,
                            CaoFK = 1,
                            DataFoto = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "Retriever_do_labrador_2.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 3,
                            CaoFK = 2,
                            DataFoto = new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "Retriever_do_labrador_3.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 4,
                            CaoFK = 3,
                            DataFoto = new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "s.bernardo.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 5,
                            CaoFK = 4,
                            DataFoto = new DateTime(2019, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "s.bernardo_2.jpg",
                            Local = "casa"
                        },
                        new
                        {
                            Id = 6,
                            CaoFK = 5,
                            DataFoto = new DateTime(2013, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "serra_da_estrela.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 7,
                            CaoFK = 5,
                            DataFoto = new DateTime(2012, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "serra_da_estrela_2.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 8,
                            CaoFK = 6,
                            DataFoto = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "Rafeiro_do_Alentejo.jpg",
                            Local = "Quinta"
                        },
                        new
                        {
                            Id = 9,
                            CaoFK = 7,
                            DataFoto = new DateTime(2011, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "pastor_alemao_2.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 10,
                            CaoFK = 7,
                            DataFoto = new DateTime(2020, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "pastor_alemao.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 11,
                            CaoFK = 8,
                            DataFoto = new DateTime(2018, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "golden-retriever_2.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 12,
                            CaoFK = 8,
                            DataFoto = new DateTime(2017, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "golden-retriever.jpg",
                            Local = "ninhada"
                        },
                        new
                        {
                            Id = 13,
                            CaoFK = 9,
                            DataFoto = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "Golden-Retriever-1.jpg",
                            Local = ""
                        },
                        new
                        {
                            Id = 14,
                            CaoFK = 10,
                            DataFoto = new DateTime(2021, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "Dogue_Alemao.jpg",
                            Local = "Casa da tia Ana"
                        },
                        new
                        {
                            Id = 15,
                            CaoFK = 11,
                            DataFoto = new DateTime(2021, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fotografia = "border_collie.jpg",
                            Local = "quintal"
                        });
                });

            modelBuilder.Entity("CriadorCaes.Models.Racas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Racas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Designacao = "Retriever do Labrador"
                        },
                        new
                        {
                            Id = 2,
                            Designacao = "Serra da Estrela"
                        },
                        new
                        {
                            Id = 3,
                            Designacao = "Pastor Alemão"
                        },
                        new
                        {
                            Id = 4,
                            Designacao = "Dogue Alemão"
                        },
                        new
                        {
                            Id = 5,
                            Designacao = "S. Bernardo"
                        },
                        new
                        {
                            Id = 6,
                            Designacao = "Rafeiro do Alentejo"
                        },
                        new
                        {
                            Id = 7,
                            Designacao = "Golden Retriever"
                        },
                        new
                        {
                            Id = 8,
                            Designacao = "Border Collie"
                        });
                });

            modelBuilder.Entity("CriadorCaes.Models.Veterinarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Honorario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veterinarios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CriadorCaes.Models.Caes", b =>
                {
                    b.HasOne("CriadorCaes.Models.Racas", "Raca")
                        .WithMany("ListaDeCaes")
                        .HasForeignKey("RacaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CriadorCaes.Models.Veterinarios", null)
                        .WithMany("ListaDeCaesTratados")
                        .HasForeignKey("VeterinariosId");

                    b.Navigation("Raca");
                });

            modelBuilder.Entity("CriadorCaes.Models.CriadoresCaes", b =>
                {
                    b.HasOne("CriadorCaes.Models.Caes", "Cao")
                        .WithMany("ListaDeCriadores")
                        .HasForeignKey("CaoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CriadorCaes.Models.Criadores", "Criador")
                        .WithMany("ListaDeCaes")
                        .HasForeignKey("CriadorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cao");

                    b.Navigation("Criador");
                });

            modelBuilder.Entity("CriadorCaes.Models.Fotografias", b =>
                {
                    b.HasOne("CriadorCaes.Models.Caes", "Cao")
                        .WithMany("ListaDeFotografias")
                        .HasForeignKey("CaoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cao");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CriadorCaes.Models.Caes", b =>
                {
                    b.Navigation("ListaDeCriadores");

                    b.Navigation("ListaDeFotografias");
                });

            modelBuilder.Entity("CriadorCaes.Models.Criadores", b =>
                {
                    b.Navigation("ListaDeCaes");
                });

            modelBuilder.Entity("CriadorCaes.Models.Racas", b =>
                {
                    b.Navigation("ListaDeCaes");
                });

            modelBuilder.Entity("CriadorCaes.Models.Veterinarios", b =>
                {
                    b.Navigation("ListaDeCaesTratados");
                });
#pragma warning restore 612, 618
        }
    }
}
