using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace ed_roadtoriches.database
{
    class DBConnect
    {
        SQLiteConnection connection;
        public DBConnect()
        {
            var pathToDB = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Waldemar_L/ed-roadtoriches/db.sqlite";
            if (!File.Exists(pathToDB))
            {
                CreateDB();
            }


            void CreateDB()
            {
                SQLiteConnection.CreateFile(pathToDB+".tmp");
                connection = new SQLiteConnection("Data Source=" + pathToDB + ".tmp;Version=3");
                connection.Open();
                String sql = "CREATE TABLE BODIES (id int not null primary key, system varchar(128),body varchar(128),dta int unsigned,type tinyint,orbitalPeriod int unsigned, coordX float, coordY float, coordZ float);";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        
        }
        public void AddWithQuery(String sql_query)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(sql_query, connection);
            connection.Close();
        }
        public void AddEntry(Body entry)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(
                $"INSERT INTO BODIES(id,system,body,dta,type,orbitalPeriod,coordX,coordY,coordZ)VALUES('{entry.ID}','{entry.System}','{entry.Planet}','{entry.DTA}','{entry.Type}','{entry.OrbitalPeriod}');", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AddEntries(List<Body> entries)
        {
            if (entries.Count > 500) { System.Diagnostics.Debug.WriteLine("Error in DBConnect > AddEntries(): You cannot send more than 500 Entries at once"); }
            else if (entries.Count > 40)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("INSERT INTO BODIES(id,system,body,dta,type,orbitalPeriod,coordX,coordY,coordZ) VALUES ");
                foreach (Body entry in entries)
                {
                    stringBuilder.Append($"('{entry.ID}','{entry.System}','{entry.Planet}','{entry.DTA}','{entry.Type}','{entry.OrbitalPeriod}','{entry.X}','{entry.Y}','{entry.Z}'),");
                }
                stringBuilder.Length--; // removing , from the String
                stringBuilder.Append(";");
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(stringBuilder.ToString(), connection);
                connection.Close();
            }
            else
            {
                String sqlquery = "INSERT INTO BODIES(id,system,body,dta,type,orbitalPeriod)VALUES";
                foreach(Body entry in entries)
                {
                    sqlquery += $"('{entry.ID}','{entry.System}','{entry.Planet}','{entry.DTA}','{entry.Type}','{entry.OrbitalPeriod}'),";
                }
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlquery.Remove(sqlquery.Length - 1) + ";", connection);
                connection.Close();
                
            }

        }

        public uint GetEntriesCount()
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("select count(*) from BODIES;", connection);
            uint entries = Convert.ToUInt32(command.ExecuteScalar());
            connection.Close();
            return entries;

        }
        public void ConvertDB() { // Changes db.sqlite.tmp into final db.sqlite
            try
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Waldemar_L/ed-roadtoriches/db.sqlite");
                File.Move((Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Waldemar_L/ed-roadtoriches/db.sqlite.tmp"),( Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Waldemar_L/ed-roadtoriches/db.sqlite"));
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error in DBConnect.cs > ConvertDB():{e}");
            }
        }

    }
}
