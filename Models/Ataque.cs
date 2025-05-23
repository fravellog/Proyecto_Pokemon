namespace Pokedex.Models
{

    public class Ataque 
    {
        public string Nombre { get; set; }
        public int Poder { get; set; }
        public TipoNaturaleza Tipo { get; set; }

        public Ataque (string nombre, int poder, TipoNaturaleza tipo) 
        {
            Nombre = nombre;
            Poder = poder;
            Tipo = tipo;
        }
    }
}