using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Api_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_datos_Click(object sender, EventArgs e)
        {
            using(var client = new HttpClient())
            {
                string url = "https://gorest.co.in/public/v2/users?access-token=e6d48572f69d12208567df293314ee38f9ed8fd57d143adcd7d0b75638dab4a8";
                client.DefaultRequestHeaders.Clear();
                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                dynamic r = JArray.Parse(res);
                dataGridView1.DataSource = r;
            }
        }
    }
}
