using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    internal class DatabaseHelper
    {
        public void DatabaseInitialize()
        {


            string connectionString = @"Data Source=..\..\..\Databases\food.db;Version=3;UseUTF16Encoding=True;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Path to the image file you want to insert
                string imagePath = "../../../Databases/Images/pho.jpg";

                int idncc = 1;
                string name = "pho";

                InsertMonAn(imagePath, name, idncc, connection);

                // Close the connection
                connection.Close();
            }
        }
        public void InsertMonAn(string imagePath, string name, int idncc, SQLiteConnection connection)
        {
            // Check if the record already exists in the database
            string checkSql = "SELECT COUNT(*) FROM MonAn WHERE TenMonAn = @name";
            using (SQLiteCommand checkCommand = new SQLiteCommand(checkSql, connection))
            {
                checkCommand.Parameters.AddWithValue("@name", name);
                int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                // If the record already exists, do not insert it again
                if (existingCount > 0)
                {
                    Console.WriteLine("The record already exists in the database.");
                    return;
                }
            }


            byte[] imageData = File.ReadAllBytes(imagePath);

            string sql = "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@name, @imageData, @idncc)";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            { 
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@idncc", idncc);
                command.Parameters.AddWithValue("@imageData", imageData);
                command.ExecuteNonQuery();
            }
        }

    }
}
