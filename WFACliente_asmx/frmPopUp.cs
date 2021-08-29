using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFACliente_asmx
{
    public partial class frmPopUp : Form
    {
        public int Id { get; set; } = 0;
        public frmPopUp()
        {
            InitializeComponent();
        }

        private void frmPopUp_Load(object sender, EventArgs e)
        {
            if(Id > 0)
            {
                this.Text = "Editar gestor";
                txtId.Text = Id.ToString();
            }
            else
            {
                this.Text = "Agregar gestor";
                txtId.Text = Id.ToString();
            }
        }
    }
}
