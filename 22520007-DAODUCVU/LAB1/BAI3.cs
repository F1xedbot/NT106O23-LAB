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
    public partial class BAI3 : Form
    {

        // Create a dictionary to map numbers to Vietnamese words
        Dictionary<int, string> numberToVietnamese = new Dictionary<int, string>
        {
            { 0, "Không"},
            { 1, "Một" },
            { 2, "Hai" },
            { 3, "Ba" },
            { 4, "Bốn" },
            { 5, "Năm" },
            { 6, "Sáu" },
            { 7, "Bảy" },
            { 8, "Tám" },
            { 9, "Chín" }
        };
        public BAI3()
        {
            InitializeComponent();
        }

        private void BAI3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Check if the TextBox has any input
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                // Check if the text can be parsed as an integer
                if (!int.TryParse(textBox1.Text, out _))
                {
                    // Display a message box if the text is not an integer
                    MessageBox.Show("Vui lòng nhập số nguyên", "Cảnh báo");
                    // Clear the input
                    textBox1.Text = "";
                }
                else
                {
                    int input_num = int.Parse(textBox1.Text);
                    if (input_num < 0 || input_num > 9)
                    {
                        // Display a message box if the number is not between 0 and 9
                        MessageBox.Show("Vui lòng nhập số từ 0 đến 9", "Cảnh báo");
                        // Clear the input
                        textBox1.Text = "";

                    }
                    else
                    {
                        // Try to get the Vietnamese word from the dictionary
                        if (numberToVietnamese.TryGetValue(input_num, out string vietnameseWord))
                        {
                            // Set the text of textBox2 to the Vietnamese word
                            textBox2.Text = vietnameseWord;
                        }
                    }

                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
