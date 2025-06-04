using BLL;
using ENTITY;
using proyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class menu : Form
    {
        private readonly UsuarioService usuarioService;
        private readonly login usuario;
        public menu()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
            lblNombUser.Text = Usuariocache.username;
            
            lblpresupuesto.Text = string.Format("{0:C}", Usuariocache.presupuesto);

        }

        



        private void menu_Load(object sender, EventArgs e)
        {
            lblNombUser.Text = Usuariocache.username;
        }

        private void AbrirFormulario(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            AbrirFormulario(new TransaccionesMenu());
        }

        private void btnrestar_Click(object sender, EventArgs e)
        {
            string input = txtmonto.Text;
            if (decimal.TryParse(input, out decimal monto) && monto > 0)
            {
                int idUsuario = Usuariocache.idusuario;
                usuarioService.ActualizarPresupuesto(idUsuario, monto, false);


                Usuariocache.presupuesto -= monto;
                lblpresupuesto.Text = string.Format("{0:C}", Usuariocache.presupuesto);

                MessageBox.Show("Presupuesto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ingrese un monto válido mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsumar_Click(object sender, EventArgs e)
        {

            string input = txtmonto.Text;
            if (decimal.TryParse(input, out decimal monto) && monto > 0)
            {
                int idUsuario = Usuariocache.idusuario;
                usuarioService.ActualizarPresupuesto(idUsuario, monto, true);


                Usuariocache.presupuesto += monto;
                lblpresupuesto.Text = string.Format("{0:C}", Usuariocache.presupuesto);

                MessageBox.Show("Presupuesto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ingrese un monto válido mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAhorros_Click(object sender, EventArgs e)
        {
            this.Hide();

            string username = Usuariocache.username;
            AbrirFormulario(new FormAhorro(username));

        }

        private void btnDeudas_Click(object sender, EventArgs e)
        {
            this.Hide();

            string username = Usuariocache.username;
            AbrirFormulario(new FormDeudas(username));

        }

        private void txtmonto_Enter(object sender, EventArgs e)
        {
            if (txtmonto.Text == "AGREGAR PRESUPUESTO")
            {
                txtmonto.Text = "";
                txtmonto.ForeColor = Color.Black;
            }
        }

        private void txtmonto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmonto.Text))
            {
                txtmonto.Text = "AGREGAR PRESUPUESTO";
                txtmonto.ForeColor = Color.DimGray;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
