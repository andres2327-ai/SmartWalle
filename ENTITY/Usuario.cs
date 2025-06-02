using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Presupuesto { get; set; } // Cambiado a decimal para precisión monetaria
        public DateTime FechaRegistro { get; set; } // Agregado para coincidir con la BD

        // Constructor vacío
        public Usuario() { }

        // Constructor completo
        public Usuario(int id, string telefono, string nombre, string username,
                      string password, decimal presupuesto, DateTime fechaRegistro)
        {
            Id = id;
            Telefono = telefono;
            Nombre = nombre;
            Username = username;
            Password = password;
            Presupuesto = presupuesto;
            FechaRegistro = fechaRegistro;
        }

        // Constructor para login
        public Usuario(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
