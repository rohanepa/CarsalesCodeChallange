using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.CodingChallenge.Persistence.Database
{
    public interface ICodingChallengeDataStore
    {
        IEnumerable<T> Collection<T>(string name) where T : class;
        Task InsertOneAsync<T>(string name, T obj) where T : class;
    }
}
