using CatalogBook.Data;
using CatalogBook.Repositories;

namespace CatalogBook.Cmd
{
    public class TestOtherOperations
    {

        public void OtherOperations()
        {
            DeleteRecord();
        }


        private void DeleteRecord()
        {
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Операция удаления записи");
            Console.WriteLine();


            Console.WriteLine("Все записи книг и авторов");

            List<Book> books = GetListBook();

            foreach(Book book in books)
            {
                Console.WriteLine("Книга: ID =  {0} Название = {1} Автор ID = {2}, Автор = {3}", book.ID.ToString(), book.Title, book.Author is null ? "" : book.Author.ID.ToString(), book.Author is null ? "" : book.Author.Name);
            }



            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Возьмем первого автора и создадим с ним несколько книг");

            Author author = books[0].Author;

            for (int i = 1; i < 5; i++)
            {
                Book newBook = new Book();

                newBook.Author = author;

                newBook.Title = "Заголовок книги " + i.ToString();

                DataContext dataContext = new DataContext();

                BookRepository bookRepository = new BookRepository(dataContext);

                Task<Book> taskBook = bookRepository.AddOrEditAsync(newBook);

                Book saveBook = taskBook.Result;

                Console.WriteLine("Добавлена кника {0} c ID  = {1}", saveBook.Title, saveBook.ID.ToString());
            }

            Console.ReadLine();

            Console.WriteLine("Удалим автора c ID {0} (Имя автора {1})", author is null ? "" : author.ID.ToString(), author is null ? "" : author.Name);

            DataContext contextDeleteAuthor = new DataContext();

            AuthorRepository authorRepository = new AuthorRepository(contextDeleteAuthor);

            Task<bool> taskAuthorRemove = authorRepository.RemoveAsync(author);

            bool resultRemove = taskAuthorRemove.Result;

            if(resultRemove)
            {
                Console.WriteLine("Автор удален");
            }
            else
            {
                Console.WriteLine("Автор НЕ удален");
            }

            Console.ReadLine();
        }

        private List<Book> GetListBook()
        {
            DataContext context = new DataContext();

            BookRepository bookRepository = new BookRepository(context);

            Task<List<Book>> taskList = bookRepository.GetAllAsync();

            return taskList.Result;
        }
    }
}
