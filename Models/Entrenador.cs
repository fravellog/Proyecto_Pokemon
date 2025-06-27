namespace Pokedex.Models
{
    public class Entrenador
    {
        public string Nombre { get; set; }

        public List <Pokebola> Pokebolas { get; } = new List<Pokebola>();
        public List<Pocion> Pociones { get; } = new List<Pocion>();
        public List<Pokemon> Equipo { get; } = new List<Pokemon>();
        public Entrenador(string nombre)
        {
            Nombre = nombre;
            Pociones = new List<Pocion>();
            Equipo = new List<Pokemon>();
        }
        public Entrenador()
        {
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
        public void agregarPocion(Pocion pocion)
        {
            if (Pociones.Count < 3)
            {
                Pociones.Add(pocion);
            }
            else
            {
                Console.WriteLine("¡No puedes llevar más pociones!");
            }
        }
        
        public void agregarPokebola(Pokebola pokebola)
        {
            if (Pokebolas.Count < 5)
            {
                Pokebolas.Add(pokebola);
            }
        }
    }
}