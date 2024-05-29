using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace LAB4
{
    public partial class BAI4 : Form
    {
        public string forkUrl = "https://betacinemas.vn";
        public BAI4()
        {
            InitializeComponent();
            FetchAndSaveFilmDataAsync(forkUrl + "/phim.htm");
        }

        private void PopulateFilmData(List<Dictionary<string, object>> data)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var filmData in data)
            {
                FilmItem filmItem = new FilmItem();
                filmItem.ImageUrl = filmData.ContainsKey("image") ? filmData["image"].ToString() : "No image found";
                filmItem.FilmTitle = filmData["linkText"].ToString();
                filmItem.FilmDescription = filmData["link"].ToString();
                flowLayoutPanel1.Controls.Add(filmItem);
            }

        }
        public async Task FetchAndSaveFilmDataAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string htmlContent = await client.GetStringAsync(url);

                    var document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(htmlContent);

                    var xpathFilmInfoQueryDivs = "//div[@class='film-info film-xs-info']";
                    var divFilmInfoNodes = document.DocumentNode.SelectNodes(xpathFilmInfoQueryDivs);

                    var xpathFilmMetadataQueryDivs = "//div[@class='pi-img-wrapper']";
                    var divFilmMetadataNodes = document.DocumentNode.SelectNodes(xpathFilmMetadataQueryDivs);

                    var filmDataArray = new List<Dictionary<string, object>>();

                    if (divFilmInfoNodes != null && divFilmInfoNodes.Count > 0)
                    {
                        foreach (var divNode in divFilmInfoNodes)
                        {
                            var anchorNodes = divNode.SelectNodes(".//a");

                            if (anchorNodes != null && anchorNodes.Count > 0)
                            {
                                foreach (var anchorNode in anchorNodes)
                                {
                                    string linkText = anchorNode.InnerText.Trim();
                                    string hrefValue = anchorNode.GetAttributeValue("href", string.Empty).Trim();

                                    var filmDataItem = new Dictionary<string, object>
                                    {
                                        ["linkText"] = linkText,
                                        ["link"] = forkUrl  + hrefValue
                                    };

                                    filmDataArray.Add(filmDataItem);
                                }
                            }
                        }
                    }

                    if (divFilmMetadataNodes != null && divFilmMetadataNodes.Count > 0)
                    {
                        for (int i = 0; i < divFilmMetadataNodes.Count; i++)
                        {
                            var divNode = divFilmMetadataNodes[i];
                            var imageNode = divNode.SelectSingleNode(".//img");

                            if (imageNode != null)
                            {
                                // Directly access the filmDataItem by its index
                                var filmDataItem = filmDataArray[i];
                                string srcValues = imageNode.GetAttributeValue("src", string.Empty).Trim();
                                filmDataItem["image"] = srcValues; // Associate the image source with the current filmDataItem
                            }
                        }
                    }

                    PopulateFilmData(filmDataArray);

                    // Serialize the list to a JSON string
                    JsonSerializerOptions jso = new JsonSerializerOptions { WriteIndented = true };
                    jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

                    string json = JsonSerializer.Serialize(filmDataArray, jso);

                    // Save the JSON string to a file
                    string filePath = Path.Combine(@"../../../Sources", "filmData.json");
                    File.WriteAllText(filePath, json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
