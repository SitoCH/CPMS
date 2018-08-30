using System;
using System.Text;
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

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Intervention> Interventions { get; set; }

        public DbSet<Journal> Journals { get; set; }

        public DbSet<JournalEntryChannel> JournalEntryChannels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "Regione X" },
                new Group { Id = 2, Name = "Compagnia XX", ParentId = 1 },
                new Group { Id = 3, Name = "Sezione aiuto alla condotta 1", ParentId = 2 },
                new Group { Id = 4, Name = "Gruppo 1", ParentId = 3 },
                new Group { Id = 5, Name = "Gruppo 2", ParentId = 3 },
                new Group { Id = 6, Name = "Sezione aiuto alla condotta 2", ParentId = 2 },
                new Group { Id = 7, Name = "Gruppo 1", ParentId = 6 },
                new Group { Id = 8, Name = "Gruppo 2", ParentId = 6 },
                new Group { Id = 9, Name = "Ospiti" });


            var passwordHash = Convert.ToBase64String(new byte[]
            {
                26, 174, 194, 213, 79, 58, 128, 154, 224, 157, 19, 239, 200, 34, 148, 127, 67, 146, 128, 34, 7, 184, 131, 119, 214, 119, 152, 176, 12, 90,
                238, 47, 96, 156, 65, 16, 128, 188, 198, 28, 240, 40, 120, 148, 202, 92, 197, 42, 227, 74, 36, 171, 242, 207, 202, 6, 30, 196, 7, 232, 193,
                78, 197, 58
            });

            var passwordSalt = Convert.ToBase64String(new byte[]
            {
                18, 204, 70, 61, 118, 37, 255, 217, 241, 57, 4, 170, 135, 249, 103, 19, 190, 214, 139, 162, 47, 34, 180, 154, 240, 88, 170, 17, 164, 154,
                227, 8, 49, 114, 109, 85, 251, 42, 214, 112, 242, 191, 201, 24, 40, 104, 55, 217, 21, 4, 233, 69, 194, 119, 143, 231, 80, 70, 103, 145, 165,
                226, 53, 20, 204, 255, 117, 125, 86, 161, 90, 220, 0, 253, 175, 207, 111, 201, 205, 6, 111, 210, 92, 238, 38, 227, 35, 68, 126, 16, 147, 183,
                171, 19, 35, 179, 189, 75, 14, 217, 186, 120, 61, 39, 194, 4, 230, 190, 234, 37, 241, 97, 129, 215, 110, 64, 182, 148, 149, 74, 198, 96,
                134, 59, 199, 224, 93, 43
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    FirstName = "Administrator",
                    LastName = "",
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
                    FirstName = "Nome capo gruppo",
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

            modelBuilder.Entity<Intervention>().HasData(new Intervention
                {
                    Id = 1,
                    Name = "Intervento demo",
                    IsActive = true
                },
                new Intervention
                {
                    Id = 2,
                    Name = "Intervento chiuso",
                    IsActive = false
                });

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
                    Person = "SM PCi",
                    DateTime = new DateTime(2018, 2, 2, 8, 30, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 2,
                    JournalEntryChannelId = 1,
                    Text = "Messaggio PC fronte 1",
                    Person = "144",
                    DateTime = new DateTime(2018, 2, 2, 8, 36, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 3,
                    JournalEntryChannelId = 1,
                    Text = "Messaggio PC fronte 2",
                    Person = "117",
                    DateTime = new DateTime(2018, 2, 2, 8, 42, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 4,
                    JournalEntryChannelId = 3,
                    Text = "Messaggio <b>PC fronte</b> 3",
                    Person = "117",
                    DateTime = new DateTime(2018, 2, 2, 8, 45, 0),
                    JournalId = 1
                },
                new JournalEntry
                {
                    Id = 5,
                    JournalEntryChannelId = 2,
                    Text = "Inizio esercizio",
                    Person = "SM PCi",
                    DateTime = new DateTime(2018, 2, 2, 8, 25, 0),
                    JournalId = 2
                },
                new JournalEntry
                {
                    Id = 6,
                    JournalEntryChannelId = 2,
                    Text = "Messaggio PC retro 1",
                    Person = "117",
                    DateTime = new DateTime(2018, 2, 2, 8, 38, 0),
                    JournalId = 2
                },
                new JournalEntry
                {
                    Id = 7,
                    JournalEntryChannelId = 1,
                    Text = "Messaggio PC retro 2",
                    Person = "117",
                    DateTime = new DateTime(2018, 2, 2, 8, 40, 0),
                    JournalId = 2
                },
                new JournalEntry
                {
                    Id = 8,
                    JournalEntryChannelId = 1,
                    Text = "Messaggio PC retro 3",
                    Person = "144",
                    DateTime = new DateTime(2018, 2, 2, 8, 40, 0),
                    JournalId = 2
                },
                new JournalEntry
                {
                    Id = 9,
                    JournalEntryChannelId = 2,
                    Text = "Messaggio PC retro 4",
                    Person = "Care team",
                    DateTime = new DateTime(2018, 2, 2, 8, 47, 0),
                    JournalId = 2
                });
        }
    }
}
