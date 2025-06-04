using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TransaccionesMenu : Form
    {
        private readonly UsuarioService _usuarioService;
        private readonly TransaccionService transaccionService;
        public TransaccionesMenu()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
            transaccionService = new TransaccionService();

            dtgvTransacciones.CellClick += dtgvTransacciones_CellClick;
        }



        private void Transacciones_Load(object sender, EventArgs e)
        {
            string username = Usuariocache.username;

            var listaTransaccion = transaccionService.consultarTabla(username);
            dtgvTransacciones.DataSource = listaTransaccion;
        }

        

        private void btntransaccion_Click(object sender, EventArgs e)
        {
            try
            {
                
                string usuario = Usuariocache.username;
                string descripcion = txtdescripcion.Text.Trim();
                decimal monto = decimal.Parse(txtmonto.Text.Trim());
                string tipo = cbTipo.Text.Trim();
                string categoria = cbCategoria.Text.Trim();

                
                if (string.IsNullOrEmpty(descripcion))
                {
                    MessageBox.Show("Por favor ingrese una descripción");
                    return;
                }

                if (monto <= 0)
                {
                    MessageBox.Show("El monto debe ser mayor que cero");
                    return;
                }

                
                int idUsuario = _usuarioService.obteneridUsuario(usuario);
                Usuario usuarioActual = new Usuario();
                
                decimal presupuestoActual = Usuariocache.presupuesto;
                try
                {
                    presupuestoActual = Usuariocache.presupuesto;
                }
                catch
                {
                    MessageBox.Show("No se pudo obtener el presupuesto del usuario.");
                    return;
                }


                if (tipo.Equals("egreso", StringComparison.OrdinalIgnoreCase) )
                {
                    if (monto > presupuestoActual)
                    {
                        MessageBox.Show("Saldo insuficiente para realizar la transacción.");
                        return;
                    }
                    else
                    {
                        Transacciones nuevaTransaccion = new Transacciones
                        {
                            Descripcion = descripcion,
                            Monto = monto,
                            Tipo = tipo,
                            Categoria = categoria,
                            Fecha = DateTime.Now
                        };

                        transaccionService.RegistrarTransaccion(nuevaTransaccion, usuario);
                        _usuarioService.ActualizarPresupuesto(idUsuario, monto, false); 

 
                        MessageBox.Show("Transacción registrada correctamente");
                        actualizarGrilla();
                    }
                }
                else
                {
                    if (tipo.Equals("ingreso", StringComparison.OrdinalIgnoreCase))
                    {
                        Transacciones nuevaTransaccion = new Transacciones
                        {
                            Descripcion = descripcion,
                            Monto = monto,
                            Tipo = tipo,
                            Categoria = categoria,
                            Fecha = DateTime.Now
                        };

                        transaccionService.RegistrarTransaccion(nuevaTransaccion, usuario);
                        _usuarioService.ActualizarPresupuesto(idUsuario, monto, true);
                        actualizarGrilla();
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un monto válido");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la transacción: {ex.Message}");
            }
        }

        private void GuardarTransaccion(Transacciones transaccion)
        {
            string usuario = Usuariocache.username;
            transaccionService.RegistrarTransaccion(transaccion, usuario);
           
            actualizarGrilla();
        }

        private void actualizarGrilla()
        {
            string username = Usuariocache.username;

            var listaTransaccion = transaccionService.consultarTabla(username);
            dtgvTransacciones.DataSource = listaTransaccion;
            
        }

        private void dtgvTransacciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvTransacciones.CurrentRow != null && dtgvTransacciones.CurrentRow.DataBoundItem is Transacciones transaccionSeleccionada)
            {
                var confirmResult = MessageBox.Show(
                    "¿Está seguro que desea eliminar esta transacción?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        if (transaccionSeleccionada.Id.HasValue)
                        {
                            transaccionService.EliminarTransaccionPorId(transaccionSeleccionada.Id.Value);
                            MessageBox.Show("Transacción eliminada correctamente.");
                            actualizarGrilla();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo identificar la transacción a eliminar.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la transacción: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una transacción para eliminar.");
            }
        }


        private void dtgvTransacciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgvTransacciones.Rows[e.RowIndex].DataBoundItem is Transacciones transaccionSeleccionada)
            {
                txtdescripcion.Text = transaccionSeleccionada.Descripcion;
                txtmonto.Text = transaccionSeleccionada.Monto.ToString("F2");
                cbTipo.Text = transaccionSeleccionada.Tipo;
                cbCategoria.Text = transaccionSeleccionada.Categoria;

                _transaccionSeleccionadaId = transaccionSeleccionada.Id;
            }
        }


        private int? _transaccionSeleccionadaId = null;

   
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_transaccionSeleccionadaId == null)
            {
                MessageBox.Show("Por favor seleccione una transacción para modificar.");
                return;
            }

            try
            {
                string usuario = Usuariocache.username;
                string descripcion = txtdescripcion.Text.Trim();
                decimal monto = decimal.Parse(txtmonto.Text.Trim());
                string tipo = cbTipo.Text.Trim();
                string categoria = cbCategoria.Text.Trim();

                if (string.IsNullOrEmpty(descripcion))
                {
                    MessageBox.Show("Por favor ingrese una descripción");
                    return;
                }

                if (monto <= 0)
                {
                    MessageBox.Show("El monto debe ser mayor que cero");
                    return;
                }


                Transacciones transaccionModificada = new Transacciones
                {
                    Id = _transaccionSeleccionadaId,
                    Descripcion = descripcion,
                    Monto = monto,
                    Tipo = tipo,
                    Categoria = categoria,
                    Fecha = DateTime.Now 
                };


                transaccionService.ModificarTransaccion(transaccionModificada, usuario);

                MessageBox.Show("Transacción modificada correctamente.");
                actualizarGrilla();
                _transaccionSeleccionadaId = null;
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un monto válido");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la transacción: {ex.Message}");
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            GUI.menu menu = new GUI.menu();
            menu.Show();
            this.Close();

        }

        private void txtdescripcion_Enter(object sender, EventArgs e)
        {
            if (txtdescripcion.Text == "DESCRIPCION")
            {
                txtdescripcion.Text = "";
                txtdescripcion.ForeColor = Color.Black;
            }
        }

        private void txtdescripcion_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdescripcion.Text))
            {
                txtdescripcion.Text = "DESCRIPCION";
                txtdescripcion.ForeColor = Color.Gray;
            }
        }

        private void txtmonto_Enter(object sender, EventArgs e)
        {
            if (txtmonto.Text == "MONTO")
            {
                txtmonto.Text = "";
                txtmonto.ForeColor = Color.Black;
            }
        }

        private void txtmonto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmonto.Text))
            {
                txtmonto.Text = "MONTO";
                txtmonto.ForeColor = Color.Gray;
            }
        }
    }
}
