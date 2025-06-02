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

namespace GUI
{
    public partial class login : Form
    {
        private readonly UsuarioService _usuarioservice;
        public login()
        {
            InitializeComponent();
            _usuarioservice = new UsuarioService();
        }

        private void AbrirFormulario(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtuser.Text.Trim();
            string contrasena = txtpassword.Text.Trim();

            _usuarioservice.Login(usuario, contrasena);

            if (_usuarioservice.Login(usuario, contrasena) == true)
            {
                this.Hide();
                AbrirFormulario(new menu());
                
            }

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.Black;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtuser.Text))
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }

        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "CONTRASEÑA")
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.Black;
                txtpassword.UseSystemPasswordChar = true; // Mostrar como contraseña
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                txtpassword.Text = "CONTRASEÑA";
                txtpassword.ForeColor = Color.DimGray;
                txtpassword.UseSystemPasswordChar = false; // Mostrar como texto normal
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Hide();
            proyecto.FormInicio inicioForm = new proyecto.FormInicio();
            inicioForm.Show();
        }

        //public string InicioDesesion()
        //{
        //    try
        //    {


        //        bool UsuarioValido = _usuarioservice.Login(usuario, contrasena);
        //        if (UsuarioValido != true)
        //        {
        //            menu formMenu = new menu();
        //            formMenu.Show();
        //            this.Hide();
        //            return usuario;
        //        }
        //        else
        //        {
        //            return "Usuario o contraseña incorrectos";
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
