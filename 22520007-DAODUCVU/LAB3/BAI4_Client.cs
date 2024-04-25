using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using static LAB3.BAI4_Dashboard;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB3
{
    public partial class BAI4_Client : Form
    {
        public BAI4_Client()
        {
            InitializeComponent();

            // Set up the ListView control
            listView1.View = View.Details;
            listView1.FullRowSelect = true; // Enable full row selection
            listView1.CheckBoxes = true; // Enable checkboxes if needed

            // Add columns
            listView1.Columns.Add("All Seats", -2);

            // Create and add groups
            listView1.Groups.Add(vipGroup);
            listView1.Groups.Add(standardGroup);
            listView1.Groups.Add(economyGroup);
        }

        private TcpClientManager tcpClientManager;
        private Theater[] theaters;
        private List<string> occupiedSeatIds = new List<string>();
        private Dictionary<string, int> filmData = new Dictionary<string, int>();

        ListViewGroup vipGroup = new ListViewGroup("VIP", HorizontalAlignment.Left);
        ListViewGroup standardGroup = new ListViewGroup("Standard", HorizontalAlignment.Left);
        ListViewGroup economyGroup = new ListViewGroup("Economy", HorizontalAlignment.Left);

        // Create a HashSet to store the previously checked items
        HashSet<ListViewItem> previouslyCheckedItems = new HashSet<ListViewItem>();
        private int total = 0;

        private void BAI4_Client_Load(object sender, EventArgs e)
        {
            // Prefetch film data
            filmData["Godzilla"] = 75000;
            filmData["Kung Fu Panda 4"] = 50000;
            filmData["Dune 2"] = 120000;

            comboBoxFilms.Items.Clear();
            comboBoxTheaters.Items.Clear();

            // Iterate over the keys in filmData and add them to the combo box
            foreach (string film in filmData.Keys)
            {
                comboBoxFilms.Items.Add(film);
            }
            comboBoxFilms.SelectedIndex = 0;
            payoutOutput.Text = total.ToString();

            tcpClientManager = new TcpClientManager();
            tcpClientManager.ConnectionStatusChanged += HandleConnectionStatusChanged;
            tcpClientManager.DataReceived += HandleDataReceived;

            if (!tcpClientManager.IsConnected())
            {
                if (tcpClientManager.Connect("127.0.0.1", 8080))
                {
                    tcpClientManager.Send("get");
                }
            }
        }

        private void populateOccupiedSeats()
        {
            occupiedSeatIds.Clear();
            foreach (Theater theater in theaters)
            {
                foreach (Seat seat in theater.S)
                {
                    if (seat.O)
                    {
                        occupiedSeatIds.Add(theater.T + seat.S);
                    }
                }
            }

            total = 0;
            payoutOutput.Text = total.ToString();
            seatOutput.Clear();
            previouslyCheckedItems.Clear();
        }

        private void renderListView(int index)
        {
            // Clear existing items in the ListView
            listView1.Items.Clear();

            // Iterate over each seat in the theater
            foreach (var seat in theaters[index].S)
            {
                ListViewItem item = new ListViewItem(seat.S); // Initialize the ListViewItem with the seat number

                // Check if the seat is VIP (State: 1)
                if (seat.St == 1)
                {
                    item.Group = vipGroup; // Assign the item to the VIP group
                }
                else if (seat.St == 0)
                {
                    item.Group = standardGroup; // Assign the item to the Standard group
                }
                else if (seat.St == 2)
                {
                    item.Group = economyGroup; // Assign the item to the Economy group
                }

                // Check if the seat is occupied (seat.O == true)
                if (seat.O)
                {
                    // Set the item to red and checked
                    item.ForeColor = Color.Red; // Set the text color to red
                    item.Checked = true; // Check the item
                }

                // Add the ListViewItem to the ListView
                listView1.Items.Add(item);
            }

        }

        private void HandleDataReceived(object sender, string receivedData)
        {
            // If the received message contains JSON data, deserialize it
            if (receivedData.StartsWith("["))
            {
                try
                {
                    theaters = JsonSerializer.Deserialize<Theater[]>(receivedData);
                    comboBoxTheaters.DataSource = theaters.Select(t => t.T).ToList();
                    comboBoxTheaters.SelectedIndex = 0;
                    renderListView(comboBoxTheaters.SelectedIndex);
                    populateOccupiedSeats();
                }
                catch (JsonException ex)
                {
                    MessageBox.Show("Error deserializing JSON data: " + ex.Message);
                }
            }
        }

        private void HandleConnectionStatusChanged(object sender, string message)
        {
            Console.WriteLine(message);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            tcpClientManager.Disconnect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"The total is {total}, Confirm Order?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;


            // Create a list to hold the selected seat texts
            List<string> selectedSeats = new List<string>();

            int theaterIndex = -1; // Initialize with -1 to indicate not found

            foreach (var theater in theaters)
            {
                if (theater.T == comboBoxTheaters.Text)
                {
                    theaterIndex = theaters.ToList().IndexOf(theater);
                    break; // Exit the loop once the theater is found
                }
            }


            // Assuming listView1 is your ListView and it has checkboxes enabled
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked && !occupiedSeatIds.Contains(comboBoxTheaters.Text + item.Text))
                {
                    selectedSeats.Add(item.Text);
                }
            }

            // Manually construct the JSON string
            string jsonString = $"update {{\"T\":\"{comboBoxTheaters.Text}\", \"S\":[{string.Join(", ", selectedSeats.Select(s => $"\"{s}\""))}]}}";

            // Send the JSON string
            tcpClientManager.Send(jsonString);
        }

        private void comboBoxTheaters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxTheaters.SelectedIndex;
            renderListView(index);
            if (index != -1)
            {
                theaterOutput.Text = comboBoxTheaters.Items[index].ToString();
                seatOutput.Clear();
                previouslyCheckedItems.Clear();
                total = 0;
                payoutOutput.Text = total.ToString();
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private int calculateTotalPayout(string film, ListViewItem seat)
        {
            int basePrice = filmData[film];
            if (seat.Group.Header == "VIP")
            {
                basePrice *= 2;
            }
            else if (seat.Group.Header == "Economy")
            {
                basePrice /= 2;
            }

            return basePrice;
        }

        private void comboBoxFilms_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxFilms.SelectedIndex;
            if (index != -1)
            {
                filmOutput.Text = comboBoxFilms.Items[index].ToString();
                seatOutput.Clear();
                previouslyCheckedItems.Clear();
                total = 0;
                payoutOutput.Text = total.ToString();
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // Get the ListViewItem that was checked or unchecked
            ListViewItem item = e.Item;

            // Access the Text property of the ListViewItem
            string itemText = item.Text;

            // Check if the item's text is in the occupiedSeatIds collection
            if (occupiedSeatIds.Contains(comboBoxTheaters.Text + itemText))
            {
                // If the item is already occupied, prevent unchecking
                e.Item.Checked = true;
            }
            else
            {
                // If the item is not occupied, update the total payout accordingly
                if (e.Item.Checked && !previouslyCheckedItems.Contains(item))
                {
                    // If the item is checked for the first time, add to the total payout
                    total += calculateTotalPayout(filmOutput.Text, item);
                    seatOutput.Text += itemText + " ";

                    // Add the item to the previouslyCheckedItems collection
                    previouslyCheckedItems.Add(item);
                }
                else if (!e.Item.Checked && previouslyCheckedItems.Contains(item))
                {
                    // If the item is unchecked and was previously checked, subtract from the total payout
                    total -= calculateTotalPayout(filmOutput.Text, item);
                    seatOutput.Text = seatOutput.Text.Replace(itemText + " ", "");

                    // Remove the item from the previouslyCheckedItems collection
                    previouslyCheckedItems.Remove(item);
                }

                // Update the payoutOutput with the new total
                payoutOutput.Text = total.ToString();
            }
        }
    }
}
