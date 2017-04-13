using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Fotoğraf_İndirme_2
{
    public partial class Form1 : Form
    {
        public String html;
        public Uri url;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 17; i++)   
            {
                
                 veriAlDip("http://fotogaleri.hurriyet.com.tr", "//*[@id='form1']/div[4]/div[3]/ul/li[1]/a", "href", listBox1);
                
                
            }

           
        }

        public void veriAl(String URL, String XPath, ListBox gelen)
        {
            try
            {
                url = new Uri(URL);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            catch (ArgumentNullException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }

            }

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                html = client.DownloadString(url);

            }
            catch (WebException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            try
            {
                gelen.Items.Add(doc.DocumentNode.SelectSingleNode(XPath).InnerText);
            }
            catch (NullReferenceException)
            {
                if (MessageBox.Show("Hatalı XPath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
        }

        public void veriAlDip(String URL, String XPath, String dip, ListBox gelen)
        {
            try
            {
                url = new Uri(URL);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            catch (ArgumentNullException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }

            }

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                html = client.DownloadString(url);

            }
            catch (WebException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            try
            {
                gelen.Items.Add(doc.DocumentNode.SelectSingleNode(XPath).Attributes[dip].Value);
            }
            catch (NullReferenceException)
            {
                if (MessageBox.Show("Hatalı XPath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
        }

        private static void DownloadRemoteImageFile(string uri, string fileName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                MessageBox.Show("BAŞARILI");
            {

                // if the remote file was found, download oit
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 17; i++)
            {

                veriAlDip(listBox1.Items[i].ToString(), "//*[@id='HtmlDownload']/a", "href", listBox2);


            }

            /*for (int i = 0; i < 10; i++)
            {
                

                //veriAl(listBox1.Items[i].ToString(), "//*[@id='content']/div/div/h3", listBox2);
                //listBox3.Items.Add("---------------------------------------");


            }*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 17; i++)
            {
                DownloadRemoteImageFile(listBox2.Items[i].ToString(), "Wallpaperr"+i+".jpg");
            }
            
        }
    }
}
