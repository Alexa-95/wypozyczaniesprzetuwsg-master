using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WypozyczanieSprzetuWSG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataReload();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btRent_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void dgvRents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btConstRent_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.Show();
        }

        public void dataReload()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://serwiswsg.000webhostapp.com/api.php?select=rents");
                var rents = JsonConvert.DeserializeObject<List<JRent>>(json);
                dgvRents.DataSource = rents;

                dgvRents.Columns[0].HeaderText = "ID";
                dgvRents.Columns[1].HeaderText = "Imię";
                dgvRents.Columns[2].HeaderText = "Nazwisko";
                dgvRents.Columns[3].HeaderText = "Wypożyczone dnia";
                dgvRents.Columns[4].HeaderText = "Wypożyczone do";
                dgvRents.Columns[5].HeaderText = "Sprzęt";
                dgvRents.Columns[6].HeaderText = "Sala";
                dgvRents.Columns[7].HeaderText = "Uwagi";

                dgvRents.Columns[0].Width = 50;
                dgvRents.Columns[2].Width = 150;
                dgvRents.Columns[1].Width = 150;
                dgvRents.Columns[3].Width = 180;
                dgvRents.Columns[4].Width = 180;
                dgvRents.Columns[5].Width = 130;
                dgvRents.Columns[7].Width = 300;
            }
        }
    }
}
