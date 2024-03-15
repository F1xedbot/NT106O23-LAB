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
    public partial class BAI3_1 : Form
    {
        public BAI3_1()
        {
            InitializeComponent();
        }


        private string NumTranslate(string so)
        {
            string[] hang_tram = { "không trăm", "một trăm", "hai trăm", "ba trăm", "bốn trăm", "năm trăm", "sáu trăm", "bảy trăm", "tám trăm", "chín trăm" };
            string[] hang_muoi = { "lẻ", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };
            string[] hang_donvi = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

            if (so == "000000000000")
                return "không";

            string part1 = so.Substring(0, 3);
            string part2 = so.Substring(3, 3);
            string part3 = so.Substring(6, 3);
            string part4 = so.Substring(9);

            string Reading(string num, string indicator)
            {
                string res = "";
                if (int.Parse(num[2].ToString()) == 0)
                {
                    if (int.Parse(num[1].ToString()) != 0)
                        res += hang_tram[int.Parse(num[0].ToString())] + " " + hang_muoi[int.Parse(num[1].ToString())] + " " + indicator;
                    else
                        res += hang_tram[int.Parse(num[0].ToString())] + " " + indicator;
                }
                else
                    res += hang_tram[int.Parse(num[0].ToString())] + " " + hang_muoi[int.Parse(num[1].ToString())] + " " + hang_donvi[int.Parse(num[2].ToString())] 
                        + " " + indicator;
                return res;
            }
            string returnedString = "";
            if (part1 != "000")
                returnedString += Reading(part1, "tỉ") + " ";
            if (part2 != "000" || part1 != "000")
                returnedString += Reading(part2, "triệu") + " ";
            if (part3 != "000" || part2 != "000")
                returnedString += Reading(part3, "ngàn") + " ";
            if (part4 != "000" || part3 != "000")
                returnedString += Reading(part4, "");
            return returnedString.Trim();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (!long.TryParse(textBox1.Text, out _))
                {
                    MessageBox.Show("Vui lòng nhập số nguyên", "Cảnh báo");
                }
                else
                {
                    string input = textBox1.Text;
                    string result = "";
                    if (input.Length == 13 && input[0] == '-')
                    {
                        string numberPart = input.Substring(1); // Extract the number part
                        result = "âm" + ' ' + NumTranslate(numberPart);
                        textBox2.Text = result;
                    }
                    else if (input.Length == 12)
                    {
                        result = NumTranslate(input);
                        textBox2.Text = result;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng 12 chữ số", "Cảnh báo");
                    }
                }
            }
        }
    }
}
