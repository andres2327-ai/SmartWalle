using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;
using proyecto;

namespace GUI
{
    public partial class Registrarse : Form
    {
        private readonly UsuarioService _usuarioService;
        public Registrarse()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
        }

        private bool RegistrarUsuario()
        {
            try
            {
                string telefono = txttelefono.Text.Trim();
                string nombre = txtnombre.Text.Trim();
                string username = txtuser.Text.Trim();
                string password = txtpasw.Text.Trim();
                string passwordConfi = txtpassw2.Text.Trim();
                decimal presupuesto = decimal.Parse(txtpresupuesto.Text.Trim());
                DateTime fecha = DateTime.Now;

                Usuario usuario = new Usuario
                {
                    Telefono = telefono,
                    Nombre = nombre,
                    Username = username,
                    Password = password,
                    Presupuesto = presupuesto, 
                    FechaRegistro = fecha
                };
                
                if (password == passwordConfi)
                {
                    _usuarioService.Registrar(usuario);
                    MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al registrar el usuario. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (RegistrarUsuario() == true)
            {
                this.Hide(); 
                login loginForm = new login();
                loginForm.Show();
            }
            
             
        }

        private void txttelefono_Enter(object sender, EventArgs e)
        {
            if (txttelefono.Text == "Telefono")
            {
                txttelefono.Text = "";
                txttelefono.ForeColor = Color.Black;
            }
        }

        private void txttelefono_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttelefono.Text))
            {
                txttelefono.Text = "Telefono";
                txttelefono.ForeColor = Color.DimGray;
            }
        }

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            if (txtnombre.Text == "Nombre")
            {
                txtnombre.Text = "";
                txtnombre.ForeColor = Color.Black;
            }
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                txtnombre.Text = "Nombre";
                txtnombre.ForeColor = Color.DimGray;
            }
        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.Black;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtuser.Text))
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpasw_Enter(object sender, EventArgs e)
        {
            if (txtpasw.Text == "Contraseña")
            {
                txtpasw.Text = "";
                txtpasw.ForeColor = Color.Black;
                txtpasw.UseSystemPasswordChar = true;
            }
        }

        private void txtpasw_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpasw.Text))
            {
                txtpasw.Text = "Contraseña";
                txtpasw.ForeColor = Color.DimGray;
                txtpasw.UseSystemPasswordChar = false;
            }
        }

        private void txtpassw2_Enter(object sender, EventArgs e)
        {
            if (txtpassw2.Text == "Confirmar Contraseña")
            {
                txtpassw2.Text = "";
                txtpassw2.ForeColor = Color.Black;
                txtpassw2.UseSystemPasswordChar = true;
            }
        }

        private void txtpassw2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpassw2.Text))
            {
                txtpassw2.Text = "Confirmar Contraseña";
                txtpassw2.ForeColor = Color.DimGray;
                txtpassw2.UseSystemPasswordChar = false;
            }
        }

        private void txtpresupuesto_Enter(object sender, EventArgs e)
        {
            if (txtpresupuesto.Text == "Presupuesto")
            {
                txtpresupuesto.Text = "";
                txtpresupuesto.ForeColor = Color.Black;
            }
        }

        private void txtpresupuesto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpresupuesto.Text))
            {
                txtpresupuesto.Text = "Presupuesto";
                txtpresupuesto.ForeColor = Color.DimGray;
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInicio inicioForm = new FormInicio(); 
            inicioForm.Show();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
