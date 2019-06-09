using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmUsuario : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void bntNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtIdusuario.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtCi.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
            this.txtEstado.ReadOnly = !valor;
            this.txtEdad.ReadOnly = !valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
            this.txtIdusuario.ReadOnly = !valor;
        }
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.bntNuevo.Enabled = false;
                this.bntGuardar.Enabled = true;
                this.bntEditar.Enabled = false;
                this.bntCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.bntNuevo.Enabled = true;
                this.bntGuardar.Enabled = false;
                this.bntEditar.Enabled = true;
                this.bntCancelar.Enabled = false;
            }
        }
        private void OcultarColumnas()
        {
            //this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NUsuario.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarApellido()
        {
            this.dataListado.DataSource = NUsuario.BuscarApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NUsuario.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellido"))
            {
                this.BuscarApellido();
            }
            else if (cbBuscar.Text.Equals("Nit"))
            {
                this.BuscarNombre();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro", "Sistema de Reserva", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NUsuario.Eliminar(Convert.ToInt32(codigo));
                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se Elimino Correctamente");
                            }
                            else
                            {
                                this.MensajeError(rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkElimnar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkElimnar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void FrmUsuario_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdusuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idusuario"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
            this.txtCi.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ci"].Value);
            this.txtCorreo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correo"].Value);
            this.txtEdad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["edad"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acesso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["contra"].Value);
            this.txtEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["estado"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void bntGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta Datos");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NUsuario.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(), this.txtCi.Text.Trim().ToUpper(), this.txtCorreo.Text.Trim().ToUpper(), this.txtEdad.Text.Trim().ToUpper(), this.cbAcceso.Text, this.txtUsuario.Text, this.txtPassword.Text, this.txtEstado.Text.Trim().ToUpper());

                    }
                    else
                    {
                        rpta = NUsuario.Editar(Convert.ToInt32(this.txtIdusuario.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(), this.txtCi.Text.Trim().ToUpper(), this.txtCorreo.Text.Trim().ToUpper(), this.txtEdad.Text.Trim().ToUpper(), this.cbAcceso.Text, this.txtUsuario.Text, this.txtPassword.Text, this.txtEstado.Text.Trim().ToUpper());

                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se Inserto");
                        }
                        else
                        {
                            this.MensajeOK("Se Actualizo");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdusuario.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Seleccione el registro");
            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.txtIdusuario.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
