using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace BLL
{
    public class UsuarioService
    {
        UsuarioRepository _usuarioRepository;
        TransaccionesRepository _transaccionRepository;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
            _transaccionRepository = new TransaccionesRepository();
        }

        public bool Login(string username, string password)
        {
            return _usuarioRepository.Login(username, password);
        }

        public int obteneridUsuario(string username)
        {
            return _usuarioRepository.obtenerIdUsuario(username);
        }

        public void ActualizarPresupuesto(int idUsuario, decimal monto, bool esSuma)
        {
           _usuarioRepository.ActualizarPresupuesto(idUsuario, monto, esSuma);
        }
        

        public void Registrar(Usuario usuario)
        {
            // Validar que el usuario no exista antes de registrar
           
            // Registrar el usuario
             _usuarioRepository.Registrar(usuario);
        }
    }
}
