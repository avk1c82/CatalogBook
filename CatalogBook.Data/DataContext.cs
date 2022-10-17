using Microsoft.EntityFrameworkCore;

namespace CatalogBook.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }


        private readonly string _connectStr;

        public DataContext() : base()
        {
            SettingConfig settingConfig = new SettingConfig();

            _connectStr = settingConfig.GetCoonectingString();

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            SettingConfig settingConfig = new SettingConfig();

            _connectStr = settingConfig.GetCoonectingString();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_connectStr);

            // Для миграции раскоментировать
            //optionsBuilder.UseSqlServer("Server=SQL-PC\\SQLAVK;Database=BookDB;User=sa;Password=*****");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b => b.Author).WithMany().OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Author>().HasData(
                new Author[]
                {
                    new Author()
                    {
                        ID = new Guid("{342E3C92-4BCE-4037-839C-5EA6BAED5804}"),
                        Name = "М. Флеонов"
                    },

                    new Author()
                    {
                        ID = new Guid("{23D04B00-2A00-4E5C-B7C8-0AA772D73B9A}"),
                        Name = "Дж. Рихтер"
                    },


                    new Author()
                    {
                        ID = new Guid("{D73D3244-0C0E-4644-A0E9-4DD8C963BA8D}"),
                        Name = "Р. Ривест"
                    }

                });

            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book()
                    {
                        ID = new Guid("{6FB2F2C6-5286-4A4D-B02A-F0340DA405DC}"),
                        Title = "Библия Delphi",
                        AuthorId = new Guid("{342E3C92-4BCE-4037-839C-5EA6BAED5804}"),
                        YearIssue = new DateTime(2000,6,20),
                        ISBN = "123-123-123",
                        Description = "Хорошая книга для начинающих"
                    },

                    new Book()
                    {
                        ID = new Guid("{B735E892-21A6-4A2F-B798-B53901BD6919}"),
                        Title = "Библия SQL",
                        AuthorId = new Guid("{342E3C92-4BCE-4037-839C-5EA6BAED5804}"),
                        YearIssue = new DateTime(2000,6,20),
                        ISBN = "555-555-555",
                        Description = "Отличная книга по SQL даже сейчас!"
                    },

                    new Book()
                    {
                        ID = new Guid("{243C40D5-7818-4C46-8069-FE0A43DA149C}"),
                        Title = "CLR via C#",
                        AuthorId = new Guid("{23D04B00-2A00-4E5C-B7C8-0AA772D73B9A}"),
                        YearIssue = new DateTime(2019,1,1),
                        ISBN = "978-5-4461-1102-2",
                        Description = "Программирование на платформе Microsof .Net Framework 4.5 на языке C#"
                    },

                    new Book()
                    {
                        ID = new Guid("{292EA292-CC97-4AEF-AC27-F528E2801CB2}"),
                        Title = "Алгоритмы, посторение и анализ",
                        AuthorId = new Guid("{D73D3244-0C0E-4644-A0E9-4DD8C963BA8D}"),
                        YearIssue = new DateTime(2019,1,1),
                        ISBN = "5-900916-37-5",
                        Description = "Книга представляет собой перевод учебника по курсу построения и анализа эффективных алгоритмов."
                    }

                });
        }


    }
}
