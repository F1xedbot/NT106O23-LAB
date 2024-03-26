using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{

    public partial class BAI3 : Form
    {

        private string inputFileContent = "";
        public BAI3()
        {
            InitializeComponent();
        }

        public class MathExpressionEvaluator
        {
            public static double Evaluate(string expression)
            {
                expression = expression.Replace(" ", "");
                return EvaluateExpression(expression);
            }

            private static double EvaluateExpression(string expression)
            {
                Stack<double> numbers = new Stack<double>();
                Stack<char> operations = new Stack<char>();

                for (int i = 0; i < expression.Length; i++)
                {
                    char c = expression[i];
                    if (c == ' ')
                        continue;

                    if (char.IsDigit(c) || c == '.')
                    {
                        string numStr = c.ToString();

                        while (i + 1 < expression.Length && (char.IsDigit(expression[i + 1]) || expression[i + 1] == '.'))
                        {
                            numStr += expression[i + 1];
                            i++;
                        }

                        double num = double.Parse(numStr, CultureInfo.InvariantCulture);
                        numbers.Push(num);
                    }
                    else if (c == '(')
                    {
                        operations.Push(c);
                    }
                    else if (c == ')')
                    {
                        while (operations.Peek() != '(')
                        {
                            EvaluateOperation(numbers, operations);
                        }
                        operations.Pop(); // Pop the '('
                    }
                    else
                    {
                        while (operations.Count > 0 && GetPrecedence(operations.Peek()) >= GetPrecedence(c))
                        {
                            EvaluateOperation(numbers, operations);
                        }
                        operations.Push(c);
                    }
                }

                while (operations.Count > 0)
                {
                    EvaluateOperation(numbers, operations);
                }

                return numbers.Pop();
            }

            private static void EvaluateOperation(Stack<double> numbers, Stack<char> operations)
            {
                char op = operations.Pop();
                double num2 = numbers.Pop();
                double num1 = numbers.Pop();
                double result = 0;

                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        result = num1 / num2;
                        break;
                }

                numbers.Push(result);
            }

            private static int GetPrecedence(char op)
            {
                if (op == '+' || op == '-')
                    return 1;
                if (op == '*' || op == '/')
                    return 2;
                return 0;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path to your input file
            string filePath = "";
            // Open file dialog to choose input file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Input File";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Path.GetFullPath("../../../Input");
            openFileDialog.FileName = "input3.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }


            // Get only the file name from the full file path
            string inputFileName = Path.GetFileName(filePath);
            label1.Text = "Input file: " + inputFileName;

            try
            {
                // Read the entire content of the file as a string
                inputFileContent = File.ReadAllText(filePath, Encoding.UTF8);

                // Set the content of the RichTextBox
                richTextBox1.Text = inputFileContent;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file reading
                MessageBox.Show("An error occurred while reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool IsInteger(double number)
        {
            return Math.Abs(number % 1) < double.Epsilon * 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inputFileContent != "")
            {
                // Specify the path to your input file
                string savePath = "";
                // Open file dialog to choose input file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Choose Input File";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Path.GetFullPath("../../../Output");
                openFileDialog.FileName = "output3.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savePath = openFileDialog.FileName;
                }

                // Get only the file name from the full file path
                string outputFileName = Path.GetFileName(savePath);
                label2.Text = "Output file: " + outputFileName;

                try
                {
                    // Read all lines from the richTextBox
                    string[] lines = richTextBox1.Lines;
                    using (StreamWriter writer = new StreamWriter(savePath))
                    {
                        // Iterate through each line
                        foreach (string line in lines)
                        {

                            double result = MathExpressionEvaluator.Evaluate(line);

                            string formattedResult;
                            if (IsInteger(result))
                            {
                                formattedResult = ((int)result).ToString();
                            }
                            else
                            {
                                formattedResult = result.ToString("0.0", CultureInfo.InvariantCulture);
                            }

                            // Write the result to the output file
                            writer.WriteLine($"{line} = {formattedResult}");
                        }
                    }
                    MessageBox.Show("Calculation completed. Results written to output3.txt", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    string outputFileContent = File.ReadAllText(savePath, Encoding.UTF8);
                    richTextBox1.Text = outputFileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nothing to calculate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
