using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class BAI6 : Form
    {
        private string connectionString = @"Data Source=..\..\..\Databases\food.db;Version=3;UseUTF16Encoding=True;";
        public void InitializeListView()
        {
            // Clear existing items and columns in the ListView
            listView1.Items.Clear();
            listView1.Columns.Clear();

            listView1.Columns.Add("Dish Name", 150); // Add a column for dish name
            listView1.Columns.Add("Contributor", 150); // Add a column for contributor
        }

        public void PopulateListView()
        {
            listView1.Items.Clear();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT MonAn.TenMonAn, NguoiDung.HoVaTen " +
                             "FROM MonAn " +
                             "INNER JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve dish name and contributor name from the query result
                            string dishName = reader["TenMonAn"].ToString();
                            string contributorName = reader["HoVaTen"].ToString();

                            // Create a ListViewItem and add dish name and contributor name as sub-items
                            ListViewItem item = new ListViewItem(dishName);
                            item.SubItems.Add(contributorName);

                            // Add the ListViewItem to the ListView
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private DatabaseHelper dbHelper;
        public BAI6()
        {
            dbHelper = new DatabaseHelper();
            InitializeComponent();
            InitializeListView();
            PopulateListView();
            listView1.View = View.Details; // Set the View property to Details
        }

        private string selectedImageFile = "";

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dishInput.Text) || string.IsNullOrEmpty(contribInput.Text) || string.IsNullOrEmpty(selectedImageFile))
            {
                MessageBox.Show("Cannot add insufficient data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            // Check if the contributor exists in the NguoiDung table and is an admin
            string query = "SELECT IDNCC FROM NguoiDung WHERE HoVaTen = @contributor AND QuyenHan = 'admin'";
            int adminID;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@contributor", contribInput.Text);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        adminID = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Contributor is not an admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Proceed with adding the data
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Values of the MonAn item to associate with the image
                string name = dishInput.Text;

                // Insert the data into the MonAn table
                dbHelper.InsertMonAn(selectedImageFile, name, adminID, connection);
                PopulateListView();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if there are any records in the MonAn table
            int totalRecords = GetTotalRecordsCount();

            if (totalRecords == 0)
            {
                MessageBox.Show("There are no records in the MonAn table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Generate a random IDMA value
            Random random = new Random();

            int randomIDMA = random.Next(1, totalRecords + 1); // Assuming IDMA starts from 1

            // Retrieve the full row corresponding to the random IDMA value
            string query = @"SELECT MonAn.*, NguoiDung.HoVaTen
                     FROM MonAn
                     INNER JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC
                     WHERE MonAn.IDMA = @idma";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idma", randomIDMA);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the BLOB data (image) from the database
                            byte[] imageData = (byte[])reader["HinhAnh"];
                            // Retrieve the data
                            string tenMonAn = reader["TenMonAn"].ToString();
                            string hoVaTen = reader["HoVaTen"].ToString();

                            BAI6_1 dialog = new BAI6_1(tenMonAn, hoVaTen, imageData);
                            dialog.ShowDialog();
                        }
                    }
                }
            }
        }

        private int GetTotalRecordsCount()
        {
            string query = "SELECT COUNT(*) FROM MonAn";

            int totalRecords = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    totalRecords = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return totalRecords;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Open file dialog to choose image file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image File";
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                selectedImageFile = openFileDialog.FileName;

                // Get the filename without the relative path
                string fileName = Path.GetFileName(selectedImageFile);

                // Now you can use 'selectedImageFile' to access the full path,
                // and 'fileName' to access the filename without the path.

                chooseImgBtn.Text = fileName;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BAI6_Load(object sender, EventArgs e)
        {

        }
    }
}
