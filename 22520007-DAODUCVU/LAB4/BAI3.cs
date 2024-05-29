using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace LAB4
{
    public partial class BAI3 : Form
    {
        public BAI3()
        {
            InitializeComponent();
            webView21.EnsureCoreWebView2Async();
            webView21.ExecuteScriptAsync("window.scroll(0,300);");
        }

        private void LoadPage(string urlString)
        {
            Uri uri = new Uri(urlString);
            webView21.Source = new Uri(uri.AbsoluteUri);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                LoadPage(textBox1.Text);
                webView21.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                LoadPage(textBox1.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                string viewSourceUrl = "view-source:" + textBox1.Text;
                LoadPage(viewSourceUrl);
                webView21.Refresh();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string path = "https://uit.edu.vn/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(textBox1.Text);
            HtmlNode[] nodes = htmlDoc.DocumentNode.SelectNodes("//img").ToArray();
            foreach (HtmlNode item in nodes)
            {
                var tmp = item.Attributes["src"].Value;

                if (!tmp.Contains("https"))
                {
                    tmp = path + tmp;
                }
                if (tmp.Contains(".png"))
                {
                    using (WebClient client = new WebClient())
                    {

                        string[] link = tmp.Split('/');
                        string fileName = link.Last();
                        if (fileName.Contains('?'))
                        {
                            var index = fileName.IndexOf("?");
                            fileName = fileName.Substring(0, index);
                        }
                        client.DownloadFile(new Uri(tmp), @"../../../Images/" + fileName);

                    }
                }
            }
        }
    }
}
