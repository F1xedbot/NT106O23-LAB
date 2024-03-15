using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class BAI2 : Form
    {
        public BAI2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool is_int_num1 = int.TryParse(textBox1.Text, out int num1);
            bool is_int_num2 = int.TryParse(textBox5.Text, out int num2);
            bool is_int_num3 = int.TryParse(textBox2.Text, out int num3);

            if (!(is_int_num1 && is_int_num2 && is_int_num3))
            {
                // Display a message box if the inputs is not an integer
                MessageBox.Show("Vui lòng nhập số nguyên", "Cảnh báo");
            }
            else
            {
                // Find the smallest and largest number
                int smallest = Math.Min(Math.Min(num1, num2), num3);
                int largest = Math.Max(Math.Max(num1, num2), num3);

                textBox4.Text = largest.ToString();
                textBox6.Text = smallest.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox5.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
