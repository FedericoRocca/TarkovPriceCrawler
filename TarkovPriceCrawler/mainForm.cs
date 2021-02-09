using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net.Http;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using TarkovCrawler;

namespace TarkovPriceCrawler
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            startCrawl(dgvPrecios);
        }

        private static async Task startCrawl(DataGridView dgvPrecios)
        {
            string url = "https://www.escapefromtarkov.com/preorder-page";
            HttpClient client = new HttpClient();
            string html = await client.GetStringAsync(url);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            List<preciosCrawler> precios = new List<preciosCrawler>();

            var spans = htmlDoc.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("itemprop", "").Equals("price")).ToList();
            foreach (var span in spans)
            {
                preciosCrawler aux = new preciosCrawler();
                aux.setPrecio(span.InnerHtml);
                precios.Add(aux);
            }

            var imgs = htmlDoc.DocumentNode.Descendants("img").Where(node => node.GetAttributeValue("alt", "").Contains("Edition")).ToList();
            int c = 0;
            foreach (var img in imgs)
            {
                precios[c].setEdition(img.GetAttributeValue("alt", ""));
                c++;
                preciosCrawler aux2 = new preciosCrawler();
            }

            foreach(preciosCrawler precio in precios)
            {
                dgvPrecios.Rows.Add(precio.getEdition(), precio.getPrecio());
            }
        }
    }
}
