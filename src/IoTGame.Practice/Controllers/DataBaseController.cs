using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace IoTGame.Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet("query")]
        public IActionResult QueryData(string database, string table, string roadId)
        {
            string connectionString = GetConnectionString(database);
            var results = new List<object>();

            if (!System.IO.File.Exists(connectionString))
            {
                return Ok(results); // 返回空表
            }

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT date, [{roadId}] FROM {table}";
                command.Parameters.AddWithValue("@roadId", roadId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new { Date = reader.GetString(0), Value = reader.GetInt32(1) });
                    }
                }
            }

            return Ok(results);
        }

        [HttpGet("history")]
        public IActionResult QueryHistoryData(string database, string table)
        {
            string connectionString = GetConnectionString(database);
            var results = new List<object>();

            if (!System.IO.File.Exists(connectionString))
            {
                return Ok(results); // 返回空表
            }

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Time, Flow FROM {table}";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(
                            new
                            {
                                Id = reader.GetInt32(0),
                                Time = reader.GetString(1),
                                Flow = reader.GetFloat(2),
                            }
                        );
                    }
                }
            }

            return Ok(results);
        }

        private string GetConnectionString(string database)
        {
            return $"Data Source=../wwwroot/Data/{database}";
        }
    }
}
