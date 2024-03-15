using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class BAI7 : Form
    {
        public BAI7()
        {
            InitializeComponent();
        }


        private (string name, double[] values) ParseAndValidateInput(string input)
        {
            string[] parts = input.Split(',');

            // Check if the first part is not a double (which means it's text)
            if (!double.TryParse(parts[0], out _))
            {
                // The first part is text, so we proceed to check the rest
                List<double> doubleValues = new List<double>();
                for (int i = 1; i < parts.Length; i++)
                {
                    if (double.TryParse(parts[i], NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    {
                        doubleValues.Add(value);
                    }
                    else
                    {
                        // If any part after the first is not a double, return an error
                        return("Lỗi: Dữ liệu đầu vào không đúng định dạng, dữ liệu phải bắt đầu bằng một dãy kí tự và theo sau là các số", new double[0]);
                    }
                }
                string text = parts[0];
                double[] doubleArray = doubleValues.ToArray();
                // Return the parsed values
                return (text, doubleArray);
            }
            else
            {
                // If the first part is a double, return an error
                return ("Lỗi: Dữ liệu đầu vào không đúng định dạng, dữ liệu phải bắt đầu bằng một dãy kí tự và theo sau là các số", new double[0]);
            }
        }

        private string EvaluateValues(double[] values, double mean)
        {

            bool noValuesBelowSixPointFive = !values.Any(v => v < 6.5);
            bool noValuesBelowFive = !values.Any(v => v < 5);
            bool noValuesBelowThreePointFive = !values.Any(v => v < 3.5);
            bool noValuesBelowTwo = !values.Any(v => v < 2);

            if (mean >= 8 && noValuesBelowSixPointFive)
            {
                return "Giỏi";
            }
            else if (mean >= 6.5 && noValuesBelowFive)
            {
                return "Khá";
            }
            else if (mean >= 5 && noValuesBelowThreePointFive)
            {
                return "TB";
            }
            else if (mean >= 3.5 && noValuesBelowTwo)
            {
                return "Yếu";
            }
            else
            {
                return "Kém";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the TextBox has any input
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string input = textBox1.Text;
                var result = ParseAndValidateInput(input);
                if (result.name.StartsWith("Lỗi:"))
                {
                    // There was an error during parsing and validation
                    MessageBox.Show(result.name, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Parsing and validation were successful
                    string name = result.name;
                    double[] values = result.values;

                    textBox9.Text = name;

                    // Diem cac mon
                    string formattedScores = "";
                    for (int i = 0; i < values.Length; i++)
                    {
                        formattedScores += $"Môn {i + 1}: {values[i]} ";
                    }
                    textBox2.Text = formattedScores;

                    // TB, Max, Min
                    double sum = values.Sum();
                    double mean = sum / values.Length;
                    double highest = values.Max();
                    double lowest = values.Min();

                    // Convert the calculated values to strings
                    string meanStr = mean.ToString("F2"); // Format with 2 decimal places
                    string highestStr = highest.ToString("F2"); // Format with 2 decimal places
                    string lowestStr = lowest.ToString("F2"); // Format with 2 decimal places

                    textBox3.Text = meanStr;
                    textBox4.Text = highestStr;
                    textBox5.Text = lowestStr;

                    // So mon rot, dau

                    int countBelowFive = 0;
                    int countAboveFive = 0;

                    foreach (double value in values)
                    {
                        if (value < 5)
                        {
                            countBelowFive++;
                        }
                        else if (value > 5)
                        {
                            countAboveFive++;
                        }
                    }

                    string countAboveFiveStr = countAboveFive.ToString();
                    string countBelowFiveStr = countBelowFive.ToString();

                    textBox6.Text = countAboveFiveStr;
                    textBox7.Text = countBelowFiveStr;

                    string evaluateResult = EvaluateValues(values, mean);

                    textBox8.Text = evaluateResult;
                }
            }
        }
    }
}
