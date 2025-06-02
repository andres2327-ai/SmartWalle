using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using ENTITY;

namespace BLL
{
    public class DeudasService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly DeudasRepository _deudasRepository;

        public DeudasService()
        {
            _usuarioRepository = new UsuarioRepository();
            _deudasRepository = new DeudasRepository();
        }
        public void RegistrarDeudas(ENTITY.Deudas deudas, string username)
        {
            // Obtener ID del usuario
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }
            // Registrar la Meta de Ahorro con el ID obtenido
            _deudasRepository.Registrar(deudas, idUsuario, username);
        }

        public List<ENTITY.Deudas> consultarTabla(string username)
        {
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }
            return _deudasRepository.ObtenerDeudasPorUsuario(username);
        }

        public void EliminarDeudaPorId(int deudaId)
        {
            if (deudaId <= 0)
            {
                throw new ArgumentException("ID de deuda inválido");
            }
            _deudasRepository.EliminarDeuda(deudaId);
        }

        public void ModificarDeuda(ENTITY.Deudas deuda, string username)
        {
            if (deuda == null || !deuda.Id.HasValue || deuda.Id.Value <= 0)
            {
                throw new ArgumentException("Deuda inválida");
            }
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }
            _deudasRepository.Modificar(deuda, idUsuario, username);
        }
    }
}
