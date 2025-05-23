namespace Pokedex.Models
{
    public class Entrenador 
    {
        public string Nombre {get; set;}
        public List<Pocion> Pociones { get; } = new List<Pocion>();
        public List<Pokemon> Equipo { get; } = new List<Pokemon>();
        public Entrenador(string nombre)
        {
            Nombre = nombre;
            Pociones = new List<Pocion>();
            Equipo = new List<Pokemon>();
        }
        public void agregarPokemon(Pokemon pokemon) 
        {
            if (Equipo.Count < 1) 
            {
                Equipo.Add(pokemon);
            }
        }
    }
}