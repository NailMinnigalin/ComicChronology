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

        private static void ExecuteNonQuery(string sql)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
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
