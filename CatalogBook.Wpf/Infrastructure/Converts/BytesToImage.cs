using System;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;


namespace CatalogBook.Wpf.Infrastructure.Converts
{
    public class BytesToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] bytes = (byte[])value;

            if(bytes == null)
            {
                return null;
            }

            BitmapImage image = new BitmapImage();

            using (MemoryStream stream = new MemoryStream(bytes, 0, bytes.Length))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
            }

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapSource image = (BitmapSource)value;

            if(image == null)
            {
                return null;
            }

            byte[] bytes = File.ReadAllBytes(image.ToString());

            return bytes;
        }
    }
}
