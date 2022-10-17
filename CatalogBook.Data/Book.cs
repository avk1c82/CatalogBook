using CatalogBook.Data.Abstract;

namespace CatalogBook.Data
{
    public class Book : BaseData
    {
        public string? Title { get; set; }
        
        public Guid? AuthorId { get; set; }
        public virtual Author? Author { get; set; }

        public DateTime? YearIssue { get; set; }

        public string? ISBN { get; set; }

        public byte[]? Cover { get; set; }

        public string? Description { get; set; }


        public Book() : base()
        {
            Title = "";
            AuthorId = null;
            Author = null;            
            YearIssue = null;
            ISBN = "";
            Cover = null;
            Description = "";
        }

        public Book(Guid id, 
                    string? title, 
                    Guid? authorId, 
                    DateTime? yearIssue, 
                    string? isbn, 
                    byte[]? cover, 
                    string? description, 
                    bool deleteRecord = false) : base(id, deleteRecord)
        {
            Title = title;
            AuthorId = authorId;
            Author = null;
            YearIssue = yearIssue;
            ISBN = isbn;
            Cover = cover;
            Description = description;
        }
    }
}
