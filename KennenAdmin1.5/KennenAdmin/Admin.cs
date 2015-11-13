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
using Nemiro.OAuth;
using Nemiro.OAuth.LoginForms;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace KennenAdmin
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = String.Empty;
            webControl2.Hide();
            this.CenterToScreen();
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                info.Url = textBox1.Text;
                SaveXML.SaveData(info, "Data.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XDocument doc;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            doc = XDocument.Load("Data.xml");
            doc.Save(appPath + "\\" + "Data.xml");
            FileStream upstream = new FileStream((appPath + "\\" + "Data.xml").ToString(), FileMode.Open);
            OAuthUtility.PutAsync
                         (
                         "https://api-content.dropbox.com/1/files_put/auto//",
                         new HttpParameterCollection
                {
                    {"access_token",Properties.Settings.Default.AccessToken},
                    {"path",Path.Combine(Path.GetFileName("Data.xml")).Replace("\\","/")},
                    {"overwrite","true"},
                    {"autorename","true"},
                    {upstream}
                },
                         callback: Upload_Result
                         );
            link();
        }
        private void Upload_Result(RequestResult result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<RequestResult>(Upload_Result), result);
                return;

            }
        }
        private void link()
        {

            OAuthUtility.PostAsync
            (
              "https://api.dropbox.com/1/shares/auto/",
                new HttpParameterCollection
                {
                    {"path",Path.Combine(Path.GetFileName("Data.xml")).Replace("\\","/") },
                    {"access_token",Properties.Settings.Default.AccessToken },
                    {"short_url","false"}
                },
                callback: GetShareLink_Result
             );
        }
        private void GetShareLink_Result(RequestResult result)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void sendURLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                info.Url = textBox1.Text;
                SaveXML.SaveData(info, "Data.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void sendToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            XDocument doc;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            doc = XDocument.Load("Data.xml");
            doc.Save(appPath + "\\" + "Data.xml");
            FileStream upstream = new FileStream((appPath + "\\" + "Data.xml").ToString(), FileMode.Open);
            OAuthUtility.PutAsync
                         (
                         "https://api-content.dropbox.com/1/files_put/auto//",
                         new HttpParameterCollection
                {
                    {"access_token",Properties.Settings.Default.AccessToken},
                    {"path",Path.Combine(Path.GetFileName("Data.xml")).Replace("\\","/")},
                    {"overwrite","true"},
                    {"autorename","true"},
                    {upstream}
                },
                         callback: Upload_Result
                         );
            link();
        }

   // Proxy Use
        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                webControl1.Hide();
                webControl2.Show();
               
            }
            if (checkBox1.Checked == false)
            {
                webControl2.Hide();
                webControl1.Show();
               
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            webControl1.DataBindings.Clear();
            webControl1.Stop();
            Application.Exit();
        }

        private void backToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                info.Url = textBox1.Text;
                SaveXML.SaveData(info, "Data.xml"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            XDocument doc;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            doc = XDocument.Load("Data.xml");
            doc.Save(appPath + "\\" + "Data.xml");
            FileStream upstream = new FileStream((appPath + "\\" + "Data.xml").ToString(), FileMode.Open);
            OAuthUtility.PutAsync
                         (
                         "https://api-content.dropbox.com/1/files_put/auto//",
                         new HttpParameterCollection
                {
                    {"access_token",Properties.Settings.Default.AccessToken},
                    {"path",Path.Combine(Path.GetFileName("Data.xml")).Replace("\\","/")},
                    {"overwrite","true"},
                    {"autorename","true"},
                    {upstream}
                },
                         callback: Upload_Result
                         );
            link();
        }

        private void Awesomium_Windows_Forms_WebControl_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void Awesomium_Windows_Forms_WebControl_ShowCreatedWebView(object sender, Awesomium.Core.ShowCreatedWebViewEventArgs e)
        {

        }

        private void Awesomium_Windows_Forms_WebControl_DocumentReady(object sender, Awesomium.Core.DocumentReadyEventArgs e)
        {
            textBox1.Text = webControl1.Source.ToString();
        }

        private void Awesomium_Windows_Forms_WebControl_AddressChanged(object sender, Awesomium.Core.UrlEventArgs e)
        {
            textBox1.Text = webControl1.Source.ToString();
        }

        private void Awesomium_Windows_Forms_WebControl_AddressChanged_1(object sender, Awesomium.Core.UrlEventArgs e)
        {
            textBox1.Text = webControl2.Source.ToString();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}