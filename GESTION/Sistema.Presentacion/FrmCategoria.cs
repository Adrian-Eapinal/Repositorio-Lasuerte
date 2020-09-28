using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }


        private void Listar()
        {
            try
            {
                DgvListado.DataSource= NCategoria.Listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+ex.StackTrace);//para proporcionar una explicacion de lo que haya ocurrido
            }
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            
        }
    }
}
