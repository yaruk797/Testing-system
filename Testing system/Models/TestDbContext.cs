using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing_system.Models.Entities;

namespace Testing_system.Models
{
    public class TestDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User(){Id = 1, FirstName = "Yaroslav", LastName = "Martinyuk", Email = "user@gmail.com", Password = "1234"}
                });

            modelBuilder.Entity<Test>().HasData(
                new Test[]
                {
                    new Test()
                    {
                        Id = 1,
                        Name = "HTML",
                        Description = "Тест на знание основ HTML. От Вас потребуется знание основных HTML-тегов, а также грамотное их использование."
                    }
                });

            modelBuilder.Entity<Question>().HasData(
                new Question()
                {
                    Id = 1,
                    Name = "Как расшифровывается HTML?",
                    TestId = 1
                });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 1,
                        Name = "HyperThread Mask Language",
                        IsRight = false,
                        QuestionId = 1
                    },
                    new Answer()
                    {
                        Id = 2,
                        Name = "HyperThread Markup Language",
                        IsRight = false,
                        QuestionId = 1
                    },
                    new Answer()
                    {
                        Id = 3,
                        Name = "HyperText Mask Language",
                        IsRight = false,
                        QuestionId = 1
                    },
                    new Answer()
                    {
                        Id = 4,
                        Name = "HyperText Markup Language",
                        IsRight = true,
                        QuestionId = 1
                    }
                });

            modelBuilder.Entity<Question>().HasData(
                new Question()
                {
                    Id = 2,
                    Name = "Какое расширение должны иметь HTML документы?",
                    TestId = 1
                });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 5,
                        Name = ".php или .asp",
                        IsRight = false,
                        QuestionId = 2
                    },
                    new Answer()
                    {
                        Id = 6,
                        Name = ".txt или .doc",
                        IsRight = false,
                        QuestionId = 2
                    },
                    new Answer()
                    {
                        Id = 7,
                        Name = ".doc",
                        IsRight = false,
                        QuestionId = 2
                    },
                    new Answer()
                    {
                        Id = 8,
                        Name = ".html или .htm",
                        IsRight = true,
                        QuestionId = 2
                    }
                });

            modelBuilder.Entity<Question>().HasData(
                new Question()
                {
                    Id = 3,
                    Name = "Какой тег позволяет вставлять картинки в HTML документы?",
                    TestId = 1
                });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 9,
                        Name = "<pic>",
                        IsRight = false,
                        QuestionId = 3
                    },
                    new Answer()
                    {
                        Id = 10,
                        Name = "<img>",
                        IsRight = true,
                        QuestionId = 3
                    },
                    new Answer()
                    {
                        Id = 11,
                        Name = "<picture>",
                        IsRight = false,
                        QuestionId = 3
                    },
                    new Answer()
                    {
                        Id = 12,
                        Name = "<image>",
                        IsRight = false,
                        QuestionId = 3
                    }
                });

        }
    }
}
