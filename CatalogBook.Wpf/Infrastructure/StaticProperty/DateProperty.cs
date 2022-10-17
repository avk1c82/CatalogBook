using System;

namespace CatalogBook.Wpf.Infrastructure.StaticProperty
{
    public static class DateProperty
    {
        public static DateTime StartDate 
        { get
            { 
                return DateTime.Now.AddMonths(1);
            }
        }
    }
}
