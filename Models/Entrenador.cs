namespace Pokedex.Models
{
    public class Entrenador 
    {
        public string Nombre {get; set;}
        public List<Pokemon> Equipo {get;} = new List<Pokemon>();

        public Entrenador (string nombre) 
        {
            Nombre = nombre;
        }
        public void agregarPokemon(Pokemon pokemon) 
        {
            if (Equipo.Count < 3) 
            {
                Equipo.Add(pokemon);
            }
        }
    }
}