using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GUI;

namespace proyecto
{
    public partial class FormInicio : Form
    {
        // Importaciones para mover el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FormInicio()
        {
            InitializeComponent();
            ConfigureWindowStyle();
        }

        private void ConfigureWindowStyle()
        {
            this.Text = string.Empty;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Event Handlers

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            OpenForm(new login());
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            OpenForm(new Registrarse());
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void FormInicio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            // Código de carga si es necesario
        }

        #endregion

        #region Helper Methods

        private void OpenForm(Form form)
        {
            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Close();
        }

        #endregion
    }
}
