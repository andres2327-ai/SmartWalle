using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Deudas
    {
        public int? Id { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Deudas()
        {

        }
        public Deudas(int id, int usuarioId, string descripcion, decimal monto, string estado, DateTime fechaCreacion)
        {
            Id = id;
            UsuarioId = usuarioId;
            Descripcion = descripcion;
            Monto = monto;
            Estado = estado;
            FechaCreacion = fechaCreacion;
        }
    }
}
