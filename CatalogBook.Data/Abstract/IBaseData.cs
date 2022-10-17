namespace CatalogBook.Data.Abstract
{
    public interface IBaseData
    {
        public Guid ID { get; set; }

        public bool DeleteRecord { get; set; }
    }
}
