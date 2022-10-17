using CatalogBook.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBook.Models
{
    public class AuthorModel : BaseModel
    {
        public string? Name { get; set; }

        public AuthorModel() : base()
        {
            Name = "";
        }

        public AuthorModel(Guid id, string name, bool deleteRecord = false) : base(id, deleteRecord)
        {
            Name = name;
        }
    }
}
