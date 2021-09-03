using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFACliente_asmx.ServiceGestoresASMX;
using WFACliente_asmx.ServiceGestoresWCF;

namespace WFACliente_asmx
{
    public partial class frmGestores : Form
    {
        public frmGestores()
        {
            InitializeComponent();
        }
        private void LoadDataWSASMX()
        {
            GestoresServiceSoapClient cliente = new GestoresServiceSoapClient();
            var gestores = cliente.GetAllGestores();
            dgvGestores.DataSource = gestores;
        }

        private void LoadDataWSWFC()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(remove);
            Service1Client clienteWCF = new Service1Client();
            var gestores2 = clienteWCF.GetGestores();
            dgvGestores.DataSource = gestores2;
        }

        private void LoadDataWebApiRest()
        {
            //Invocar servicio rest api
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:49815/");

            var request = clienteHttp.GetAsync("api/Gestores").Result;
          /*clienteHttp.PostAsync();
            clienteHttp.PutAsync();
            clienteHttp.DeleteAsync();*/
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Gestores>>(result);
                dgvGestores.DataSource = listado;
            }
        }
        private bool remove(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadDataWSASMX();
            //LoadDataWSWFC();
            LoadDataWebApiRest();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPopUp frm = new frmPopUp();
            frm.Id = 0;
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmPopUp frm = new frmPopUp();
            frm.Id = (int)dgvGestores.CurrentRow.Cells[0].Value;
            frm.ShowDialog();
        }
    }
}
