using System.Data.SQLite;

namespace LAB2
{
    public partial class LAB2_GUI : Form
    {
        public LAB2_GUI()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            InitializeComponent();
            dbHelper.DatabaseInitialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAI1 bai1 = new BAI1();
            bai1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BAI2 bai2 = new BAI2();
            bai2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BAI3 bai3 = new BAI3();
            bai3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BAI4 bai4 = new BAI4();
            bai4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BAI5 bai5 = new BAI5();
            bai5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BAI6 bai6 = new BAI6();
            bai6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BAI7 bai7 = new BAI7();
            bai7.Show();
        }
    }


}
