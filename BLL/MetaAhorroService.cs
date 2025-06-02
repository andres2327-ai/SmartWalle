using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DALL;

namespace BLL
{
    public class MetaAhorroService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly MetaAhorroRepository _metaAhorroRepository;

        public MetaAhorroService()
        {
            _usuarioRepository = new UsuarioRepository();
            _metaAhorroRepository = new MetaAhorroRepository();
        }
        public void RegistrarMetaAhorro(MetaAhorro metaAhorro, string username)
        {
            // Obtener ID del usuario
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }
            // Registrar la Meta de Ahorro con el ID obtenido
            _metaAhorroRepository.Registrar(metaAhorro, idUsuario, username);
        }




        public List<MetaAhorro> consultarTabla(string username)
        {
            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }
            return _metaAhorroRepository.ObtenerMetasPorUsuario(idUsuario);
        }
        public void EliminarMetaAhorro(int metaAhorroId)
        {
            
            if (metaAhorroId == 0)
            {
                throw new Exception("Usuario no encontrado");
            }
            _metaAhorroRepository.EliminarMeta(metaAhorroId);
        }

        public void GestionarMetaAhorro(MetaAhorro metaahorro, string username)
        {
            if (metaahorro == null)
            {
                throw new ArgumentException("Transacción inválida");
            }

            int idUsuario = _usuarioRepository.obtenerIdUsuario(username);
            if (idUsuario == 0)
            {
                throw new Exception("Usuario no encontrado");
            }

            // Se asume que el método Modificar existe en el repositorio, si no, debe implementarse.
            _metaAhorroRepository.ActualizarMeta(metaahorro, idUsuario, username);
        }
    }
}
