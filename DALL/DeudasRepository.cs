using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ENTITY;

namespace DALL
{
    public class DeudasRepository : BDS
    {
        private BDS _bds;
        private UsuarioRepository _usuarioRepository = new UsuarioRepository();
        public DeudasRepository()
        {
            _bds = new BDS();
        }

        public Deudas Registrar(Deudas deuda, int idusuario, string username)
        {
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }
            using (var conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = @"INSERT INTO deudas 
                                    (usuario_id, descripcion, monto, estado, fecha_creacion)
                                    OUTPUT INSERTED.Id
                                    VALUES 
                                    (@usuario_id, @descripcion, @monto, @estado, @fecha_creacion)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", idUsuario);
                        cmd.Parameters.AddWithValue("@descripcion", deuda.Descripcion);
                        cmd.Parameters.AddWithValue("@monto", deuda.Monto);
                        cmd.Parameters.AddWithValue("@estado", deuda.Estado);
                        cmd.Parameters.AddWithValue("@fecha_creacion", deuda.FechaCreacion);
                        int id = (int)cmd.ExecuteScalar(); // Obtener el ID de la deuda insertada
                        deuda.Id = id; //
                        return deuda;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones, podrías registrar el error o lanzar una excepción personalizada
                    throw new Exception("Error al registrar la Deuda: " + ex.Message);
                }
            }
        }

        public List<Deudas> ObtenerDeudasPorUsuario(string username)
        {
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }
            using (var conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "SELECT * FROM deudas WHERE usuario_id = @usuario_id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", idUsuario);
                        using (var reader = cmd.ExecuteReader())
                        {
                            List<Deudas> deudas = new List<Deudas>();
                            while (reader.Read())
                            {
                                Deudas deuda = new Deudas
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    UsuarioId = reader.GetInt32(reader.GetOrdinal("usuario_id")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                                    Monto = reader.GetDecimal(reader.GetOrdinal("monto")),
                                    Estado = reader.GetString(reader.GetOrdinal("estado")),
                                    FechaCreacion = reader.GetDateTime(reader.GetOrdinal("fecha_creacion"))
                                };
                                deudas.Add(deuda);
                            }
                            return deudas;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las deudas: " + ex.Message);
                }
            }
        }

        public void ActualizarEstadoDeuda(int idDeuda, string nuevoEstado)
        {
            using (var conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "UPDATE deudas SET estado = @estado WHERE Id = @idDeuda";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@idDeuda", idDeuda);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el estado de la deuda: " + ex.Message);
                }
            }
        }

        public void EliminarDeuda(int idDeuda)
        {
            using (var conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "DELETE FROM deudas WHERE Id = @idDeuda";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idDeuda", idDeuda);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la deuda: " + ex.Message);
                }
            }
        }

        public Deudas Modificar(Deudas deudas, int idusuario, string username)
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
                    string query = @"UPDATE deudas 
                                    SET descripcion = @descripcion, 
                                        monto = @monto, 
                                        estado = @estado, 
                                        fecha_creacion = @fecha_creacion 
                                    WHERE Id = @idDeuda AND usuario_id = @usuario_id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@descripcion", deudas.Descripcion);
                        cmd.Parameters.AddWithValue("@monto", deudas.Monto);
                        cmd.Parameters.AddWithValue("@estado", deudas.Estado);
                        cmd.Parameters.AddWithValue("@fecha_creacion", deudas.FechaCreacion);
                        cmd.Parameters.AddWithValue("@idDeuda", deudas.Id); // Fixed: Removed ".Value" as Id is of type int
                        cmd.Parameters.AddWithValue("@usuario_id", idUsuario);
                        cmd.ExecuteNonQuery();

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la transacción o no tiene permisos para modificarla.");
                        }
                        return deudas;
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
