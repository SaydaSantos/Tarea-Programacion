namespace Tarea_Programacion.Server
{
    public class Persona : Informacion
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public override int Clave => Edad; // Usamos Edad como clave del árbol

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Edad: {Edad}";
        }
    }
}
