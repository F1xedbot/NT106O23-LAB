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
    public partial class BAI2 : Form
    {
        public BAI2()
        {
            InitializeComponent();
        }

        // Class to hold file information
        public class FileInformation
        {
            public string FileName { get; set; }
            public long Size { get; set; }
            public string TrueURL { get; set; }
            public string FileContent { get; set; }
            public int LineCount { get; set; }
            public int CharactersCount { get; set; }
            public int WordsCount { get; set; }
        }

        // Function to get file information
        private FileInformation GetFileInfo(string filePath)
        {
            FileInformation fileInfo = new FileInformation();
            fileInfo.FileName = Path.GetFileName(filePath);
            fileInfo.Size = new FileInfo(filePath).Length;
            fileInfo.TrueURL = Path.GetFullPath(filePath);
            fileInfo.FileContent = File.ReadAllText(filePath, Encoding.UTF8);
            fileInfo.LineCount = fileInfo.FileContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            fileInfo.CharactersCount = fileInfo.FileContent.Length;
            fileInfo.WordsCount = fileInfo.FileContent.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            return fileInfo;
        }

        private void BAI2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            openFileDialog.FileName = "input2.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }

            try
            { 
                // Call the function to get file information
                FileInformation fileInfo = GetFileInfo(filePath);

                // Set the content of the RichTextBox
                richTextBox1.Text = fileInfo.FileContent;

                // Display other file information
                file_name.Text = fileInfo.FileName;
                file_size.Text = fileInfo.Size.ToString() + " bytes";
                file_url.Text = fileInfo.TrueURL;
                file_line_count.Text = fileInfo.LineCount.ToString();
                file_word_count.Text = fileInfo.WordsCount.ToString();
                file_char_count.Text = fileInfo.CharactersCount.ToString();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file reading
                MessageBox.Show("An error occurred while reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
