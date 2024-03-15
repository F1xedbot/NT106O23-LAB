using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class BAI8 : Form
    {
        public BAI8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the text from textBox1
            string newText = textBox1.Text;

            if (textBox1.Text.Length <= 0 || int.TryParse(textBox1.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập một món ăn hợp lệ", "Cảnh báo");
                return;
            }
            else
            {
                // Split the RichTextBox's text into lines using Environment.NewLine
                string[] lines = richTextBox1.Lines;


                // Check if the text from textBox1 already exists in the lines
                if (lines.Contains(newText))
                {
                    // If it does, show a warning message
                    MessageBox.Show("Món ăn đã tồn tại trong danh sách", "Cảnh báo");
                    return;
                }
                else
                {
                    // Check if the last character of richTextBox1's text is not a newline character
                    if (richTextBox1.Text.Length == 0 || richTextBox1.Text[richTextBox1.Text.Length - 1] != '\n')
                    {
                        // If not, append a newline character before appending newText
                        richTextBox1.AppendText("\n");
                    }

                    // Append newText to richTextBox1
                    richTextBox1.AppendText(newText);
                }
            }
        }
        public string GetRandomLine(RichTextBox richTextBox)
        {
            // Split the RichTextBox's text into lines using Environment.NewLine
            string[] lines = richTextBox1.Lines;

            // Check if there are any lines
            if (lines.Length == 0)
            {
                return "";
            }

            // Create a new instance of Random
            Random random = new Random();

            // Generate a random index within the bounds of the array
            int randomIndex = random.Next(lines.Length);

            // Return the line at the randomly selected index
            return lines[randomIndex];
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Find the last newline character
            int lastNewLineIndex = richTextBox1.Text.LastIndexOf('\n');

            // If a newline character is found, remove everything from the last newline to the end
            if (lastNewLineIndex >= 0)
            {
                richTextBox1.Text = richTextBox1.Text.Remove(lastNewLineIndex);
            }
            else
            {
                // If no newline character is found, clear the entire text
                richTextBox1.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string random_item = GetRandomLine(richTextBox1);

            if (random_item == "")
            {
                MessageBox.Show("Không tìm thấy món ăn để chọn!", "Lỗi");
                return;
            }

            textBox2.Text = random_item;
        }
    }
}
