using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DALL
{
    public class UsuarioRepository : BDS
    {
        private BDS _bds;

        public UsuarioRepository()
        {
            _bds = new BDS();
        }

        public bool Login(string username, string passwoord)
        {
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "SELECT * FROM USUARIOS WHERE username = @username AND password = @password ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", passwoord);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // Aquí podrías mapear los datos del usuario si es necesario
                            Usuariocache.idusuario = reader.GetInt32(0);
                            Usuariocache.telefono = reader.GetString(1);
                            Usuariocache.nombre = reader.GetString(2);
                            Usuariocache.fechaRegistro = reader.GetDateTime(3);
                            Usuariocache.username = reader.GetString(4);
                            Usuariocache.password = reader.GetString(5);
                            Usuariocache.presupuesto = reader.GetDecimal(6);
                        }
                        return reader.HasRows; // Retorna true si hay filas, indicando que el usuario existe
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }

        public void ActualizarPresupuesto(int idUsuario, decimal monto, bool esSuma)
        {
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string operacion = esSuma ? "+" : "-";
                    string query = $@"
                    UPDATE USUARIOS
                    SET presupuesto = presupuesto {operacion} @monto
                    WHERE Id = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el presupuesto: " + ex.Message);
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }

        public Usuario Registrar(Usuario usuario)
        {
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = @"
                        INSERT INTO usuarios 
                        (telefono, nombre, username, password, presupuesto, fecha_registro) 
                        VALUES 
                        (@telefono, @nombre, @username, @password, @presupuesto, @fecha_registro)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@fecha_registro", usuario.FechaRegistro);
                        cmd.Parameters.AddWithValue("@username", usuario.Username);
                        cmd.Parameters.AddWithValue("@password", usuario.Password);
                        cmd.Parameters.AddWithValue("@presupuesto", usuario.Presupuesto);

                        object result = cmd.ExecuteScalar();
                        usuario.Id = result != null ? Convert.ToInt32(result) : 0; // Obtiene el ID del nuevo usuario insertado
                        return usuario;
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // Manejo de excepciones, podrías registrar el error o lanzar una excepción personalizada
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }

        public string ObtenerUsusario(string username)
        {
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "SELECT nombre FROM USUARIOS WHERE username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        return result != null ? result.ToString() : null; // Retorna el nombre o null si no existe
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }

        public int obtenerIdUsuario(string username)
        {
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "SELECT Id FROM USUARIOS WHERE username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0; // Retorna el ID o 0 si no existe
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }
    }
}
