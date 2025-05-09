namespace Pokedex.Models
{

    public class Ataque 
    {
        string Nombre;
        string Efecto;

        public Ataque (string nombre, string tipo) 
        {
            Nombre = nombre;
            Tipo = tipo;
        }
    }
}