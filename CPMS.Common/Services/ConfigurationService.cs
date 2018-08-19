using System.Linq;
using CPMS.Common.EF;
using CPMS.Common.Entities;

namespace CPMS.Common.Services
{
    public interface IConfigurationService
    {
        string GetValue(string key);

        void AddOrUpdateValue(string key, string value);
    }

    public static class ConfigurationKeys
    {
        public static readonly string JwtSecret = "JwtSecret";
    }


    public class ConfigurationService : IConfigurationService
    {
        private readonly DataContext _dataContext;

        public ConfigurationService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string GetValue(string key)
        {
            return _dataContext.Configurations.SingleOrDefault(x => x.Key == key)?.Value;
        }

        public void AddOrUpdateValue(string key, string value)
        {
            var entry = _dataContext.Configurations.SingleOrDefault(x => x.Key == key);
            if (entry != null)
            {
                entry.Value = value;
            }
            else
            {
                _dataContext.Configurations.Add(new Configuration
                {
                    Key = key,
                    Value = value
                });
            }

            _dataContext.SaveChanges();
        }
    }
}
