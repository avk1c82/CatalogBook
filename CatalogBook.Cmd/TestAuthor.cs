using CatalogBook.Data;
using CatalogBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBook.Cmd
{
    public class TestAuthor
    {
        public Author CreateAuthor()
        {
            Author author = new Author();

            author.Name = "Головачев";

            DataContext context = new DataContext();

            AuthorRepository authorRepository = new AuthorRepository(context);

            Task<Author> taskSaveAuthor = authorRepository.AddOrEditAsync(author);

            //if(!taskSaveAuthor.IsCompleted)
            //{
            //    Console.WriteLine("Ждемс, пока не запишет и не удалит 'context'");
            //    taskSaveAuthor.Wait();
            //}

            Author saveAuthor = taskSaveAuthor.Result;

            Console.WriteLine("Записан автор: " + saveAuthor.Name + " ID = " + saveAuthor.ID.ToString());

            Console.WriteLine();




            Console.WriteLine("Получаем автора по ID = " + saveAuthor.ID.ToString());

            DataContext contextRead = new DataContext();

            AuthorRepository authorReadRepository = new AuthorRepository(contextRead);

            Task<Author> taskReadAuthor = authorReadRepository.GetByIdAsync(new Guid(saveAuthor.ID.ToString()));

            //if(!taskReadAuthor.IsCompleted)
            //{
            //    Console.WriteLine("Ждемс, пока не прочитает и не удалит 'contextRead'");
            //    taskSaveAuthor.Wait();
            //}

            Author readAuthor = taskReadAuthor.Result;

            Console.WriteLine("Прочитал автора под ID = " + saveAuthor.ID.ToString() + ". Это " + readAuthor.Name);

            Console.WriteLine();




            string newAuthor = "Донцова";

            Console.WriteLine("Изменяем автора: " + readAuthor.Name + " с ID = " + readAuthor.ID.ToString() + " на " + newAuthor + " (не приведи Бог!!!)");

            saveAuthor.Name = newAuthor;

            DataContext contextChange = new DataContext();

            AuthorRepository authorRepositoryChange = new AuthorRepository(contextChange);

            Task<Author> taskChangeAuthor = authorRepositoryChange.AddOrEditAsync(saveAuthor);

            //if(!taskChangeAuthor.IsCompleted)
            //{
            //    Console.WriteLine("Ждемс, пока не изменит и не удалит 'contextChange'");
            //    taskSaveAuthor.Wait();
            //}

            Author changeAuthor = taskChangeAuthor.Result;

            Console.WriteLine("Изменили автора под ID = " + changeAuthor.ID.ToString() + ". теперь это (упаси Бог!) " + changeAuthor.Name);

            Console.WriteLine();

            Console.WriteLine("Возвращаем автора с ID = " + changeAuthor.ID);

            return changeAuthor;
        }
    }
}
