using CatalogBook.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBook.Models
{
    public class BookModel : BaseModel
    {
        public string? Title { get; set; }

        public Guid? AuthorId { get; set; }
        public virtual AuthorModel? Author { get; set; }

        public string AuthorName { get; set; }

        public DateTime? YearIssue { get; set; }

        public string? ISBN { get; set; }

        public byte[]? Cover { get; set; }

        public string? Description { get; set; }


        public BookModel() : base()
        {
            Title = "";
            AuthorId = null;
            Author = null;
            AuthorName = "";
            YearIssue = null;
            ISBN = "";
            Cover = null;
            Description = "";
        }

        public BookModel(Guid id,
                    string? title,
                    Guid? authorId,
                    AuthorModel? author,
                    DateTime? yearIssue,
                    string? isbn,
                    byte[]? cover,
                    string? description,
                    bool deleteRecord = false) : base(id, deleteRecord)
        {
            Title = title;
            AuthorId = authorId;
            Author = author;

            if(author is null)
            {
                AuthorName = "";
            }
            else
            {
                AuthorName = author.Name ?? "";
            }

            YearIssue = yearIssue;
            ISBN = isbn;
            Cover = cover;
            Description = description;
        }
    }
}
