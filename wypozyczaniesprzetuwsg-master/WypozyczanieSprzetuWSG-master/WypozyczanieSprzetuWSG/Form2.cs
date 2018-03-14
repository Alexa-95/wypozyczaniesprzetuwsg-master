using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WypozyczanieSprzetuWSG
{
    public partial class Form2 : Form
    {
        Form1 mainForm;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            mainForm = form1;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://serwiswsg.000webhostapp.com/api.php?select=devices");
                List<JDevice> devices = JsonConvert.DeserializeObject<List<JDevice>>(json);
                this.cbDevice.DataSource = devices;
                this.cbDevice.DisplayMember = "device_name";
                this.cbDevice.ValueMember = "device_id";
            }
        }

        private static readonly HttpClient client = new HttpClient();

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                var values = new NameValueCollection();
                values["rent_name"] = tbName.Text;
                values["rent_surname"] = tbSurname.Text;
                values["rent_from"] = dtpRentFrom.Text;
                values["rent_to"] = dtpRentTo.Text;
                values["rent_device"] = cbDevice.SelectedValue.ToString();
                values["rent_room"] = tbRoom.Text;
                values["rent_ad"] = tbAd.Text;

                var response = wc.UploadValues("https://serwiswsg.000webhostapp.com/addRent.php", "POST", values);
                string responseString = Encoding.UTF8.GetString(response);

                this.Close();
                mainForm.dataReload();
            }
        }
    }
}
