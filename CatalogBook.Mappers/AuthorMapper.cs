using CatalogBook.Data;
using CatalogBook.Models;

namespace CatalogBook.Mappers
{
    public static class AuthorMapper
    {

        public static Author? ToData(this AuthorModel item)
        {
            if(item is null)
            {
                return null;
            }

            Author itemOut = new Author(item.ID, item.Name, item.DeleteRecord);

            return itemOut;
        }

        public static List<Author>? ToData(this List<AuthorModel> item)
        {
            if(item is null)
            {
                return null;
            }

            List<Author?> itemOut = new List<Author?>();

            foreach(AuthorModel author in item)
            {
                itemOut.Add(author.ToData());
            }

            return itemOut;
        }


        public static AuthorModel? ToModel(this Author item)
        {
            if(item is null)
            {
                return null;
            }

            AuthorModel itemOut = new AuthorModel(item.ID, item.Name, item.DeleteRecord);

            return itemOut;
        }


        public static List<AuthorModel>? ToModel(this List<Author> item)
        {
            if(item is null)
            {
                return null;
            }

            List<AuthorModel?> itemOut = new List<AuthorModel?>();

            foreach(Author authorModel in item)
            {
                itemOut.Add(authorModel.ToModel());
            }

            return itemOut;
        }
    }
}
