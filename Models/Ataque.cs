namespace Pokedex.Models
{

    public class Ataque 
    {
        public string Nombre;
        public string Tipo;

        public Ataque (string nombre, string tipo) 
        {
            Nombre = nombre;
            Tipo = tipo;
        }
    }
}