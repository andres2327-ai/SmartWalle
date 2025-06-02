using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class MetaAhorro
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public decimal MontoActual { get; set; }
        public decimal MontoObjetivo { get; set; }
        public string NombreMeta { get; set; }
        public bool Completada { get; set; }
        public double PorcentajeCompletado { get; set; }

        public MetaAhorro()
        {

        }

        public MetaAhorro(int id, int usuarioId, decimal montoActual, decimal montoObjetivo, string nombreMeta, bool completada, double porcentajeCompletado)
        {

            Id = id;
            UsuarioId = usuarioId;
            MontoActual = montoActual;
            MontoObjetivo = montoObjetivo;
            NombreMeta = nombreMeta;
            Completada = completada;
            PorcentajeCompletado = porcentajeCompletado;
        }
    }
}
