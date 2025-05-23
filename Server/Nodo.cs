using Microsoft.VisualBasic;

namespace Tarea_Programacion.Server
{
    public class Nodo
    {
        public Informacion Info { get; set; }
        public Nodo Izquierda { get; set; }
        public Nodo Derecha { get; set; }

        public Nodo(Informacion info)
        {
            Info = info;
        }
    }
}
