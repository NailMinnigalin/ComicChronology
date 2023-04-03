using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ComicChronology
{
    internal static class DBConnection
    {
        static private readonly string _dbName = "ComicChronologyDB.sqlite";
        static private readonly string _connectionString = $"Data Source={_dbName};Version=3;";
        public static void InitDB()
        {
            if (!File.Exists(_dbName))
                SQLiteConnection.CreateFile(_dbName);

            UpdateDB();
        }
        
        public static int CreateNewSeries()
        {
            string sql = "INSERT INTO Series (title, periodicityId) VALUES (@title, @periodId);";
            ExecuteNonQuery(sql, new Dictionary<string, object> { { "@title", "New comics" }, { "@periodId", 1 } });

            return GetSeriesMaxId();
        }

        public static void DeleteSeries(int id)
        {
            string sql = "DELETE FROM series WHERE id = @sId;";
            ExecuteNonQuery(sql, new Dictionary<string, object> { { "@sId", id} });
        }

        public static Series? GetSeries(int id)
        {
            string sql = "SELECT * FROM series WHERE id = @sId";
            Series? series = null;

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@sId", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            int sId = reader.GetInt32(0);
                            string titles = reader.GetString(1);
                            int periodicityId = reader.GetInt32(2);
                            series = new Series(sId, titles, periodicityId);
                        }
                    }
                }
            }

            return series;
        }

        public static PeriodicityType? GetPeriodicityType(int id)
        {
            string sql = "SELECT * FROM PeriodicityType WHERE id = @sId";
            PeriodicityType? periodicityType = null;

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@sId", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            int pId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            periodicityType = new PeriodicityType(pId, name);
                        }
                    }
                }
            }

            return periodicityType;
        }

        public static List<Series> GetAllSeries()
        {
            string sql = "SELECT * FROM Series";
            List<Series> seriesList = new List<Series>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string title = reader["title"].ToString();
                            int periodicityId = Convert.ToInt32(reader["periodicityId"]);

                            seriesList.Add(new Series(id, title, periodicityId));
                        }
                    }
                }
            }

            return seriesList;
        }

        public static List<PeriodicityType> GetAllPeriodicityType()
        {
            string sql = "SELECT * FROM PeriodicityType";
            List<PeriodicityType> periodicityTypeList = new List<PeriodicityType>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string name = reader["name"].ToString();

                            periodicityTypeList.Add(new PeriodicityType(id, name));
                        }
                    }
                }
            }

            return periodicityTypeList;
        }

        public static void UpdateSeries(int id, string title, int periodicityId)
        {
            string sql = "UPDATE Series SET title = @Title, periodicityId = @PeriodicityId WHERE id = @Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@Title", title},
                {"@PeriodicityId", periodicityId},
                {"@Id", id}
            };
            ExecuteNonQuery(sql, parameters);
        }

        public static int GetNumberIssues(int seriesId)
        {
            string sql = "SELECT COUNT(*) FROM Issues WHERE seriesId = @sId";
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@sId", seriesId);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }

            return 0;
        }

        public static void ClearIssues(int seriesId)
        {
            string sql = "DELETE FROM Issues WHERE seriesId = @seriesId";
            ExecuteNonQuery(sql, new Dictionary<string, object> { { "@seriesId", seriesId } });
        }

        public static void InsertIssue(int seriesId, int issueNumber, DateTime releaseDate, bool isRead)
        {
            string sql = "INSERT INTO Issues (seriesId, issue_number, releaseDate, isRead) " +
                "VALUES (@seriesId, @issueNumber, @releaseDate, @isRead)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@seriesId", seriesId },
                { "@issueNumber", issueNumber },
                { "@releaseDate", releaseDate },
                { "@isRead", isRead}
            };
            ExecuteNonQuery(sql, parameters);
        }

        private static int GetSeriesMaxId()
        {
            string sql = "SELECT MAX(id) FROM Series";
            int maxId = 0;

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            maxId = reader.GetInt32(0);
                        }
                    }
                }
            }

            return maxId;
        }
        private static void UpdateDB()
        {
            string[] requiredTables = new string[] { "PeriodicityType", "Series", "Issues" };
            foreach (string requiredTable in requiredTables)
            {
                if (!IsTableExists(requiredTable))
                    CreateTable(requiredTable);
            }
        }

        private static void CreateTable(string requiredTable)
        {
            switch (requiredTable)
            {
                case "PeriodicityType":
                    CreatePeriodicityTypeTable();
                    FillPeriodicityTypeTable();
                    break;
                case "Series":
                    CreateSeriesTable();
                    break;
                case "Issues":
                    CreateIssuesTable();
                    break;
            }
        }

        private static void FillPeriodicityTypeTable()
        {
            string sql = @"INSERT INTO PeriodicityType (name) VALUES
                            ('annually'),
                            ('monthly'),
                            ('twice a month'),
                            ('weekly')";
            ExecuteNonQuery(sql);
        }

        private static void CreateIssuesTable()
        {
            string sql = @"CREATE TABLE Issues (
                            id INTEGER PRIMARY KEY,
                            seriesId INTEGER NOT NULL,
                            issue_number INTEGER NOT NULL,
                            releaseDate DATE NOT NULL,
                            isRead BOOLEAN NOT NULL,
                            FOREIGN KEY (seriesId) REFERENCES Series(id)
                            );";
            ExecuteNonQuery(sql);
        }

        private static void CreateSeriesTable()
        {
            string sql = @"CREATE TABLE Series (
                    id INTEGER PRIMARY KEY,
                    title TEXT NOT NULL,
                    periodicityId INTEGER NOT NULL,
                    FOREIGN KEY (periodicityId) REFERENCES PeriodicityType (id)
                    );";
            ExecuteNonQuery(sql);
        }

        private static void CreatePeriodicityTypeTable()
        {
            string sql = @"CREATE TABLE PeriodicityType (
                    id INTEGER PRIMARY KEY,
                    name TEXT NOT NULL
                    );";
            ExecuteNonQuery(sql);
        }

        private static void ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, object> param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        private static bool IsTableExists(string requiredTable)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT 1 FROM sqlite_master WHERE type = 'table' AND name = @requiredTable LIMIT 1;";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@requiredTable", requiredTable);
                    return command.ExecuteScalar() != null;
                }
            }
        }
    }
}
