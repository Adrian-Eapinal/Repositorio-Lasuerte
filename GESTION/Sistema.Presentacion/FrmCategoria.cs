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

        private string NombreAnt;
        public FrmCategoria()
        {
            InitializeComponent();
        }


        private void Listar()
        {
            try
            {
                Dgvlistado.DataSource = NCategoria.Listar();
                this.Formato();
                this.Limpiar();

                lblTotall.Text = "Total de registros: " + Convert.ToString(Dgvlistado.Rows.Count);
            }
             

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);//para proporcionar una explicacion de lo que haya ocurrido

            }
        }

        private void Buscar()
        {
            try
            {
                Dgvlistado.DataSource = NCategoria.Buscar(txtbuscar.Text);
                this.Formato();

                lblTotall.Text = "Total de registros: " + Convert.ToString(Dgvlistado.Rows.Count);
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);//para proporcionar una explicacion de lo que haya ocurrido

            }
        }
        private void Formato()
        {
            Dgvlistado.Columns[0].Visible = false;
            Dgvlistado.Columns[1].Visible = false;
            Dgvlistado.Columns[2].Width = 150;
            Dgvlistado.Columns[3].Width = 440;
            Dgvlistado.Columns[3].HeaderText = "Descripcion";
            Dgvlistado.Columns[4].Width = 100;
        }
        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtbuscar.Clear();
            btninsertar.Visible = true;
            btnactualizar.Visible = false;
            ErrorIcono.Clear();

        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Entrada y Salida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Entrada y Salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Listar();
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Lbltotal_Click(object sender, EventArgs e)
        {
          

        }

        private void Txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Buscar();
        }

        private void Btninsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text== string.Empty)
                {
                  this.MensajeError("Faltan ingresar algunos datos, serán remarcados");// le paso el parametro para que me pase el error 
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre."); //Para mostrar el icono de error el la caja de texto
                }
                else
                {
                    Rpta = NCategoria.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());// le pasamos los parametros y ltrim para borrar los espacios
                    if (Rpta.Equals(("OK")))
                    {
                        this.MensajeOk("Se inserto de forma correcta el registro.");
                        this.Limpiar();
                        this.Listar();//para llamar a los registros que estan registrador 
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            Tabgeneral.SelectedIndex = 0;

        }

        private void Dgvlistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.Limpiar();//para oculta el actualizar 
            btnactualizar.Visible = true;
            btninsertar.Visible = false;
            txtId.Text = Convert.ToString(Dgvlistado.CurrentRow.Cells["ID"].Value);
            this.NombreAnt = Convert.ToString(Dgvlistado.CurrentRow.Cells["Nombre"].Value);
            txtNombre.Text = Convert.ToString(Dgvlistado.CurrentRow.Cells["Nombre"].Value);
            txtDescripcion.Text = Convert.ToString(Dgvlistado.CurrentRow.Cells["Descripcion"].Value);
            Tabgeneral.SelectedIndex = 1;
            
        }

        private void Btnactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty || txtId.Text== string.Empty)
                {
                    this.MensajeError("Faltan ingresar algunos datos, serán remarcados");// le paso el parametro para que me pase el error 
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre."); //Para mostrar el icono de error el la caja de texto
                }
                else
                {
                    Rpta = NCategoria.Actualizar(Convert.ToInt32(txtId.Text), this.NombreAnt,txtNombre.Text.Trim(), txtDescripcion.Text.Trim());// le pasamos los parametros y ltrim para borrar los espacios
                    if (Rpta.Equals(("OK")))
                    {
                        this.MensajeOk("Se Actualizó de forma correcta el registro.");
                        this.Limpiar();
                        this.Listar();//para llamar a los registros que estan registrador 
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
