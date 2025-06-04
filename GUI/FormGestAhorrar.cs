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
        private string _username; 
        public FormGestAhorrar()
        {
            InitializeComponent();
            _metaAhorroService = new MetaAhorroService();
            _username = Usuariocache.username; 
            CargarMetas();
            this.dgvmetas.CellClick += new DataGridViewCellEventHandler(this.dgvmetas_CellClick);
            
        }

        private void CargarMetas()
        {
            try
            {
                var metas = _metaAhorroService.consultarTabla(_username);
                dgvmetas.DataSource = metas;

                
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
                
            }
        }


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

                var metaActual = _metaAhorroService.consultarTabla(usuario)
                    .FirstOrDefault(m => m.Id == _MetaSeleccionadaId.Value);
                lblNomMeta.Text = metaActual.NombreMeta;

                if (metaActual == null)
                {
                    MessageBox.Show("No se encontró la meta seleccionada.");
                    return;
                }

               
                

                metaActual.MontoActual = montoAhorro;

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

        
    }
}




        

