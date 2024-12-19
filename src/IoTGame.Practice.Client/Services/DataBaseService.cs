using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IoTGame.Practice.Client.Services
{
    public class DatabaseService
    {
        private readonly HttpClient _httpClient;

        public DatabaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<object>> QueryDataAsync(string database, string roadId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<object>>(
                $"api/data/query?database={database}&roadId={roadId}"
            );
            return response ?? new List<object>();
        }

        public async Task<List<Data>> QueryHistoryDataAsync(string database)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Data>>(
                $"api/data/history?database={database}"
            );
            return response ?? new List<Data>();
        }
    }

    public class Data
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public float Flow { get; set; }
    }
}
