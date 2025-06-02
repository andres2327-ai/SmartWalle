using System;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace proyecto
{
    public partial class FormDeudas : Form
    {
        private readonly DeudasService _deudasService;
        private string _username;

        public FormDeudas(string username)
        {
            InitializeComponent();
            _deudasService = new DeudasService();
            _username = username;
            CargarDeudas();
            ConfigurarPlaceholders();

            dgvDeudas.CellClick += dgvDeudas_CellClick;


        }

        private void ConfigurarPlaceholders()
        {
            txtDescripcion.Enter += (sender, e) => {
                if (txtDescripcion.Text == "Descripción")
                {
                    txtDescripcion.Text = "";
                    txtDescripcion.ForeColor = System.Drawing.Color.Black;
                }
            };

            txtDescripcion.Leave += (sender, e) => {
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    txtDescripcion.Text = "Descripción";
                    txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
                }
            };

            txtMonto.Enter += (sender, e) => {
                if (txtMonto.Text == "Monto")
                {
                    txtMonto.Text = "";
                    txtMonto.ForeColor = System.Drawing.Color.Black;
                }
            };

            txtMonto.Leave += (sender, e) => {
                if (string.IsNullOrWhiteSpace(txtMonto.Text))
                {
                    txtMonto.Text = "Monto";
                    txtMonto.ForeColor = System.Drawing.Color.DimGray;
                }
            };
        }

        private void CargarDeudas()
        {
            try
            {
                var deudas = _deudasService.consultarTabla(_username);
                dgvDeudas.DataSource = deudas;
                //ConfigurarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar deudas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvDeudas.Columns["Id"].Visible = false;
            dgvDeudas.Columns["IdUsuario"].Visible = false;
            dgvDeudas.Columns["Username"].Visible = false;

            if (dgvDeudas.Columns["Descripcion"] != null)
                dgvDeudas.Columns["Descripcion"].HeaderText = "Descripción";

            if (dgvDeudas.Columns["Estado"] != null)
                dgvDeudas.Columns["Estado"].HeaderText = "Estado";

            if (dgvDeudas.Columns["Monto"] != null)
                dgvDeudas.Columns["Monto"].HeaderText = "Monto";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private bool ValidarCampos()
        {
            if (txtDescripcion.Text == "Descripción" || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor ingrese una descripción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtMonto.Text == "Monto" || string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out _))
            {
                MessageBox.Show("Por favor ingrese un monto válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbEstado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Por favor seleccione un estado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtDescripcion.Text = "Descripción";
            txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            txtMonto.Text = "Monto";
            txtMonto.ForeColor = System.Drawing.Color.DimGray;
            cmbEstado.SelectedIndex = -1;
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        

        private void btnatras_Click(object sender, EventArgs e)
        {
            GUI.menu menu = new GUI.menu();
            menu.Show();
            this.Hide();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    var deuda = new Deudas
                    {
                        Descripcion = txtDescripcion.Text,
                        Monto = decimal.Parse(txtMonto.Text),
                        Estado = cmbEstado.Text,
                        FechaCreacion = DateTime.Now
                    };

                    _deudasService.RegistrarDeudas(deuda, _username);
                    LimpiarCampos();
                    CargarDeudas();
                    MessageBox.Show("Deuda registrada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar deuda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvDeudas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una deuda para eliminar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("¿Está seguro que desea eliminar esta deuda?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var deudaId = Convert.ToInt32(dgvDeudas.SelectedRows[0].Cells["Id"].Value);
                    _deudasService.EliminarDeudaPorId(deudaId);
                    CargarDeudas();
                    MessageBox.Show("Deuda eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar deuda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Reemplaza el método dgvDeudas_CellContentClick por este:
        private void dgvDeudas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvDeudas.Rows[e.RowIndex];
                var deuda = fila.DataBoundItem as Deudas;
                if (deuda != null)
                {
                    txtDescripcion.Text = deuda.Descripcion;
                    txtDescripcion.ForeColor = System.Drawing.Color.Black;
                    txtMonto.Text = deuda.Monto.ToString("F2");
                    txtMonto.ForeColor = System.Drawing.Color.Black;
                    cmbEstado.Text = deuda.Estado;
                    _deudaseleccionadaid = deuda.Id;
                }
            }
        }

        // Paso 2: Declarar variable de clase para guardar el Id de la transacción seleccionada
        private int? _deudaseleccionadaid = null;

        // Paso 3: Modificar el método btnModificar_Click para actualizar la transacción

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            string username = _username; // Asegúrate de que el username esté disponible aquí
            if (_deudaseleccionadaid.HasValue)
            {
                if (ValidarCampos())
                {
                    var deudaModificada = new Deudas
                    {
                        Id = _deudaseleccionadaid.Value,
                        Descripcion = txtDescripcion.Text,
                        Monto = decimal.Parse(txtMonto.Text),
                        Estado = cmbEstado.Text,
                        FechaCreacion = DateTime.Now // O la fecha que corresponda
                    };

                    _deudasService.ModificarDeuda(deudaModificada, username);
                    CargarDeudas();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una deuda para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

// Pseudocódigo detallado:
// 1. Al hacer clic en una fila del DataGridView (dgvDeudas), obtener el objeto Deudas de la fila seleccionada.
// 2. Cargar los valores de ese objeto en los controles txtDescripcion, txtMonto y cmbEstado.
// 3. Guardar el Id de la deuda seleccionada en una variable de clase (_deudaseleccionadaid).
// 4. Al hacer clic en btnModificar, si _deudaseleccionadaid tiene valor, validar los campos.
// 5. Si la validación es correcta, crear un objeto Deudas con los datos de los controles y el Id guardado.
// 6. Llamar a _deudasService.ModificarDeuda con el objeto y el username.
// 7. Limpiar los campos y recargar la tabla después de modificar.

            // Implementación:


        private void dgvDeudas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvDeudas.Rows[e.RowIndex];
                var deuda = fila.DataBoundItem as Deudas;
                if (deuda != null)
                {
                    txtDescripcion.Text = deuda.Descripcion;
                    txtDescripcion.ForeColor = System.Drawing.Color.Black;
                    txtMonto.Text = deuda.Monto.ToString("F2");
                    txtMonto.ForeColor = System.Drawing.Color.Black;
                    cmbEstado.Text = deuda.Estado;
                    _deudaseleccionadaid = deuda.Id;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_deudaseleccionadaid.HasValue)
            {
                if (ValidarCampos())
                {
                    try
                    {
                        var deudaModificada = new Deudas
                        {
                            Id = _deudaseleccionadaid.Value,
                            Descripcion = txtDescripcion.Text,
                            Monto = decimal.Parse(txtMonto.Text),
                            Estado = cmbEstado.Text
                        };
                        _deudasService.ModificarDeuda(deudaModificada, _username);
                        LimpiarCampos();
                        CargarDeudas();
                        MessageBox.Show("Deuda modificada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar deuda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una deuda para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

// Asegúrate de asociar el evento en el constructor o en el Load del formulario:
// dgvDeudas.CellClick += dgvDeudas_CellClick;
        

        // 4. Modificar LimpiarCampos para resetear _deudaSeleccionadaId y botones:
        

        // 5. Asociar el evento SelectionChanged en el constructor o en FormDeudas_Load:
        private void FormDeudas_Load(object sender, EventArgs e)
        {
            btnGuardar.Click += btnGuardar_Click;
            
            btnEliminar.Click += btnEliminar_Click;
            
        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripción")
            {
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                txtDescripcion.Text = "Descripción";
                txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            }
        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            if (txtMonto.Text == "Monto")
            {
                txtMonto.Text = "";
                txtMonto.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                txtMonto.Text = "Monto";
                txtMonto.ForeColor = System.Drawing.Color.DimGray;
            }
        }

       
    }
}