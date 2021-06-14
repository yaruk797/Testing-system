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

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User(){Id = 1, FirstName = "Yaroslav", LastName = "Martinyuk", Email = "user@gmail.com", Password = "1234"}
                });

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User(){Id = 2, FirstName = "User", LastName = "User", Email = "user2@gmail.com", Password = "12345"}
                });

            //HTML test
            modelBuilder.Entity<Test>().HasData(
                new Test()
                {
                    Id = 1,
                    Name = "Основы HTML",
                    Description = "Тест на знание основ HTML. От Вас потребуется знание основных HTML-тегов, а также грамотное их использование.",
                    UserId = 1
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

            //CSS test
            modelBuilder.Entity<Test>().HasData(
                new Test()
                {
                    Id = 2,
                    Name = "Основы CSS",
                    Description = "Тест на знание основ CSS.",
                    UserId = 1
                });

            modelBuilder.Entity<Question>().HasData(
                new Question()
                {
                    Id = 4,
                    Name = "Как расшифровывается CSS?",
                    TestId = 2
                });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 13,
                        Name = "Common Style Sheets",
                        IsRight = false,
                        QuestionId = 4
                    },
                    new Answer()
                    {
                        Id = 14,
                        Name = "Computer Style Sheets",
                        IsRight = false,
                        QuestionId = 4
                    },
                    new Answer()
                    {
                        Id = 15,
                        Name = "Cascading Style Sheets",
                        IsRight = true,
                        QuestionId = 4
                    }
                });

            modelBuilder.Entity<Question>().HasData(
               new Question()
               {
                   Id = 5,
                   Name = "Укажите CSS свойство позволяющее устанавливать размер шрифта?",
                   TestId = 2
               });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 16,
                        Name = "font-weight",
                        IsRight = false,
                        QuestionId = 5
                    },
                    new Answer()
                    {
                        Id = 17,
                        Name = "font-size",
                        IsRight = true,
                        QuestionId = 5
                    },
                    new Answer()
                    {
                        Id = 18,
                        Name = "size",
                        IsRight = false,
                        QuestionId = 5
                    },
                    new Answer()
                    {
                        Id = 19,
                        Name = "weight",
                        IsRight = false,
                        QuestionId = 5
                    }
                });

            modelBuilder.Entity<Question>().HasData(
               new Question()
               {
                   Id = 6,
                   Name = "С помощью какого тэга можно подключить к HTML документу внешний файл стилей?",
                   TestId = 2
               });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 20,
                        Name = "<style>",
                        IsRight = false,
                        QuestionId = 6
                    },
                    new Answer()
                    {
                        Id = 21,
                        Name = "<link>",
                        IsRight = true,
                        QuestionId = 6
                    },
                    new Answer()
                    {
                        Id = 22,
                        Name = "<meta>",
                        IsRight = false,
                        QuestionId = 6
                    },
                    new Answer()
                    {
                        Id = 23,
                        Name = "<css>",
                        IsRight = false,
                        QuestionId = 6
                    }
                });

            //JS test
            modelBuilder.Entity<Test>().HasData(
                new Test()
                {
                    Id = 3,
                    Name = "Основы JS",
                    Description = "Тест на знание основ JS.",
                    UserId = 2
                });

            modelBuilder.Entity<Question>().HasData(
              new Question()
              {
                  Id = 7,
                  Name = "Какая функция используется, если нужно спросить пользователя о чем-то и принять ответ 'да' или 'нет'?",
                  TestId = 3
              });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 24,
                        Name = "eval()",
                        IsRight = false,
                        QuestionId = 7
                    },
                    new Answer()
                    {
                        Id = 25,
                        Name = "alert()",
                        IsRight = true,
                        QuestionId = 7
                    },
                    new Answer()
                    {
                        Id = 26,
                        Name = "confirm()",
                        IsRight = false,
                        QuestionId = 7
                    },
                    new Answer()
                    {
                        Id = 27,
                        Name = "prompt()",
                        IsRight = false,
                        QuestionId = 7
                    }
                });

            modelBuilder.Entity<Question>().HasData(
              new Question()
              {
                  Id = 8,
                  Name = "С помощью каких тегов можно добавить скрипт на JavaScript в HTML-документ?",
                  TestId = 3
              });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 28,
                        Name = "<javascript>",
                        IsRight = false,
                        QuestionId = 8
                    },
                    new Answer()
                    {
                        Id = 29,
                        Name = "<script>",
                        IsRight = true,
                        QuestionId = 8
                    },
                    new Answer()
                    {
                        Id = 30,
                        Name = "<link>",
                        IsRight = false,
                        QuestionId = 8
                    },
                    new Answer()
                    {
                        Id = 31,
                        Name = "<program>",
                        IsRight = false,
                        QuestionId = 8
                    }
                });

            //C# test
            modelBuilder.Entity<Test>().HasData(
               new Test()
               {
                   Id = 4,
                   Name = "Основы C#",
                   Description = "Тест на знание основ C#.",
                   UserId = 2
               });

            modelBuilder.Entity<Question>().HasData(
              new Question()
              {
                  Id = 9,
                  Name = "Что делает оператор «%»",
                  TestId = 4
              });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 32,
                        Name = "Возвращает процент от суммы",
                        IsRight = false,
                        QuestionId = 9
                    },
                    new Answer()
                    {
                        Id = 33,
                        Name = "Возвращает тригонометрическую функцию",
                        IsRight = false,
                        QuestionId = 9
                    },
                    new Answer()
                    {
                        Id = 34,
                        Name = "Возвращает остаток от деления",
                        IsRight = true,
                        QuestionId = 9
                    },
                    new Answer()
                    {
                        Id = 35,
                        Name = "Ни чего из выше перечисленного",
                        IsRight = false,
                        QuestionId = 9
                    }
                });

            modelBuilder.Entity<Question>().HasData(
              new Question()
              {
                  Id = 10,
                  Name = "Как найти квадратный корень из числа x",
                  TestId = 4
              });
            modelBuilder.Entity<Answer>().HasData(
                new Answer[]
                {
                    new Answer()
                    {
                        Id = 36,
                        Name = "Sqrt(x)",
                        IsRight = false,
                        QuestionId = 10
                    },
                    new Answer()
                    {
                        Id = 37,
                        Name = "Arifmetic.sqrt",
                        IsRight = false,
                        QuestionId = 10
                    },
                    new Answer()
                    {
                        Id = 38,
                        Name = "Summ.Koren(x)",
                        IsRight = false,
                        QuestionId = 10
                    },
                    new Answer()
                    {
                        Id = 39,
                        Name = "Math.Sqrt(x)",
                        IsRight = true,
                        QuestionId = 10
                    }
                });
        }
    }
}
