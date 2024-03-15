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
    public partial class BAI6 : Form
    {
        public BAI6()
        {
            InitializeComponent();
        }

        public string DetermineZodiacSign(int day, int month)
        {
            string zodiacSign;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                zodiacSign = "Bạch Dương";
            }
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 21))
            {
                zodiacSign = "Kim Ngưu";
            }
            else if ((month == 5 && day >= 22) || (month == 6 && day <= 22))
            {
                zodiacSign = "Song Tử";
            }
            else if ((month == 6 && day >= 23) || (month == 7 && day <= 22))
            {
                zodiacSign = "Cự Giải";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                zodiacSign = "Sư Tử";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 23))
            {
                zodiacSign = "Xử Nữ";
            }
            else if ((month == 9 && day >= 24) || (month == 10 && day <= 23))
            {
                zodiacSign = "Thiên Bình";
            }
            else if ((month == 10 && day >= 24) || (month == 11 && day <= 22))
            {
                zodiacSign = "Thần Nông";
            }
            else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
            {
                zodiacSign = "Nhân Mã";
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 20))
            {
                zodiacSign = "Ma Kết";
            }
            else if ((month == 1 && day >= 21) || (month == 2 && day <= 19))
            {
                zodiacSign = "Bảo Bình";
            }
            else // (month == 2 && day >= 20) || (month == 3 && day <= 20)
            {
                zodiacSign = "Song Ngư";
            }

            return zodiacSign;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Get the selected date from the DateTimePicker
            DateTime selectedDate = dateTimePicker1.Value;

            // Extract the day and month from the selected date
            int day = selectedDate.Day;
            int month = selectedDate.Month;

            // Determine the zodiac sign based on the day and month
            string zodiacSign = DetermineZodiacSign(day, month);

            textBox1.Text = zodiacSign;

        }
    }
}
