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
    public partial class BAI5 : Form
    {
        public BAI5()
        {
            InitializeComponent();
        }

        private void BAI5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Bảng cửu chương");
            comboBox1.Items.Add("Tính toán giá trị");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
        }

        private (int Factorial, int SumofPowers) calculateValues(int A, int B)
        {
            int difference = A - B;
            int sumOfPowers = 0;
            int factorial = 1;

            // Calculate factorial
            for (int i = 1; i <= difference; i++)
            {
                factorial *= i;
            }

            // Calculate sum of A^1 to A^B
            for (int i = 1; i <= B; i++)
            {
                int power = (int)Math.Pow(A, i);
                sumOfPowers += power;
            }

            return (factorial, sumOfPowers);
        }

        private string GenerateMultiplicationTable(int A, int B)
        {
            if (B > A)
            {
                return "\nCảnh báo: B lớn hơn A. Đảm bảo B bé hơn hoặc bằng A để có thể xuất bảng";
            }

            string tables = "\n";
            for (int i = B; i <= A; i++)
            {
                tables += $"Bảng cửu chương cho {i}:\n";
                for (int j = 1; j <= 10; j++)
                {
                    tables += $"{i} x {j} = {i * j}\n";
                }
                tables += "\n"; // Add a line break between tables
            }

            return tables;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the TextBox has any input
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                // Check if the text can be parsed as an integer
                if (!int.TryParse(textBox1.Text, out _) || !int.TryParse(textBox2.Text, out _))
                {
                    MessageBox.Show("Vui lòng nhập số nguyên", "Cảnh báo");
                }
                else
                {
                    // Parse input text as int
                    int num1 = int.Parse(textBox1.Text);
                    int num2 = int.Parse(textBox2.Text);

                    int selectedIndex = comboBox1.SelectedIndex;
                    switch(selectedIndex)
                    {
                        case 0:
                            {
                                string table = GenerateMultiplicationTable(num1, num2);
                                richTextBox1.Text = table;
                            }
                            break;
                        case 1:
                            {
                                var (factorial, sumOfPowers) = calculateValues(num1, num2);
                                richTextBox1.AppendText("\n");
                                richTextBox1.AppendText($"Giá trị (A-B)!: {factorial}\n");
                                richTextBox1.AppendText($"Tổng S = A^1 + A^2 + ... + A^B: {sumOfPowers}\n");
                            }
                            break;
                        default:
                            MessageBox.Show("Hãy chọn một option tính toán !", "Cảnh báo");
                            break;
                    }
                }
            }
        }
    }
}
