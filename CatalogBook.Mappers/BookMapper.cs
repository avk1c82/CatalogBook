using CatalogBook.Data;
using CatalogBook.Models;

namespace CatalogBook.Mappers
{
    public static class BookMapper
    {
        public static Book? ToData(this BookModel item)
        {
            if(item == null)
            {
                return null;
            }

            Book itemOut = new Book(item.ID, 
                                    item.Title, 
                                    item.AuthorId, 
                                    item.YearIssue, 
                                    item.ISBN, 
                                    item.Cover, 
                                    item.Description, 
                                    item.DeleteRecord);

            return itemOut;
        }


        public static List<Book>? ToData(this List<BookModel> item)
        {
            if(item == null)
            {
                return null;
            }

            List<Book?> itemOut = new List<Book?>();

            foreach(BookModel book in item)
            {
                itemOut.Add(ToData(book));
            }

            return itemOut;
        }


        public static BookModel? ToModel(this Book item)
        {
            if(item == null)
            {
                return null;
            }

            BookModel itemOut = new BookModel(item.ID,
                                                item.Title,
                                                item.AuthorId,
                                                item.Author.ToModel(),
                                                item.YearIssue,
                                                item.ISBN,
                                                item.Cover,
                                                item.Description,
                                                item.DeleteRecord);

            return itemOut;
        }

        public static List<BookModel>? ToModel(this List<Book> item)
        {
            if(item == null)
            {
                return null;
            }

            List<BookModel?> itemOut = new List<BookModel?>();

            foreach(Book bookModel in item)
            {
                itemOut.Add(bookModel.ToModel());
            }

            return itemOut;
        }

    }
}
