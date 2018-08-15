using System;
using CPMS.Common.Entities;
using CPMS.Common.Utils;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Common.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Intervention> Interventions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "Regione X" },
                new Group { Id = 2, Name = "Compagnia XX" },
                new Group { Id = 3, Name = "Sezione aiuto alla condotta 1", ParentId = 2 },
                new Group { Id = 4, Name = "Gruppo 1", ParentId = 3 },
                new Group { Id = 5, Name = "Gruppo 2", ParentId = 3 },
                new Group { Id = 6, Name = "Sezione aiuto alla condotta 2", ParentId = 2 },
                new Group { Id = 7, Name = "Gruppo 1", ParentId = 6 },
                new Group { Id = 8, Name = "Gruppo 2", ParentId = 6 },
                new Group { Id = 9, Name = "Ospiti" });


            PasswordUtils.CreatePasswordHash("admin", out var passwordHash, out var passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    GroupId = 9
                },
                new User
                {
                    Id = 2,
                    Username = "ComandanteDiCompagnia-1",
                    FirstName = "Nome comandante di compagnia",
                    LastName = "",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    GroupId = 2
                }, new User
                {
                    Id = 3,
                    Username = "CapoSezione-1",
                    FirstName = "Nome capo sezione",
                    LastName = "",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    GroupId = 3
                }, new User
                {
                    Id = 4,
                    Username = "CapoGruppo-1",
                    FirstName = "Nome capo gruoppo",
                    LastName = "",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    GroupId = 4
                }, new User
                {
                    Id = 5,
                    Username = "Milite-1",
                    FirstName = "Nome milite 1",
                    LastName = "",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    GroupId = 4
                }, new User
                {
                    Id = 6,
                    Username = "Milite-2",
                    FirstName = "Nome milite 2",
                    LastName = "",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    GroupId = 4
                });


            modelBuilder.Entity<JournalEntryChannel>().HasData(new JournalEntryChannel
                {
                    Id = 1,
                    Name = "Phone",
                    Icon = "fa-phone"
                },
                new JournalEntryChannel
                {
                    Id = 2,
                    Name = "Mobile",
                    Icon = "fa-mobile"
                },
                new JournalEntryChannel
                {
                    Id = 3,
                    Name = "E-mail",
                    Icon = "fa-envelope "
                });

            modelBuilder.Entity<Intervention>().HasData(new Intervention { Id = 1, Name = "Intervento demo" });

            modelBuilder.Entity<Journal>().HasData(new Journal
            {
                Id = 1,
                Name = "PC fronte",
                InterventionId = 1
            }, new Journal
            {
                Id = 2,
                Name = "PC retro",
                InterventionId = 1
            });

            modelBuilder.Entity<JournalEntry>().HasData(new JournalEntry
                {
                    Id = 1,
                    JournalEntryChannelId = 2,
                    Text = "Inizio esercizio",
                    DateTime = new DateTime(2018, 2, 2, 8, 30, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 2,
                    JournalEntryChannelId = 1,
                    Text = "Messaggio PC fronte 1",
                    DateTime = new DateTime(2018, 2, 2, 8, 36, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 3,
                    JournalEntryChannelId = 1,
                    Text = "Messaggio PC fronte 2",
                    DateTime = new DateTime(2018, 2, 2, 8, 42, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 4,
                    JournalEntryChannelId = 3,
                    Text = "Messaggio PC fronte 3",
                    DateTime = new DateTime(2018, 2, 2, 8, 45, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 5,
                    JournalEntryChannelId = 2,
                    Text = "Inizio esercizio",
                    DateTime = new DateTime(2018, 2, 2, 8, 25, 0),
                    JournalId = 2
                },
                new JournalEntry
                {
                    Id = 6,
                    JournalEntryChannelId = 2,
                    Text = "Messaggio PC retro 1",
                    DateTime = new DateTime(2018, 2, 2, 8, 38, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 7,
                    JournalEntryChannelId = 1,
                    Text = "Messaggio PC retro 2",
                    DateTime = new DateTime(2018, 2, 2, 8, 40, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 8,
                    JournalEntryChannelId = 1,
                    Text = "Messaggio PC retro 3",
                    DateTime = new DateTime(2018, 2, 2, 8, 40, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 9,
                    JournalEntryChannelId = 2,
                    Text = "Messaggio PC retro 4",
                    DateTime = new DateTime(2018, 2, 2, 8, 47, 0),
                    JournalId = 1
                });
        }
    }
}
