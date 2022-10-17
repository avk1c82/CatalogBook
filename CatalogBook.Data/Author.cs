using CatalogBook.Data.Abstract;

namespace CatalogBook.Data
{
    public class Author : BaseData
    {
        public string? Name { get; set; }

        public Author() : base()
        {
            Name = "";
        }

        public Author(Guid id, string name, bool deleteRecord = false) : base(id, deleteRecord)
        {
            Name = name;
        }
    }
}
