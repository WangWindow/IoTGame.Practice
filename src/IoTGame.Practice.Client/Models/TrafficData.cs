using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace IoTGame.Practice.Client.Models;

public class TrafficData
{
    private readonly string connectionString;

    public TrafficData(string dbPath)
    {
        connectionString = $"Data Source={dbPath};Version=3;";
    }

    public class TrafficRecord
    {
        public int Road { get; set; }
        public DateTime Date { get; set; }
        public double Flow { get; set; }
    }

    /// <summary>
    /// Get traffic data from the database
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    public List<TrafficRecord> GetTrafficData(string tableName)
    {
        var records = new List<TrafficRecord>();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT road, date, flow FROM {tableName}";
            using (var command = new SQLiteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = new TrafficRecord
                        {
                            Road = reader.GetInt32(0),
                            Date = DateTime.Parse(reader.GetString(1)),
                            Flow = reader.GetDouble(2),
                        };
                        records.Add(record);
                    }
                }
            }
        }

        return records;
    }

    /// <summary>
    /// Get traffic data from the database for a specific road
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="road"></param>
    /// <returns></returns>
    public List<TrafficRecord> GetTrafficData(string tableName, int road)
    {
        var records = new List<TrafficRecord>();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT road, date, flow FROM {tableName} WHERE road = @road";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@road", road);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = new TrafficRecord
                        {
                            Road = reader.GetInt32(0),
                            Date = DateTime.Parse(reader.GetString(1)),
                            Flow = reader.GetDouble(2),
                        };
                        records.Add(record);
                    }
                }
            }
        }

        return records;
    }

    /// <summary>
    /// (async)Get traffic data from the database
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    public async Task<List<TrafficRecord>> GetTrafficDataAsync(string tableName)
    {
        var records = new List<TrafficRecord>();
        using (var connection = new SQLiteConnection(connectionString))
        {
            await connection.OpenAsync();
            string query = $"SELECT road, date, flow FROM {tableName}";
            using (var command = new SQLiteCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var record = new TrafficRecord
                        {
                            Road = reader.GetInt32(0),
                            Date = DateTime.Parse(reader.GetString(1)),
                            Flow = reader.GetDouble(2),
                        };
                        records.Add(record);
                    }
                }
            }
        }
        return records;
    }

    /// <summary>
    /// (async)Get traffic data from the database for a specific road
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="road"></param>
    /// <returns></returns>
    public async Task<List<TrafficRecord>> GetTrafficDataAsync(string tableName, string road)
    {
        var records = new List<TrafficRecord>();
        using (var connection = new SQLiteConnection(connectionString))
        {
            await connection.OpenAsync();
            string query = $"SELECT road, date, flow FROM {tableName} WHERE road = @road";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@road", road);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var record = new TrafficRecord
                        {
                            Road = reader.GetInt32(0),
                            Date = DateTime.Parse(reader.GetString(1)),
                            Flow = reader.GetDouble(2),
                        };
                        records.Add(record);
                    }
                }
            }
        }
        return records;
    }
}
