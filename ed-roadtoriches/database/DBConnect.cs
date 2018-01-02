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
                String sql = "CREATE TABLE BODIES (id int not null primary key, system varchar(128),body varchar(128),dta int unsigned,type tinyint,orbitalPeriod int unsigned);";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        
        }
        public void AddWithQuery(String command)
        {

        }

        public Int64 getEntriesCount()
        {
            return -1;
        }
        public void convertDB() {
            try
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Waldemar_L/ed-roadtoriches/db.sqlite");
                File.Move((Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Waldemar_L/ed-roadtoriches/db.sqlite.tmp"),( Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Waldemar_L/ed-roadtoriches/db.sqlite"));
            }
            catch
            {

            }
        }

    }
}
