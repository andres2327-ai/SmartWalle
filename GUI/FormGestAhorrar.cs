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

namespace proyecto
{
    public partial class FormGestAhorrar : Form
    {
        private readonly MetaAhorroService _metaAhorroService;
        private string _username; // Debes obtener este valor al crear el formulario
        public FormGestAhorrar()
        {
            InitializeComponent();
            _metaAhorroService = new MetaAhorroService();
            _username = Usuariocache.username; // Asignar el nombre de usuario desde el caché
            CargarMetas();
            this.dgvmetas.CellClick += new DataGridViewCellEventHandler(this.dgvmetas_CellClick);
            

             // Asignar el nombre de la primera meta al texto de la etiqueta
        }

        private void CargarMetas()
        {
            try
            {
                var metas = _metaAhorroService.consultarTabla(_username);
                dgvmetas.DataSource = metas;

                // Opcional: Configurar columnas del DataGridView si es necesario
                if (dgvmetas.Columns.Count > 0)
                {
                    dgvmetas.Columns[0].HeaderText = "Nombre";
                    dgvmetas.Columns[1].HeaderText = "Monto Objetivo";
                    dgvmetas.Columns[2].HeaderText = "Monto Actual";
                    dgvmetas.Columns[3].HeaderText = "Fecha Objetivo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las metas: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvmetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvmetas.Rows[e.RowIndex];
                _MetaSeleccionadaId = Convert.ToInt32(row.Cells["Id"].Value);
                // Opcional: puedes mostrar los datos en los controles si lo deseas
            }
        }

        // Variables para almacenar la meta seleccionada

        private int? _MetaSeleccionadaId = null;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_MetaSeleccionadaId == null)
            {
                MessageBox.Show("Por favor seleccione una meta para modificar.");
                return;
            }

            try
            {
                string usuario = Usuariocache.username;
                decimal montoAhorro = decimal.Parse(txtAhorro.Text.Trim());

                if (montoAhorro < 0)
                {
                    MessageBox.Show("El monto de ahorro debe ser mayor o igual a cero.");
                    return;
                }

                // Obtener la meta actual para conservar los demás datos
                var metaActual = _metaAhorroService.consultarTabla(usuario)
                    .FirstOrDefault(m => m.Id == _MetaSeleccionadaId.Value);
                lblNomMeta.Text = metaActual.NombreMeta;

                if (metaActual == null)
                {
                    MessageBox.Show("No se encontró la meta seleccionada.");
                    return;
                }

                // Asignar el nombre de la meta al texto de la etiqueta
                

                metaActual.MontoActual = montoAhorro;

                // Actualizar la meta
                _metaAhorroService.GestionarMetaAhorro(metaActual, usuario);

                MessageBox.Show("Monto de ahorro actualizado correctamente.");
                CargarMetas();
                _MetaSeleccionadaId = null;
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un monto válido en el campo de ahorro.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la meta de ahorro: {ex.Message}");
            }
        }

        private void txtAhorro_Enter(object sender, EventArgs e)
        {
            if (txtAhorro.Text == "Ingrese Ahorro")
            {
                txtAhorro.Text = "";
                txtAhorro.ForeColor = Color.Black;
            }
        }

        private void txtAhorro_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAhorro.Text))
            {
                txtAhorro.Text = "Ingrese Ahorro";
                txtAhorro.ForeColor = Color.DimGray;
            }   
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Recuerda asociar el evento dgvmetas_CellClick al DataGridView en el diseñador o en el constructor:
    }
}


// Pseudocódigo detallado:
// 1. Al hacer clic en un registro del DataGridView (dgvmetas), guardar el id de la meta seleccionada (_MetaSeleccionadaId).
// 2. Al presionar btnGuardar, validar que _MetaSeleccionadaId no sea null.
// 3. Tomar el valor de txtAhorro, validarlo y actualizar el campo monto_actual de la meta seleccionada.
// 4. Llamar a MetaAhorroService.GestionarMetaAhorro con el objeto MetaAhorro actualizado.
// 5. Refrescar la grilla y limpiar la selección.

            // Agregar el evento para seleccionar la meta en el DataGridView:
        

        

