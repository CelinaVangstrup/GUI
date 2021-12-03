using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ST3PRJ3.Data
{
    public class DataBase
    {
        public SQLiteConnection myConnection;

        public DataBase()
        {
            myConnection = new SQLiteConnection("Data Source=database.db");

            if (!File.Exists("./database.db")) // Tjekker om databasen eksistere, hvis ikke, opretter den en ny
            {
                SQLiteConnection.CreateFile(@".\database.db");

            }
            
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open) //Tjekker om forbindelsen til database er åbent, hvis ikke, åbner den forbindelse til den
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if ((myConnection.State != System.Data.ConnectionState.Closed)) //Tjekker om forbindelsen til database er lukket, hvis ikke, lukker den forbindelse til den
            {
                myConnection.Close();
                
            }
        }

        public static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sQLiteCommand;
            String createSQL = "CREATE TABLE SampleTable(Col1 VARCHAR(20), COL2 INT)";
            sQLiteCommand = conn.CreateCommand();
            sQLiteCommand.CommandText = createSQL;
            sQLiteCommand.ExecuteNonQuery();
        }

        public static void uploadData()
        {
            BloodPressureUDPReader data = new BloodPressureUDPReader();

            object datalist = data.ReadBloodPressureFromUDP();
        
            
            //sQLiteCommand.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES ('PersonNumber', bloodpressureData);";
            //sQLiteCommand.ExecuteNonQuery();
        }
    }
}
