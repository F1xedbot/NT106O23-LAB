using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LAB2.BAI4;

namespace LAB2
{
    public partial class BAI4 : Form
    {
        public BAI4()
        {
            InitializeComponent();
        }

        [Serializable]
        public class Student
        {
            public string FullName { get; set; }
            public int MSSV { get; set; }
            public string PhoneNumber { get; set; }
            public float Grade1 { get; set; }
            public float Grade2 { get; set; }
            public float Grade3 { get; set; }
            public float AverageGrade { get; set; }
        }

        // Declare a HashSet to store unique IDs
        HashSet<string> addedIds = new HashSet<string>();

        // Declare students array
        Student[] inputStudents = new Student[0];

        Student[] outputStudents = new Student[0];

        int currentStudentIndex = 0;
        int studentsListLength = 0;

        private void BAI4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if inputStudents contains any data
            if (inputStudents == null || inputStudents.Length == 0)
            {
                MessageBox.Show("No student data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Open file dialog to choose JSON file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save As";
            saveFileDialog.InitialDirectory = Path.GetFullPath("../../../Output");
            saveFileDialog.FileName = "output4.json";
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // If the file already exists, read the existing data
                    if (File.Exists(filePath))
                    {
                        string fileContent = File.ReadAllText(filePath);
                        Student[] existingStudents = JsonSerializer.Deserialize<Student[]>(fileContent);

                        // Concatenate inputStudents with existingStudents
                        inputStudents = existingStudents.Concat(inputStudents).ToArray();
                    }

                    // Serialize the updated array of students to JSON
                    string jsonString = JsonSerializer.Serialize(inputStudents, new JsonSerializerOptions { WriteIndented = true });

                    // Write the serialized JSON string to the file
                    File.WriteAllText(filePath, jsonString);

                    MessageBox.Show("File saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameInput.Text) || string.IsNullOrEmpty(idInput.Text) || string.IsNullOrEmpty(phoneInput.Text)
                || string.IsNullOrEmpty(c1Input.Text) || string.IsNullOrEmpty(c2Input.Text) || string.IsNullOrEmpty(c3Input.Text))
            {
                MessageBox.Show("Cannot add insufficent data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the ID input is exactly 8 characters and can be parsed to an integer
            if (idInput.Text.Length != 8 || !int.TryParse(idInput.Text, out _))
            {
                MessageBox.Show("Please enter a valid 8-digit ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the phone number input is exactly 10 characters, starts with '0', and can be parsed to a long integer
            if (phoneInput.Text.Length != 10 || phoneInput.Text[0] != '0' || !long.TryParse(phoneInput.Text, out _))
            {
                MessageBox.Show("Please enter a valid 10-digit phone number starting with '0'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if c1Input text can be parsed to an integer and is within the range of 0 to 10 (inclusive)
            if (!int.TryParse(c1Input.Text, out int c1) || c1 < 0 || c1 > 10)
            {
                MessageBox.Show("Please enter a valid grade (0 to 10) for course 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if c2Input text can be parsed to an integer and is within the range of 0 to 10 (inclusive)
            if (!int.TryParse(c2Input.Text, out int c2) || c2 < 0 || c2 > 10)
            {
                MessageBox.Show("Please enter a valid grade (0 to 10) for course 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if c3Input text can be parsed to an integer and is within the range of 0 to 10 (inclusive)
            if (!int.TryParse(c3Input.Text, out int c3) || c3 < 0 || c3 > 10)
            {
                MessageBox.Show("Please enter a valid grade (0 to 10) for course 3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the ID is already added
            if (addedIds.Contains(idInput.Text))
            {
                MessageBox.Show("Duplicate ID. Please enter a unique ID.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method early if duplicate ID is found
            }

            // Add data to the RichTextBox
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.AppendText("\n\n");
            }
            richTextBox1.AppendText(nameInput.Text + '\n');
            richTextBox1.AppendText(idInput.Text + '\n');
            richTextBox1.AppendText(phoneInput.Text + '\n');
            richTextBox1.AppendText(c1Input.Text + '\n');
            richTextBox1.AppendText(c2Input.Text + '\n');
            richTextBox1.AppendText(c3Input.Text);

            // Add the ID to the HashSet
            addedIds.Add(idInput.Text);

            // Create a new student instance
            Student newStudent = new Student
            {
                FullName = nameInput.Text,
                MSSV = int.Parse(idInput.Text),
                PhoneNumber = phoneInput.Text,
                Grade1 = float.Parse(c1Input.Text),
                Grade2 = float.Parse(c2Input.Text),
                Grade3 = float.Parse(c3Input.Text)
            };

            // Calculate average grade
            newStudent.AverageGrade = (newStudent.Grade1 + newStudent.Grade2 + newStudent.Grade3) / 3f;

            // Append the new student to the students array
            Array.Resize(ref inputStudents, inputStudents.Length + 1);
            inputStudents[inputStudents.Length - 1] = newStudent;

            // Clear input fields
            nameInput.Clear();
            idInput.Clear();
            phoneInput.Clear();
            c1Input.Clear();
            c2Input.Clear();
            c3Input.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Clear input fields
            nameInput.Clear();
            idInput.Clear();
            phoneInput.Clear();
            c1Input.Clear();
            c2Input.Clear();
            c3Input.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Open file dialog to choose input file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Choose Input File";
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Read the JSON file content
                    string fileContent = File.ReadAllText(openFileDialog.FileName);

                    // Deserialize the JSON content into an array of Student objects
                    outputStudents = JsonSerializer.Deserialize<Student[]>(fileContent);
                    studentsListLength = outputStudents.Length;

                    if (studentsListLength > 0)
                    {
                        currentStudentIndex = 0;
                        setVisualize(outputStudents[currentStudentIndex]);
                        MessageBox.Show("Students data loaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No student data found in the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (JsonException)
            {
                MessageBox.Show("Error reading JSON data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setVisualize(Student student)
        {
            if (student == null)
            {
                MessageBox.Show("Error reading Student data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nameOutput.Text = student.FullName;
            idOutput.Text = student.MSSV.ToString();
            phoneOutput.Text = student.PhoneNumber.ToString();
            c1Output.Text = student.Grade1.ToString();
            c2Output.Text = student.Grade2.ToString();
            c3Output.Text = student.Grade3.ToString();
            averageOutput.Text = student.AverageGrade.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (outputStudents != null && currentStudentIndex < studentsListLength - 1)
            {
                currentStudentIndex++;
                setVisualize(outputStudents[currentStudentIndex]);
                int labelCountText = currentStudentIndex + 1;
                labelCount.Text = labelCountText.ToString();
            }
            else
            {
                MessageBox.Show("Out of range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (outputStudents != null && currentStudentIndex > 0)
            {
                currentStudentIndex--;
                setVisualize(outputStudents[currentStudentIndex]);
                int labelCountText = currentStudentIndex + 1;
                labelCount.Text = labelCountText.ToString();
            }
            else
            {
                MessageBox.Show("Out of range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
