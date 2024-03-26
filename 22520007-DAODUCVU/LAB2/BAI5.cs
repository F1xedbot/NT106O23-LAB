using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB2
{
    public partial class BAI5 : Form
    {
        public BAI5()
        {
            InitializeComponent();
        }

        static string statisticsReport = "";
        static string inputStatisticsData = "";
        bool reportView = false;
        public class CinemaStatistics
        {
            public class Movie
            {
                public string Name { get; set; }
                public decimal TicketPrice { get; set; }
                public string CinemaHall { get; set; }
                public int TotalTickets { get; set; }
                public int TicketsSold { get; set; }
                public int VIPTicketsSold { get; set; }
                public int HalfPriceTicketsSold { get; set; }

                // Constructor to initialize properties
                public Movie(string name, decimal ticketPrice, string cinemaHall, int totalTickets, int ticketsSold, int vipTicketsSold, int halfPriceTicketsSold)
                {
                    Name = name;
                    TicketPrice = ticketPrice;
                    CinemaHall = cinemaHall;
                    TotalTickets = totalTickets;
                    TicketsSold = ticketsSold;
                    VIPTicketsSold = vipTicketsSold;
                    HalfPriceTicketsSold = halfPriceTicketsSold;
                }
            }

            // List to store movie information
            private List<Movie> movies = new List<Movie>();

            // Method to add a movie to the list
            public void AddMovie(string name, decimal ticketPrice, string cinemaHall, int totalTickets, int ticketsSold, int vipTicketsSold, int halfPriceTicketsSold)
            {
                movies.Add(new Movie(name, ticketPrice, cinemaHall, totalTickets, ticketsSold, vipTicketsSold, halfPriceTicketsSold));
            }

            // Method to calculate cinema statistics
            public string CalculateStatistics()
            {
                if (movies.Count == 0)
                {
                    return "No movies found.";
                }

                // Generate statistics report
                StringBuilder statisticsReport = new StringBuilder("Cinema Statistics:\n");

                foreach (var movie in movies)
                {
                    // Calculate remaining tickets
                    int remainingTickets = movie.TotalTickets - movie.TicketsSold;

                    // Calculate revenue
                    decimal standardRevenue = movie.TicketsSold * movie.TicketPrice;
                    decimal VIPRevenue = movie.VIPTicketsSold * (movie.TicketPrice * 2); // VIP tickets cost twice the standard price
                    decimal halfPriceRevenue = movie.HalfPriceTicketsSold * (movie.TicketPrice / 2); // Half-price tickets cost half of the standard price
                    decimal totalRevenue = standardRevenue + VIPRevenue + halfPriceRevenue;

                    // Calculate sell-out ratio
                    double sellOutRatio = (double)movie.TicketsSold / movie.TotalTickets;

                    // Append movie statistics to the report
                    statisticsReport.AppendLine($"Movie: {movie.Name}");
                    statisticsReport.AppendLine($"Total Tickets: {movie.TotalTickets}");
                    statisticsReport.AppendLine($"Tickets Sold: {movie.TicketsSold}");
                    statisticsReport.AppendLine($"Remaining Tickets: {remainingTickets}");
                    statisticsReport.AppendLine($"Sell-Out Ratio: {sellOutRatio:P}");
                    statisticsReport.AppendLine($"Standard Revenue: ${standardRevenue}");
                    statisticsReport.AppendLine($"VIP Revenue: ${VIPRevenue}");
                    statisticsReport.AppendLine($"Half-Price Revenue: ${halfPriceRevenue}");
                    statisticsReport.AppendLine($"Total Revenue: ${totalRevenue}");
                    statisticsReport.AppendLine();
                }

                return statisticsReport.ToString();
            }

            // Method to save statistics to a text file
            public void SaveStatisticsToFile(string filePath)
            {
                statisticsReport = CalculateStatistics();
                File.WriteAllText(filePath, statisticsReport);
            }
        }


        private string selectedInputFile = "";

        private void button1_Click(object sender, EventArgs e)
        {
            // Open file dialog to choose input file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Input File";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Path.GetFullPath("../../../Input");
            openFileDialog.FileName = "input5.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedInputFile = openFileDialog.FileName;
            }

            // Get only the file name from the full file path
            string inputFileName = Path.GetFileName(selectedInputFile);
            inputStatisticsData = File.ReadAllText(selectedInputFile);
            inputStatisticsData = "Input File: " + inputFileName + "\n\n" + inputStatisticsData;
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            // Disable the button to prevent multiple calculations
            button2.Enabled = false;
            string outputFileName = "";


            // Save statistics to output file
            string outputPath = "../../../Output/output5.txt";

            // Open file dialog to choose output file
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.Title = "Choose Output File";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = Path.GetFullPath("../../../Output");
            saveFileDialog.FileName = "output5.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputPath = saveFileDialog.FileName;
            }

            if (string.IsNullOrEmpty(outputPath))
            {
                MessageBox.Show("Cannot save statistics to a null file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get only the file name from the full file path
            outputFileName = Path.GetFileName(outputPath);

            // Start the calculation in a separate task
            await Task.Run(() =>
            {
                CinemaStatistics cinemaStats = new CinemaStatistics();

                string[] lines = File.ReadAllLines(selectedInputFile);

                List<List<string>> dataList = new List<List<string>>();
                List<string> currentMovieData = new List<string>();

                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line.Trim()))
                    {
                        // If the line is empty, add the current movie data to dataList
                        if (currentMovieData.Count > 0)
                        {
                            dataList.Add(currentMovieData);
                            currentMovieData = new List<string>(); // Reset currentMovieData for the next movie
                        }
                    }
                    else
                    {
                        // If the line is not empty, add it to the current movie data
                        currentMovieData.Add(line);
                    }
                }

                // Add the last movie data to dataList if it's not already added
                if (currentMovieData.Count > 0)
                {
                    dataList.Add(currentMovieData);
                }

                // Process each movie data and add it to cinemaStats
                foreach (var movieData in dataList)
                {
                    string name = movieData[0].Trim();
                    decimal ticketPrice = decimal.Parse(movieData[1].Trim());
                    string cinemaHall = movieData[2].Trim();
                    int totalTickets = int.Parse(movieData[3].Trim());
                    int ticketSold = int.Parse(movieData[4].Trim());
                    int vipTicketsSold = int.Parse(movieData[5].Trim());
                    int halfTicketsSold = int.Parse(movieData[6].Trim());


                    cinemaStats.AddMovie(name, ticketPrice, cinemaHall, totalTickets, ticketSold, vipTicketsSold, halfTicketsSold);
                }

                cinemaStats.SaveStatisticsToFile(outputPath);

                // Perform your calculation here...
                int totalSteps = 100; // Define the total steps of the calculation
                for (int i = 0; i < totalSteps; i++)
                {
                    // Perform a portion of the calculation
                    // Update the progress bar value
                    UpdateProgressBar(i, totalSteps);

                    // Simulate some work being done
                    System.Threading.Thread.Sleep(25); // Replace this with your actual calculation logic
                }
            });

            // Re-enable the button after the calculation is finished
            button2.Enabled = true;
            statisticsReport = "Output File: " + outputFileName + "\n\n" + statisticsReport;
            richTextBox1.Text = statisticsReport;
            reportView = true;
            MessageBox.Show("Statistics saved to " + outputFileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar1.Value = 0;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateProgressBar(int currentValue, int maxValue)
        {
            // Ensure thread safety when updating UI controls
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = (int)(((double)currentValue / maxValue) * 100)));
            }
            else
            {
                progressBar1.Value = (int)(((double)currentValue / maxValue) * 100);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!reportView) richTextBox1.Text = statisticsReport;
            else richTextBox1.Text = inputStatisticsData;
            reportView = !reportView;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
