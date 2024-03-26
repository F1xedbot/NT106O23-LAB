using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class BAI1 : Form
    {
        private string inputFileContent = "";
        public BAI1()
        {
            InitializeComponent();
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
            openFileDialog.FileName = "input1.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
            try { 
                // Read the entire content of the file as a string
                inputFileContent = File.ReadAllText(filePath, Encoding.UTF8);
                // Set the content of the RichTextBox
                richTextBox1.Text = inputFileContent;

                // Get only the file name from the full file path
                string inputFileName = Path.GetFileName(filePath);

                label1.Text = "Input file: " + inputFileName;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file reading
                MessageBox.Show("An error occurred while reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inputFileContent != "")
            {

                // Specify the path to your output file
                string savePath = "";
                // Open file dialog to choose output file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Choose Output File";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Path.GetFullPath("../../../Output");
                openFileDialog.FileName = "output1.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savePath = openFileDialog.FileName;
                }

                // Get only the file name from the full file path
                string outputFileName = Path.GetFileName(savePath);
                label2.Text = "Output file: " + outputFileName;

                // Convert the content to uppercase
                string uppercaseContent = inputFileContent.ToUpper();

                // Write the uppercase content to the output file
                using (StreamWriter writer = new StreamWriter(savePath, false, Encoding.UTF8))
                {
                    writer.Write(uppercaseContent);
                }

                MessageBox.Show("Content successfully written to " + savePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Nothing to write", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
