using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBook.Models.Abstracts
{
    public class BaseModel
    {
        public Guid ID { get; set; }

        public bool DeleteRecord { get; set; }

        public BaseModel()
        {
            ID = default(Guid);

            DeleteRecord = false;
        }

        public BaseModel(Guid id, bool deleteRecord)
        {
            ID = id;
            DeleteRecord = deleteRecord;
        }
    }
}
