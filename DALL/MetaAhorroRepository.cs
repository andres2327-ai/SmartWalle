using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DALL
{
    public class MetaAhorroRepository : BDS
    {
        private BDS _bds;
        private UsuarioRepository _usuarioRepository = new UsuarioRepository();
        public MetaAhorroRepository()
        {
            _bds = new BDS();
        }

        public MetaAhorro Registrar(MetaAhorro metaAhorro, int idusuario, string username)
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
                    string query = @"INSERT INTO metas_ahorro 
                  (usuario_id, monto_objetivo, monto_actual, nombre, completada)
                  OUTPUT INSERTED.Id
                  VALUES 
                  (@usuario_id, @monto_objetivo, @monto_actual, @nombre, @completada)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", idUsuario);
                        cmd.Parameters.AddWithValue("@monto_objetivo", metaAhorro.MontoObjetivo);
                        cmd.Parameters.AddWithValue("@monto_actual", metaAhorro.MontoActual);
                        cmd.Parameters.AddWithValue("@nombre", metaAhorro.NombreMeta);
                        cmd.Parameters.AddWithValue("@completada", metaAhorro.Completada);
                         // Asumiendo que 'categoria' es la descripción



                        int id = (int)cmd.ExecuteScalar(); // Obtener el ID de la transacción insertada
                        metaAhorro.Id = id; //
                        return metaAhorro;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones, podrías registrar el error o lanzar una excepción personalizada
                    throw new Exception("Error al registrar la Meta de Ahorro: " + ex.Message);
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }



        public List<MetaAhorro> ObtenerMetasPorUsuario(int idusuario)
        {
            List<MetaAhorro> metas = new List<MetaAhorro>();
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "SELECT id, usuario_id, monto_objetivo, monto_actual, nombre, completada, porcentaje_completado FROM metas_ahorro WHERE usuario_id = @usuario_id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", idusuario);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            metas.Add(new MetaAhorro
                            {
                                Id = reader.GetInt32(0),
                                UsuarioId = reader.GetInt32(1),
                                MontoObjetivo = reader.GetDecimal(2),
                                MontoActual = reader.GetDecimal(3),
                                NombreMeta = reader.GetString(4),
                                Completada = reader.GetBoolean(5),
                                PorcentajeCompletado = reader.IsDBNull(6) ? 0.0 : Convert.ToDouble(reader.GetDecimal(6))
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
            return metas;
        }
        public bool EliminarMeta(int idMeta)
        {
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "DELETE FROM metas_ahorro WHERE id = @id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idMeta);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la Meta de Ahorro: " + ex.Message);
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }

        public bool ActualizarMeta(MetaAhorro metaAhorro, int idusuario, string username)
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
                    string query = @"UPDATE metas_ahorro 
                                     SET monto_objetivo = @monto_objetivo, 
                                         monto_actual = @monto_actual, 
                                         nombre = @nombre, 
                                         completada = @completada
                                     WHERE id = @id AND usuario_id = @usuario_id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@monto_objetivo", metaAhorro.MontoObjetivo);
                        cmd.Parameters.AddWithValue("@monto_actual", metaAhorro.MontoActual);
                        cmd.Parameters.AddWithValue("@nombre", metaAhorro.NombreMeta);
                        cmd.Parameters.AddWithValue("@completada", metaAhorro.Completada);
                        cmd.Parameters.AddWithValue("@id", metaAhorro.Id);
                        cmd.Parameters.AddWithValue("@usuario_id", idUsuario);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar la Meta de Ahorro: " + ex.Message);
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }

        public MetaAhorro ObtenerMetaPorId(int idMeta)
        {
            using (SqlConnection conn = _bds.AbrirConexion())
            {
                try
                {
                    string query = "SELECT * FROM metas_ahorro WHERE id = @id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idMeta);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new MetaAhorro
                                {
                                    Id = reader.GetInt32(0),
                                    UsuarioId = reader.GetInt32(1),
                                    MontoObjetivo = reader.GetDecimal(2),
                                    MontoActual = reader.GetDecimal(3),
                                    NombreMeta = reader.GetString(4),
                                    Completada = reader.GetBoolean(5),
                                    PorcentajeCompletado = reader.GetDouble(6)
                                };
                            }
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la Meta de Ahorro: " + ex.Message);
                }
                finally
                {
                    _bds.CloseConnection(conn);
                }
            }
        }
    }
}
