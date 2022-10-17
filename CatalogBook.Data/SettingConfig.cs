using Microsoft.Extensions.Configuration;

namespace CatalogBook.Data
{
    public class SettingConfig
    {
        public string GetCoonectingString()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());

            builder.AddJsonFile("ConnectSetting.json");

            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            return connectionString;
        }
    }
}
