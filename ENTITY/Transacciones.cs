using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Transacciones
    {
        public int? Id { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }

        public string Categoria { get; set; }

       

        public Transacciones()
        {

        }

        public Transacciones(string descripcion, decimal monto, DateTime fecha, string tipo, string categoria)
        {
            this.Descripcion = descripcion;
            this.Monto = monto;
            this.Fecha = fecha;
            this.Tipo = tipo;
            this.Categoria = categoria;
        }
    }
}
