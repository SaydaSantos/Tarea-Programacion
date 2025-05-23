namespace Tarea_Programacion.Server
{
    public abstract class Informacion
    {
        public abstract int Clave { get; }

        public override string ToString()
        {
            return $"Clave: {Clave}";
        }
    }
}
