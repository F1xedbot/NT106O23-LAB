namespace WinFormsApp1
{
    public partial class BAI1 : Form
    {
        public BAI1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inputbox_1_TextChanged(object sender, EventArgs e)
        {
            // Check if the TextBox has any input
            if (!string.IsNullOrWhiteSpace(inputbox_1.Text))
            {
                // Check if the text can be parsed as an integer
                if (!int.TryParse(inputbox_1.Text, out _))
                {
                    // Display a message box if the text is not an integer
                    MessageBox.Show("Vui lòng nhập số nguyên", "Cảnh báo");
                    // Clear the input
                    inputbox_1.Text = "";
                }
            }
            if (checkIfSufficientInputs(inputbox_1.Text, inputbox_2.Text))
            {
                // Parse input text as int
                int num1 = int.Parse(inputbox_1.Text);
                int num2 = int.Parse(inputbox_2.Text);
                int sum = num1 + num2;
                // Show result on result text box
                result_box.Text = sum.ToString();
            }

        }

        private bool checkIfSufficientInputs(string input1, string input2)
        {
            // If both textbox has some inputs
            return (!string.IsNullOrWhiteSpace(inputbox_2.Text) && !string.IsNullOrWhiteSpace(inputbox_1.Text));
        }

        private void inputbox_2_TextChanged(object sender, EventArgs e)
        {
            // Check if the TextBox has any input
            if (!string.IsNullOrWhiteSpace(inputbox_2.Text))
            {
                // Check if the text can be parsed as an integer
                if (!int.TryParse(inputbox_2.Text, out _))
                {
                    // Display a message box if the text is not an integer
                    MessageBox.Show("Vui lòng nhập số nguyên", "Cảnh báo");
                    // Clear the input
                    inputbox_2.Text = "";
                }
            }

            if (checkIfSufficientInputs(inputbox_1.Text, inputbox_2.Text))
            {
                // Parse input text as int
                int num1 = int.Parse(inputbox_1.Text);
                int num2 = int.Parse(inputbox_2.Text);
                int sum = num1 + num2;
                // Show result on result text box
                result_box.Text = sum.ToString();
            }
        }

        private void result_box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
