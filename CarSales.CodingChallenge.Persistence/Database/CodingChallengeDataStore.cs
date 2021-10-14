using JsonFlatFileDataStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarSales.CodingChallenge.Persistence.Database
{
    public class CodingChallengeDataStore : ICodingChallengeDataStore
    {
        private DataStore _dataStore;

        public CodingChallengeDataStore()
        {
            _dataStore = new DataStore(Path.Join(AppContext.BaseDirectory, "Database\\salesperson.json"));
        }

        public IEnumerable<T> Collection<T>(string name) where T : class
        {
            return _dataStore.GetCollection<T>(name).AsQueryable();
        }

        public async Task InsertOneAsync<T>(string name, T obj) where T : class
        {
            var collection = _dataStore.GetCollection<T>(name);
            await collection.InsertOneAsync(obj);
        }
    }
}
