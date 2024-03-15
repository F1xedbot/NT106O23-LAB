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
    public partial class BAI4 : Form
    {

        // Define filmData as a class-level field
        private Dictionary<string, Tuple<int, List<int>>> filmData;

        private Dictionary<int, List<string>> ticketMapping;


        // Visual Handler
        private List<System.Windows.Forms.Button> highlightedSeat;
        private int ordered_seat = 0;


        // Ticket Order Handler
        private Dictionary<string, List<Tuple<int, string>>> ticketOrder;


        public BAI4()
        {
            InitializeComponent();
            // Adding a collection of items
            List<string> items = new List<string> { "Đào, phở và piano", "Mai", "Gặp lại chị bầu", "Tarot" };
            comboBox1.Items.AddRange(items.ToArray());
            // Initialize the filmData dictionary
            filmData = new Dictionary<string, Tuple<int, List<int>>>
            {
                { "Đào, phở và piano", new Tuple<int, List<int>>(45000, new List<int> { 1, 2, 3 }) },
                { "Mai", new Tuple<int, List<int>>(100000, new List<int> { 2, 3 }) },
                { "Gặp lại chị bầu", new Tuple<int, List<int>>(70000, new List<int> { 1 }) },
                { "Tarot", new Tuple<int, List<int>>(90000, new List<int> { 3 }) }
            };
            ticketMapping = new Dictionary<int, List<string>>
            {
                {1, new List<string>{"A1", "A5", "C1", "C5"} },
                {2, new List<string>{"A2", "A3", "A4", "C2", "C3", "C4"}},
                {3, new List<string>{"B2", "B3", "B4"}}
            };
            highlightedSeat = new List<System.Windows.Forms.Button> { };
            ticketOrder = new Dictionary<string, List<Tuple<int, string>>> { };
        }

        private void BAI4_Load(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Step 1: Retrieve the selected item's text
            string selectedFilm = comboBox1.SelectedItem.ToString();

            // Step 2: Access the dictionary using the selected item's text
            if (filmData.TryGetValue(selectedFilm, out Tuple<int, List<int>> filmInfo))
            {
                // Step 1: Disable all GroupBoxes
                foreach (Control control in this.Controls)
                {
                    if (control is GroupBox)
                    {
                        ((GroupBox)control).Enabled = false;
                    }
                }
                comboBox2.SelectedIndex = -1;
                comboBox2.Items.Clear();
                textBox4.Text = "";


                // Step 2: Loop through the list of integers
                foreach (int sequenceNumber in filmInfo.Item2)
                {
                    // Construct the name of the GroupBox control
                    string groupBoxName = "groupBox" + sequenceNumber;

                    // Find the GroupBox control by name
                    Control[] groupBoxes = this.Controls.Find(groupBoxName, true);

                    // If the GroupBox control is found, enable it
                    if (groupBoxes.Length > 0 && groupBoxes[0] is GroupBox)
                    {
                        ((GroupBox)groupBoxes[0]).Enabled = true;
                    }
                }

                if (filmInfo.Item2 != null)
                {
                    // Convert each integer in filmInfo.Item2 to a string and add them to comboBox2
                    foreach (int number in filmInfo.Item2)
                    {
                        comboBox2.Items.Add(number.ToString());
                    }
                }

                textBox3.Text = selectedFilm;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == -1)
            {
                return;
            }

            comboBox3.SelectedIndex = -1;
            comboBox3.Items.Clear();
            textBox6.Text = "";

            // Adding a collection of items
            List<string> items = new List<string> { "A1", "A2", "A3", "A4", "A5",
            "B1", "B2", "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5"};
            comboBox3.Items.AddRange(items.ToArray());

            textBox4.Text = comboBox2.SelectedItem.ToString();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                return;
            }

            string selectedItem = comboBox3.SelectedItem.ToString();

            int ticket_type = 0;

            // Iterate through the ticketMapping dictionary
            foreach (var entry in ticketMapping)
            {
                // Check if the selected item is in the current list
                if (entry.Value.Contains(selectedItem))
                {
                    // If found, save the key (value in ticketMapping)
                    ticket_type = entry.Key;
                    break; // Exit the loop once the item is found
                }
            }

            string selectedFilm = comboBox1.SelectedItem.ToString();
            filmData.TryGetValue(selectedFilm, out Tuple<int, List<int>> filmInfo);


            double price = filmInfo.Item1;

            switch (ticket_type)
            {
                case 1:
                    { price *= 0.5; };
                    break;
                case 3:
                    { price *= 2; };
                    break;
                default:
                    { };
                    break;
            }
            textBox6.Text = price.ToString();


            // Step 1: Retrieve the selected item's text
            string selectedSequence = comboBox2.SelectedItem.ToString();

            // Construct the name of the GroupBox control
            string buttonName = selectedItem + "_" + selectedSequence;


            // Find the button by name
            Control[] foundControls = this.Controls.Find(buttonName, true);

            // Check if the button was found
            if (foundControls.Length > 0 && foundControls[0] is System.Windows.Forms.Button)
            {
                // Cast the found control to a Button and change its background color to blue
                System.Windows.Forms.Button foundButton = foundControls[0] as System.Windows.Forms.Button;

                if (foundButton.BackColor == Color.IndianRed)
                {
                    // Display a message box if the text is not an integer
                    MessageBox.Show("Ghế này đã có người đặt", "Cảnh báo");
                    comboBox3.SelectedIndex = -1;
                }
                else
                {
                    foundButton.BackColor = Color.LightBlue;
                    highlightedSeat.Add(foundButton);

                    if (highlightedSeat.Count > ordered_seat + 1)
                    {
                        highlightedSeat[ordered_seat].BackColor = Color.White;
                        highlightedSeat.RemoveAt(ordered_seat);
                    }
                    textBox5.Text = selectedItem;
                }
            }
            else
            {
                // Handle the case where the button was not found
                Console.WriteLine($"Button '{buttonName}' not found.");
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0)
            {
                string username = textBox1.Text;
                int theater_number = int.Parse(textBox4.Text);
                string seat_id = textBox5.Text;

                Tuple<int, string> seatInfo = new Tuple<int, string>(theater_number, seat_id);

                // Check if the username already exists in the ticketOrder dictionary
                if (ticketOrder.ContainsKey(username))
                {
                    // Retrieve the existing list of seat information for the user
                    List<Tuple<int, string>> userSeats = ticketOrder[username];

                    // Check if the user has already booked a seat in the same theater for the same movie
                    bool sameTheaterBooked = userSeats.Any(s => s.Item1 == theater_number);

                    if (sameTheaterBooked)
                    {
                        // If the user has already booked a seat in the same theater, add the new seat information
                        userSeats.Add(seatInfo);
                        highlightedSeat[ordered_seat].BackColor = Color.IndianRed;
                    }
                    else
                    {
                        // If the user tries to book a seat in a different theater for the same movie, show a warning
                        MessageBox.Show("Bạn không thể đặt ghế ở 2 rạp chiếu khác nhau", "Cảnh báo");
                        return;
                    }
                }
                else
                {
                    // If the username does not exist in the ticketOrder dictionary, add a new entry
                    ticketOrder[username] = new List<Tuple<int, string>> { seatInfo };
                    highlightedSeat[ordered_seat].BackColor = Color.IndianRed;
                }

                // Display a message box if the text is not an integer
                MessageBox.Show("Bạn đã đặt vé thành công !");

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";


                foreach (Control control in this.Controls)
                {
                    if (control is GroupBox)
                    {
                        ((GroupBox)control).Enabled = false;
                    }
                }

                textBox1.Text = "";

                comboBox2.SelectedIndex = -1;
                comboBox2.Items.Clear();

                comboBox3.SelectedIndex = -1;
                comboBox3.Items.Clear();

                ordered_seat += 1;

            }
            else
            {
                // Display a message box if the text is not an integer
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }
    }
}
