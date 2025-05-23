using System.Text;

namespace Tarea_Programacion.Server
{
    public class ArbolBinarioBusqueda
    {
        public Nodo Raiz { get; private set; }

        public void Insertar(Informacion info)
        {
            Raiz = InsertarRec(Raiz, info);
        }

        private Nodo InsertarRec(Nodo nodo, Informacion info)
        {
            if (nodo == null) return new Nodo(info);

            if (info.Clave < nodo.Info.Clave)
                nodo.Izquierda = InsertarRec(nodo.Izquierda, info);
            else if (info.Clave > nodo.Info.Clave)
                nodo.Derecha = InsertarRec(nodo.Derecha, info);

            return nodo;
        }

        public Nodo Buscar(int clave)
        {
            return BuscarRec(Raiz, clave);
        }

        private Nodo BuscarRec(Nodo nodo, int clave)
        {
            if (nodo == null || nodo.Info.Clave == clave) return nodo;

            return clave < nodo.Info.Clave
                ? BuscarRec(nodo.Izquierda, clave)
                : BuscarRec(nodo.Derecha, clave);
        }

        public void Eliminar(int clave)
        {
            Raiz = EliminarRec(Raiz, clave);
        }

        private Nodo EliminarRec(Nodo nodo, int clave)
        {
            if (nodo == null) return null;

            if (clave < nodo.Info.Clave)
                nodo.Izquierda = EliminarRec(nodo.Izquierda, clave);
            else if (clave > nodo.Info.Clave)
                nodo.Derecha = EliminarRec(nodo.Derecha, clave);
            else
            {
                if (nodo.Izquierda == null) return nodo.Derecha;
                if (nodo.Derecha == null) return nodo.Izquierda;

                Nodo min = EncontrarMinimo(nodo.Derecha);
                nodo.Info = min.Info;
                nodo.Derecha = EliminarRec(nodo.Derecha, min.Info.Clave);
            }

            return nodo;
        }

        private Nodo EncontrarMinimo(Nodo nodo)
        {
            while (nodo.Izquierda != null)
                nodo = nodo.Izquierda;
            return nodo;
        }

        public string RecorridoInOrden() => RecorridoInOrden(Raiz).ToString();
        private StringBuilder RecorridoInOrden(Nodo nodo)
        {
            StringBuilder sb = new();
            if (nodo != null)
            {
                sb.Append(RecorridoInOrden(nodo.Izquierda));
                sb.AppendLine(nodo.Info.ToString());
                sb.Append(RecorridoInOrden(nodo.Derecha));
            }
            return sb;
        }

        public string RecorridoPreOrden() => RecorridoPreOrden(Raiz).ToString();
        private StringBuilder RecorridoPreOrden(Nodo nodo)
        {
            StringBuilder sb = new();
            if (nodo != null)
            {
                sb.AppendLine(nodo.Info.ToString());
                sb.Append(RecorridoPreOrden(nodo.Izquierda));
                sb.Append(RecorridoPreOrden(nodo.Derecha));
            }
            return sb;
        }

        public string RecorridoPosOrden() => RecorridoPosOrden(Raiz).ToString();
        private StringBuilder RecorridoPosOrden(Nodo nodo)
        {
            StringBuilder sb = new();
            if (nodo != null)
            {
                sb.Append(RecorridoPosOrden(nodo.Izquierda));
                sb.Append(RecorridoPosOrden(nodo.Derecha));
                sb.AppendLine(nodo.Info.ToString());
            }
            return sb;
        }
    }
}
