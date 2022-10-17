namespace CatalogBook.Data.Abstract
{
    public abstract class BaseData : IBaseData
    {
        public Guid ID { get; set; }

        public bool DeleteRecord { get; set; }

        public BaseData()
        {
            ID = default(Guid);

            DeleteRecord = false;
        }

        public BaseData(Guid id, bool deleteRecord)
        {
            ID = id;
            DeleteRecord = deleteRecord;
        }
    }
}
