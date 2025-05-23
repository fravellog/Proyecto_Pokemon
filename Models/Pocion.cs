namespace Pokedex.Models 
{

    public class Pocion {
        public string Nombre;
        public string TipoEfecto;
        public int Efecto;

        public Pocion(string nombre, string tipo_efecto, int efecto)
        {
            Nombre = nombre;
            TipoEfecto = tipo_efecto;
            Efecto = efecto;
        }
        public void MostrarPocion() {
            Console.WriteLine(@$"Nombre: {Nombre}
            
            Efecto: {TipoEfecto}");

        }
    }

}