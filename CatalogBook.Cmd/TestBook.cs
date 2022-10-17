using CatalogBook.Data;
using CatalogBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBook.Cmd
{
    public class TestBook
    {
        public Book CreateBook(Author author)
        {
            Book book = new Book();

            book.Title = "Бич времен";

            book.Author = author;

            book.YearIssue = new DateTime(1996, 05, 01);

            book.ISBN = "Т-130-500";

            book.Description = "Фантастика про хроновыверт";

            DataContext context = new DataContext();

            BookRepository bookRepository = new BookRepository(context);

            Task<Book> taskBookNew = bookRepository.AddOrEditAsync(book);

            Book bookNew = taskBookNew.Result;

            Console.WriteLine("ID новой книги = " + bookNew.ID);

            Console.WriteLine();



            Console.WriteLine("Прлучаем книгу по ID = " + bookNew.ID.ToString());

            DataContext contextBookRead = new DataContext();

            BookRepository bookRepositoryRead = new BookRepository(contextBookRead);

            Task<Book> taskBookRead = bookRepositoryRead.GetByIdAsync(bookNew.ID);

            Book bookRead = taskBookRead.Result;

            Console.WriteLine("Прочитана запись с ID = " + bookRead.ID + " название: " + bookRead.Title + " автор: " + bookRead.Author.Name);

            Console.WriteLine();

            

            Console.WriteLine("Внесение изменений в запись");

            bookRead.Author.Name = "Головачев";

            DataContext dataContextBookChange = new DataContext();

            BookRepository bookRepositoryChange = new BookRepository(dataContextBookChange);

            Task<Book> taskBookChange = bookRepositoryChange.AddOrEditAsync(bookRead);

            Book bookChange = taskBookChange.Result;

            Console.WriteLine("Изменена кника с ID = " + bookChange.ID.ToString() + " теперь автор = " + bookChange.Author.Name);

            Console.WriteLine();



            Console.ReadLine();

            return bookChange;
        }
    }
}
