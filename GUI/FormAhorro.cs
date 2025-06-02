using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITY;
using BLL;

namespace proyecto
{
    public partial class FormAhorro : Form
    {
        private readonly MetaAhorroService _metaAhorroService;
        private string _username; // Debes obtener este valor al crear el formulario

        public FormAhorro(string username)
        {
            InitializeComponent();
            _metaAhorroService = new MetaAhorroService();
            _username = username;

            // Configuración inicial
            ConfigurarPlaceholders();
            CargarMetas();
        }

        private void ConfigurarPlaceholders()
        {
            // Manejar eventos para los placeholders
            txtCantidad.Enter += (s, e) => {
                if (txtCantidad.Text == "Cantidad") txtCantidad.Text = "";
            };

            txtCantidad.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtCantidad.Text)) txtCantidad.Text = "Cantidad";
            };

            txtNombreMe.Enter += (s, e) => {
                if (txtNombreMe.Text == "Nombre de tu Meta") txtNombreMe.Text = "";
            };

            txtNombreMe.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtNombreMe.Text)) txtNombreMe.Text = "Nombre de tu Meta";
            };
        }

        private void CargarMetas()
        {
            
                var metas = _metaAhorroService.consultarTabla(_username);
                dgvMetas.DataSource = metas;

                // Opcional: Configurar columnas del DataGridView si es necesario
                //if (dgvMetas.Columns.Count > 0)
                //{
                //    dgvMetas.Columns[0].HeaderText = "Nombre";
                //    dgvMetas.Columns[1].HeaderText = "Monto Objetivo";
                //    dgvMetas.Columns[2].HeaderText = "Monto Actual";
                //    dgvMetas.Columns[3].HeaderText = "Fecha Objetivo";
                //}
            
            
        }

        private void btnAgregarMeta_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            

            
        }

        private void btnGestionar_Click(object sender, EventArgs e)
        {
            // Implementar lógica para gestionar (depositar/retirar)
            if (dgvMetas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor selecciona una meta para gestionar", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí podrías abrir otro formulario para gestionar la meta seleccionada
        }

      

        private void btnsalir_Click_1(object sender, EventArgs e)
        {
            GUI.menu menu = new GUI.menu();
            menu.Show();
            this.Close();

        }

        private void btnGestionar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormGestAhorrar gestionarMeta = new FormGestAhorrar();

            gestionarMeta.Show();


        }

        private void btnAgregarMeta_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (txtNombreMe.Text == "Nombre de tu Meta" || string.IsNullOrWhiteSpace(txtNombreMe.Text))
                {
                    MessageBox.Show("Por favor ingresa un nombre para la meta", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtCantidad.Text == "Cantidad" || !decimal.TryParse(txtCantidad.Text, out decimal monto))
                {
                    MessageBox.Show("Por favor ingresa una cantidad válida", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear objeto MetaAhorro
                var meta = new MetaAhorro
                {
                    MontoActual = 0,
                    MontoObjetivo = monto,
                    NombreMeta = txtNombreMe.Text,
                    Completada = false,
                    PorcentajeCompletado = 0,

                    // Iniciar en 0
                };

                // Registrar la meta
                _metaAhorroService.RegistrarMetaAhorro(meta, _username);

                MessageBox.Show("Meta creada exitosamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar y actualizar
                txtNombreMe.Text = "Nombre de tu Meta";
                txtCantidad.Text = "Cantidad";
                CargarMetas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la meta: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvMetas.CurrentRow != null && dgvMetas.CurrentRow.DataBoundItem is MetaAhorro metaSeleccionada)
            {
                var confirmResult = MessageBox.Show(
                    "¿Está seguro que desea eliminar esta meta de ahorro?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        if (metaSeleccionada.Id > 0)
                        {
                            _metaAhorroService.EliminarMetaAhorro(metaSeleccionada.Id);
                            MessageBox.Show("Meta eliminada correctamente.");
                            CargarMetas();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo identificar la meta a eliminar.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la meta: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una meta para eliminar.");
            }
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "Cantidad")
            {
                txtCantidad.Text = "";
                txtCantidad.ForeColor = Color.Black;
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                txtCantidad.Text = "Cantidad";
                txtCantidad.ForeColor = Color.DimGray;
            }
        }

        private void txtNombreMe_Enter(object sender, EventArgs e)
        {
            if (txtNombreMe.Text == "Nombre de tu Meta")
            {
                txtNombreMe.Text = "";
                txtNombreMe.ForeColor = Color.Black;
            }
        }

        private void txtNombreMe_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMe.Text))
            {
                txtNombreMe.Text = "Nombre de tu Meta";
                txtNombreMe.ForeColor = Color.DimGray;
            }
        }
    }
}
