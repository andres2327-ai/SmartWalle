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
                // Obtener datos del formulario
                string usuario = Usuariocache.username;
                string descripcion = txtdescripcion.Text.Trim();
                decimal monto = decimal.Parse(txtmonto.Text.Trim());
                string tipo = cbTipo.Text.Trim();
                string categoria = cbCategoria.Text.Trim();

                // Validaciones básicas
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

                // Obtener el usuario para consultar su presupuesto
                int idUsuario = _usuarioService.obteneridUsuario(usuario);
                Usuario usuarioActual = new Usuario();
                // Aquí podrías tener un método para obtener el usuario completo, pero si no, solo consulta el presupuesto
                // Suponiendo que tienes un método para obtener el usuario por username
                // Si no, deberías implementarlo en UsuarioRepository
                // Por ahora, solo obtendremos el presupuesto
                // (Puedes ajustar esto si tienes un método para obtener el usuario completo)
                decimal presupuestoActual = Usuariocache.presupuesto;
                try
                {
                    // Si tienes un método para obtener el usuario completo, úsalo aquí
                    // usuarioActual = _usuarioService.ObtenerUsuarioPorUsername(usuario);
                    // presupuestoActual = usuarioActual.Presupuesto;

                    // Si no, puedes obtener el presupuesto de otra forma
                    // Por ejemplo, podrías tener un método en UsuarioRepository para obtener el presupuesto
                    // Aquí se asume que tienes acceso al presupuesto de alguna manera
                    // Si tienes el usuario en caché, úsalo
                    presupuestoActual = Usuariocache.presupuesto;
                }
                catch
                {
                    MessageBox.Show("No se pudo obtener el presupuesto del usuario.");
                    return;
                }

                // Si la transacción es de tipo "Gasto" o similar, verifica el presupuesto
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

                        // Registrar la transacción
                        transaccionService.RegistrarTransaccion(nuevaTransaccion, usuario);
                        _usuarioService.ActualizarPresupuesto(idUsuario, monto, false); // Restar del presupuesto

                        // Mensaje de éxito
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

                    // Crear nueva transacción
                    

                // Opcional: Limpiar los campos después de guardar

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
            // Aquí puedes implementar la lógica para actualizar la grilla de transacciones
            // Por ejemplo, podrías cargar las transacciones desde la base de datos y mostrarlas en un DataGridView
            // dataGridView1.DataSource = ObtenerTransacciones(); // Método ficticio
        }

        private void dtgvTransacciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Verifica que no se haya hecho clic en el encabezado y que haya una fila seleccionada
            //if (e.RowIndex >= 0 && dtgvTransacciones.Rows[e.RowIndex].DataBoundItem is Transacciones transaccionSeleccionada)
            //{
            //    var confirmResult = MessageBox.Show(
            //        "¿Está seguro que desea eliminar esta transacción?",
            //        "Confirmar eliminación",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Question);

            //    if (confirmResult == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            // Suponiendo que tienes un método EliminarTransaccion en tu servicio
            //            // y que el Id de la transacción no es nulo
            //            if (transaccionSeleccionada.Id.HasValue)
            //            {
            //                transaccionService.EliminarTransaccionPorId(transaccionSeleccionada.Id.Value);
            //                MessageBox.Show("Transacción eliminada correctamente.");
            //                actualizarGrilla();
            //            }
            //            else
            //            {
            //                MessageBox.Show("No se pudo identificar la transacción a eliminar.");
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Error al eliminar la transacción: {ex.Message}");
            //        }
            //    }
            //}
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

        // Paso 1: Al hacer clic en una fila del DataGridView, cargar los datos en los TextBox
        private void dtgvTransacciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgvTransacciones.Rows[e.RowIndex].DataBoundItem is Transacciones transaccionSeleccionada)
            {
                txtdescripcion.Text = transaccionSeleccionada.Descripcion;
                txtmonto.Text = transaccionSeleccionada.Monto.ToString("F2");
                cbTipo.Text = transaccionSeleccionada.Tipo;
                cbCategoria.Text = transaccionSeleccionada.Categoria;
                // Puedes guardar el Id en una variable de clase para usarlo al modificar
                _transaccionSeleccionadaId = transaccionSeleccionada.Id;
            }
        }

        // Paso 2: Declarar variable de clase para guardar el Id de la transacción seleccionada
        private int? _transaccionSeleccionadaId = null;

        // Paso 3: Modificar el método btnModificar_Click para actualizar la transacción
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

                // Crear objeto transacción con los nuevos datos
                Transacciones transaccionModificada = new Transacciones
                {
                    Id = _transaccionSeleccionadaId,
                    Descripcion = descripcion,
                    Monto = monto,
                    Tipo = tipo,
                    Categoria = categoria,
                    Fecha = DateTime.Now // O puedes mantener la fecha original si lo prefieres
                };

                // Llamar al método de actualización (debes implementarlo en tu servicio y repositorio)
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
