﻿// <auto-generated />
using System;
using CPMS.Common.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPMS.Common.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180823205839_JournalEntryChannel")]
    partial class JournalEntryChannel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CPMS.Common.Entities.Configuration", b =>
                {
                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Key");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("CPMS.Common.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Groups");

                    b.HasData(
                        new { Id = 1, Name = "Regione X" },
                        new { Id = 2, Name = "Compagnia XX", ParentId = 1 },
                        new { Id = 3, Name = "Sezione aiuto alla condotta 1", ParentId = 2 },
                        new { Id = 4, Name = "Gruppo 1", ParentId = 3 },
                        new { Id = 5, Name = "Gruppo 2", ParentId = 3 },
                        new { Id = 6, Name = "Sezione aiuto alla condotta 2", ParentId = 2 },
                        new { Id = 7, Name = "Gruppo 1", ParentId = 6 },
                        new { Id = 8, Name = "Gruppo 2", ParentId = 6 },
                        new { Id = 9, Name = "Ospiti" }
                    );
                });

            modelBuilder.Entity("CPMS.Common.Entities.Intervention", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Interventions");

                    b.HasData(
                        new { Id = 1, Name = "Intervento demo" }
                    );
                });

            modelBuilder.Entity("CPMS.Common.Entities.Journal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InterventionId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("InterventionId");

                    b.ToTable("Journals");

                    b.HasData(
                        new { Id = 1, InterventionId = 1, Name = "PC fronte" },
                        new { Id = 2, InterventionId = 1, Name = "PC retro" }
                    );
                });

            modelBuilder.Entity("CPMS.Common.Entities.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("JournalEntryChannelId");

                    b.Property<int>("JournalId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("JournalEntryChannelId");

                    b.HasIndex("JournalId");

                    b.ToTable("JournalEntry");

                    b.HasData(
                        new { Id = 1, DateTime = new DateTime(2018, 2, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), JournalEntryChannelId = 2, JournalId = 1, Text = "Inizio esercizio" },
                        new { Id = 2, DateTime = new DateTime(2018, 2, 2, 8, 36, 0, 0, DateTimeKind.Unspecified), JournalEntryChannelId = 1, JournalId = 1, Text = "Messaggio PC fronte 1" },
                        new { Id = 3, DateTime = new DateTime(2018, 2, 2, 8, 42, 0, 0, DateTimeKind.Unspecified), JournalEntryChannelId = 1, JournalId = 1, Text = "Messaggio PC fronte 2" },
                        new { Id = 4, DateTime = new DateTime(2018, 2, 2, 8, 45, 0, 0, DateTimeKind.Unspecified), JournalEntryChannelId = 3, JournalId = 1, Text = "Messaggio PC fronte 3" },
                        new { Id = 5, DateTime = new DateTime(2018, 2, 2, 8, 25, 0, 0, DateTimeKind.Unspecified), JournalEntryChannelId = 2, JournalId = 2, Text = "Inizio esercizio" },
                        new { Id = 6, DateTime = new DateTime(2018, 2, 2, 8, 38, 0, 0, DateTimeKind.Unspecified), JournalEntryChannelId = 2, JournalId = 1, Text = "Messaggio PC retro 1" },
                        new { Id = 7, DateTime = new DateTime(2018, 2, 2, 8, 40, 0, 0, DateTimeKind.Unspecified), JournalEntryChannelId = 1, JournalId = 1, Text = "Messaggio PC retro 2" },
                        new { Id = 8, DateTime = new DateTime(2018, 2, 2, 8, 40, 0, 0, DateTimeKind.Unspecified), JournalEntryChannelId = 1, JournalId = 1, Text = "Messaggio PC retro 3" },
                        new { Id = 9, DateTime = new DateTime(2018, 2, 2, 8, 47, 0, 0, DateTimeKind.Unspecified), JournalEntryChannelId = 2, JournalId = 1, Text = "Messaggio PC retro 4" }
                    );
                });

            modelBuilder.Entity("CPMS.Common.Entities.JournalEntryChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Icon");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("JournalEntryChannels");

                    b.HasData(
                        new { Id = 1, Icon = "fa-phone", Name = "Phone" },
                        new { Id = 2, Icon = "fa-mobile", Name = "Mobile" },
                        new { Id = 3, Icon = "fa-envelope ", Name = "E-mail" }
                    );
                });

            modelBuilder.Entity("CPMS.Common.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<int>("GroupId");

                    b.Property<string>("LastName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, FirstName = "Administrator", GroupId = 9, LastName = "", PasswordHash = "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", PasswordSalt = "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", Username = "admin" },
                        new { Id = 2, FirstName = "Nome comandante di compagnia", GroupId = 2, LastName = "", PasswordHash = "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", PasswordSalt = "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", Username = "ComandanteDiCompagnia-1" },
                        new { Id = 3, FirstName = "Nome capo sezione", GroupId = 3, LastName = "", PasswordHash = "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", PasswordSalt = "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", Username = "CapoSezione-1" },
                        new { Id = 4, FirstName = "Nome capo gruppo", GroupId = 4, LastName = "", PasswordHash = "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", PasswordSalt = "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", Username = "CapoGruppo-1" },
                        new { Id = 5, FirstName = "Nome milite 1", GroupId = 4, LastName = "", PasswordHash = "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", PasswordSalt = "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", Username = "Milite-1" },
                        new { Id = 6, FirstName = "Nome milite 2", GroupId = 4, LastName = "", PasswordHash = "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", PasswordSalt = "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", Username = "Milite-2" }
                    );
                });

            modelBuilder.Entity("CPMS.Common.Entities.Group", b =>
                {
                    b.HasOne("CPMS.Common.Entities.Group", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CPMS.Common.Entities.Journal", b =>
                {
                    b.HasOne("CPMS.Common.Entities.Intervention", "Intervention")
                        .WithMany()
                        .HasForeignKey("InterventionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CPMS.Common.Entities.JournalEntry", b =>
                {
                    b.HasOne("CPMS.Common.Entities.JournalEntryChannel", "JournalEntryChannel")
                        .WithMany()
                        .HasForeignKey("JournalEntryChannelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CPMS.Common.Entities.Journal", "Journal")
                        .WithMany("JournalEntries")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CPMS.Common.Entities.User", b =>
                {
                    b.HasOne("CPMS.Common.Entities.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
