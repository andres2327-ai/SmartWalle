using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DALL;

namespace BLL
{
    public class TransaccionService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly TransaccionesRepository _transaccionRepository;

        public TransaccionService()
        {
            _usuarioRepository = new UsuarioRepository();
            _transaccionRepository = new TransaccionesRepository();
        }

        public void RegistrarTransaccion(Transacciones transaccion, string username)
        {
            // Obtener ID del usuario
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            string usernamepro = username;
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }

            // Registrar la transacción con el ID obtenido
            _transaccionRepository.Registrar(transaccion, idUsuario, usernamepro);
        }



        public List<Transacciones> consultarTabla(string username)
        {
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }

            return _transaccionRepository.ObtenerTransaccionesPorUsuario(idUsuario);
        }
        public void EliminarTransaccionPorId(int transaccionId)
        {
            if (transaccionId <= 0)
            {
                throw new ArgumentException("ID de transacción inválido");
            }
            _transaccionRepository.EliminarTransaccion(transaccionId);
        }
        public void ModificarTransaccion(Transacciones transaccion, string username)
        {
            if (transaccion == null || !transaccion.Id.HasValue || transaccion.Id.Value <= 0)
            {
                throw new ArgumentException("Transacción inválida");
            }

            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }

            // Se asume que el método Modificar existe en el repositorio, si no, debe implementarse.
            _transaccionRepository.Modificar(transaccion, idUsuario, username);
        }
    }

}
