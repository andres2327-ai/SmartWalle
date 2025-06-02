using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DALL
{
    public class TransaccionesRepository : BDS
    {
        private BDS _bds;
        private UsuarioRepository _usuarioRepository = new UsuarioRepository();
        public TransaccionesRepository()
        {
            _bds = new BDS();
        }

        public List<Transacciones> ObtenerTransaccionesPorUsuario(int idusuario)
        {
            List<Transacciones> transacciones = new List<Transacciones>();
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "SELECT * FROM transacciones WHERE usuario_id = @usuario_id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", idusuario);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            transacciones.Add(new Transacciones
                            {
                                Id = reader.GetInt32(0),
                                IdUsuario = reader.GetInt32(1),
                                Monto = reader.GetDecimal(2),
                                Tipo = reader.GetString(3),
                                Categoria = reader.GetString(4),
                                Descripcion = reader.GetString(5),
                                Fecha = reader.GetDateTime(6)
                                
                                // Asumiendo que 'categoria' es la descripción
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones, podrías registrar el error o lanzar una excepción personalizada
                    throw new Exception("Error al consultar: " + ex.Message);
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
            return transacciones;
        }
        

        public Transacciones Registrar(Transacciones transaccion, int idusuario, string username)
        {

            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);

            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = @"INSERT INTO transacciones 
                  (usuario_id, descripcion, monto, fecha, tipo, categoria)
                  OUTPUT INSERTED.Id
                  VALUES 
                  (@usuario_id, @descripcion, @monto, @fecha, @tipo, @categoria)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("usuario_id", idUsuario);
                        cmd.Parameters.AddWithValue("@descripcion", transaccion.Descripcion);
                        cmd.Parameters.AddWithValue("@Monto", transaccion.Monto);
                        cmd.Parameters.AddWithValue("@fecha", transaccion.Fecha);
                        cmd.Parameters.AddWithValue("@tipo", transaccion.Tipo);
                        cmd.Parameters.AddWithValue("@categoria", transaccion.Categoria); // Asumiendo que 'categoria' es la descripción



                        int id = (int)cmd.ExecuteScalar(); // Obtener el ID de la transacción insertada
                        transaccion.Id = id; //
                        return transaccion;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones, podrías registrar el error o lanzar una excepción personalizada
                    throw new Exception("Error al registrar la transacción: " + ex.Message);
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }



        public bool EliminarTransaccion(int idTransaccion)
        {
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "DELETE FROM transacciones WHERE Id = @id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idTransaccion);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la transacción: " + ex.Message);
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }
        public Transacciones Modificar(Transacciones transaccion, int idusuario, string username)
        {
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);

            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }

            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = @"UPDATE transacciones 
                                     SET descripcion = @descripcion, 
                                         monto = @monto, 
                                         fecha = @fecha, 
                                         tipo = @tipo, 
                                         categoria = @categoria
                                     WHERE Id = @id AND usuario_id = @usuario_id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@descripcion", transaccion.Descripcion);
                        cmd.Parameters.AddWithValue("@monto", transaccion.Monto);
                        cmd.Parameters.AddWithValue("@fecha", transaccion.Fecha);
                        cmd.Parameters.AddWithValue("@tipo", transaccion.Tipo);
                        cmd.Parameters.AddWithValue("@categoria", transaccion.Categoria);
                        cmd.Parameters.AddWithValue("@id", transaccion.Id);
                        cmd.Parameters.AddWithValue("@usuario_id", idUsuario);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la transacción o no tiene permisos para modificarla.");
                        }
                        return transaccion;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al modificar la transacción: " + ex.Message);
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }
    }
}
