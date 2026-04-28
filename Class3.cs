using Microsoft.Data.Sqlite;
using System;

SqliteConnection con = new SqliteConnection(@"Data Source='chinook.db'");
con.open();
SqliteCommand cmd = con.CreateCommand();
cmd.CommandText = "SELECT * FROM artists";
SqliteDataReader reader = cmd.ExecuteReader;
while (reader.Read())
{
    Console.WriteLine(reader["ProductName"]);
}
