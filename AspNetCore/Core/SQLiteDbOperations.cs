using System.Data;
using System.Data.SQLite;
using System.IO;

namespace AspNetCore.Core
{
    public class SQLiteDbOperations
    {
        internal SQLiteConnection connection;

        /// <summary>
        /// 
        /// </summary>
        public SQLiteDbOperations()
        {
            if (!File.Exists("Assessment.sqlite"))
            {
                SQLiteCommand command;
                SQLiteConnection.CreateFile("Assessment.sqlite");

                string sql = @"CREATE TABLE User(
                               Id INTEGER PRIMARY KEY AUTOINCREMENT ,
                               FirstName          TEXT      NOT NULL,
                               LastName           TEXT      NOT NULL
                            );";
                connection = new SQLiteConnection("Data Source=Assessment.sqlite;Version=3;");
                connection.Open();
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal void OpenConnection()
        {
            connection = new SQLiteConnection("Data Source=Assessment.sqlite;Version=3;");
            connection.Open();
        }

        /// <summary>
        /// 
        /// </summary>
        internal void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
